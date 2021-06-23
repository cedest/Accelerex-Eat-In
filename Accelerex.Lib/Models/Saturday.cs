using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Saturday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Saturday> saturdayHours, List<Sunday> sundayHours)
        {
            switch (saturdayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(saturdayHours, sundayHours);
                case 2:
                    {
                        if (saturdayHours.First().Type == "close")
                        {
                            saturdayHours.RemoveAt(0);
                            return ProcessHours(saturdayHours, sundayHours);
                        }

                        var openTime = saturdayHours.First(x => x.Type == "open");
                        var closeTime = saturdayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Saturday lastOpening = null;

                        if (saturdayHours.First().Type == "close")
                        {
                            saturdayHours.RemoveAt(0);
                            return ProcessHours(saturdayHours, sundayHours);
                        }

                        if (saturdayHours.Last().Type == "open")
                        {
                            lastOpening = saturdayHours.Last();
                            saturdayHours.Remove(lastOpening);

                            return ProcessHours(saturdayHours, sundayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(saturdayHours, sundayHours, lastOpening);
                    }
            }
        }
    }
}
