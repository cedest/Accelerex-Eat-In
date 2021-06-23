using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Thursday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Thursday> thursdayHours, List<Friday> fridayHours)
        {
            switch (thursdayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(thursdayHours, fridayHours);
                case 2:
                    {
                        if (thursdayHours.First().Type == "close")
                        {
                            thursdayHours.RemoveAt(0);
                            return ProcessHours(thursdayHours, fridayHours);
                        }

                        var openTime = thursdayHours.First(x => x.Type == "open");
                        var closeTime = thursdayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Thursday lastOpening = null;

                        if (thursdayHours.First().Type == "close")
                        {
                            thursdayHours.RemoveAt(0);
                            return ProcessHours(thursdayHours, fridayHours);
                        }

                        if (thursdayHours.Last().Type == "open")
                        {
                            lastOpening = thursdayHours.Last();
                            thursdayHours.Remove(lastOpening);

                            return ProcessHours(thursdayHours, fridayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(thursdayHours, fridayHours, lastOpening);
                    }
            }
        }
    }
}
