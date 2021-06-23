using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Monday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Monday> mondayHours, List<Tuesday> tuesdayHours)
        {
            switch (mondayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(mondayHours, tuesdayHours);
                case 2:
                    {
                        if (mondayHours.First().Type == "close")
                        {
                            mondayHours.RemoveAt(0);
                            return ProcessHours(mondayHours, tuesdayHours);
                        }

                        var openTime = mondayHours.First(x => x.Type == "open");
                        var closeTime = mondayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Monday lastOpening = null;

                        if (mondayHours.First().Type == "close")
                        {
                            mondayHours.RemoveAt(0);
                            return ProcessHours(mondayHours, tuesdayHours);
                        }

                        if (mondayHours.Last().Type == "open")
                        {
                            lastOpening = mondayHours.Last();
                            mondayHours.Remove(lastOpening);

                            return ProcessHours(mondayHours, tuesdayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(mondayHours, tuesdayHours, lastOpening);
                    }
            }
        }
    }
}
