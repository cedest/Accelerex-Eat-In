using System;
using System.Collections.Generic;
using System.Linq;

namespace Accelerex.Lib.Helpers
{
    public static class OpenHourHelper
    {
        public static string ProcessAllEntries<T, U>(List<T> tuesdayHours, List<U> wednesdayHours, T lastOpening) where T : class, new()
        {
            List<string> result = new List<string>();

            for (int i = 0; i <= (tuesdayHours.Count / 2);)
            {
                T openTime = tuesdayHours[i];
                T closeTime = tuesdayHours[i + 1];

                result.Add(ProcessTwoEntries(openTime, closeTime));
                i += 2;
            }

            if (lastOpening != null)
            {
                T closeTimeFromWed = wednesdayHours.Select(x => new
                {
                    Type = ((dynamic)x).Type,
                    Value = ((dynamic)x).Value
                }).ToList().First(x => x.Type == "close") as T;

                if (((dynamic)wednesdayHours.First()).Type == "open")
                {
                    closeTimeFromWed = default;
                }

                result.Add(ProcessTwoEntries(lastOpening, closeTimeFromWed));
            }

            return string.Join(", ", result);
        }

        public static string ProcessTwoEntries<T>(T openTime, T closeTime)
        {
            List<string> result = new List<string>();

            if (openTime == null)
            {
                result.Add("Error - Open time not set");
            }
            else
            {
                dynamic open = ConvertEpochTime(((dynamic)openTime).Value.ToString());
                result.Add(open);
            }

            if (closeTime == null)
            {
                result.Add("Error - Close time not set");
            }
            else
            {
                dynamic close = ConvertEpochTime(((dynamic)closeTime).Value.ToString());
                result.Add(close);
            }

            return string.Join(" - ", result);
        }

        public static string ProcessOneEntry<T, U>(List<T> tuesdayHours, List<U> wednesdayHours)
        {
            List<string> result = new List<string>();

            if (((dynamic)tuesdayHours.First()).Type == "close")
            {
                return "Closed";
            }

            dynamic openTime = ConvertEpochTime(((dynamic)tuesdayHours.First()).Value.ToString());
            result.Add(openTime);

            if (wednesdayHours.Count == 0 || ((dynamic)wednesdayHours.First()).Type == "open")
            {
                result.Add("Error - Close time not set");
            }
            else
            {
                dynamic closeTime = ConvertEpochTime(((dynamic)wednesdayHours.First()).Value.ToString());
                result.Add(closeTime);
            }

            return string.Join(" - ", result);
        }

        public static string ConvertEpochTime(string time)
        {
            bool isTime = double.TryParse(time, out double result);
            result = (!isTime) ? 0 : result;

            string hourSuffix = " AM";
            double conversion = Math.Round((24 * result) / 86400);

            if (conversion > 12)
            {
                conversion -= 12;
                hourSuffix = " PM";
            }

            return $"{conversion}{hourSuffix}";
        }

        public static string DoProcessHours<T, U>(List<T> dayHours, List<U> nextDayHours) where T : class, new() where U : class
        {
            switch (dayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return ProcessOneEntry(dayHours, nextDayHours);
                case 2:
                    {
                        if (((dynamic)dayHours.First()).Type == "close")
                        {
                            dayHours.RemoveAt(0);
                            return DoProcessHours(dayHours, nextDayHours);
                        }

                        T openTime = dayHours.First(x => ((dynamic)x).Type == "open");
                        T closeTime = dayHours.First(x => ((dynamic)x).Type == "close");

                        return ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        T lastOpening = null;

                        if (((dynamic)dayHours.First()).Type == "close")
                        {
                            dayHours.RemoveAt(0);
                            return DoProcessHours(dayHours, nextDayHours);
                        }

                        if (((dynamic)dayHours.Last()).Type == "open")
                        {
                            lastOpening = dayHours.Last();
                            dayHours.Remove(lastOpening);

                            return DoProcessHours(dayHours, nextDayHours);
                        }

                        return ProcessAllEntries(dayHours, nextDayHours, lastOpening);
                    }
            }
        }
    }
}
