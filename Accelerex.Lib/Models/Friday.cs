using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Friday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Friday> fridayHours, List<Saturday> saturdayHours)
        {
            switch (fridayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(fridayHours, saturdayHours);
                case 2:
                    {
                        if (fridayHours.First().Type == "close")
                        {
                            fridayHours.RemoveAt(0);
                            return ProcessHours(fridayHours, saturdayHours);
                        }

                        var openTime = fridayHours.First(x => x.Type == "open");
                        var closeTime = fridayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Friday lastOpening = null;

                        if (fridayHours.First().Type == "close")
                        {
                            fridayHours.RemoveAt(0);
                            return ProcessHours(fridayHours, saturdayHours);
                        }

                        if (fridayHours.Last().Type == "open")
                        {
                            lastOpening = fridayHours.Last();
                            fridayHours.Remove(lastOpening);

                            return ProcessHours(fridayHours, saturdayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(fridayHours, saturdayHours, lastOpening);
                    }
            }
        }
    }
}
