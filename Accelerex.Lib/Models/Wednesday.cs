using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Wednesday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Wednesday> wednesdayHours, List<Thursday> thursdayHours)
        {
            switch (wednesdayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(wednesdayHours, thursdayHours);
                case 2:
                    {
                        if (wednesdayHours.First().Type == "close")
                        {
                            wednesdayHours.RemoveAt(0);
                            return ProcessHours(wednesdayHours, thursdayHours);
                        }

                        var openTime = wednesdayHours.First(x => x.Type == "open");
                        var closeTime = wednesdayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Wednesday lastOpening = null;

                        if (wednesdayHours.First().Type == "close")
                        {
                            wednesdayHours.RemoveAt(0);
                            return ProcessHours(wednesdayHours, thursdayHours);
                        }

                        if (wednesdayHours.Last().Type == "open")
                        {
                            lastOpening = wednesdayHours.Last();
                            wednesdayHours.Remove(lastOpening);

                            return ProcessHours(wednesdayHours, thursdayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(wednesdayHours, thursdayHours, lastOpening);
                    }
            }
        }
    }
}
