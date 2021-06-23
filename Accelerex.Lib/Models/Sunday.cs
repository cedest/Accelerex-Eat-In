using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Sunday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Sunday> sundayHours, List<Monday> mondayHours)
        {
            switch (sundayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(sundayHours, mondayHours);
                case 2:
                    {
                        if (sundayHours.First().Type == "close")
                        {
                            sundayHours.RemoveAt(0);
                            return ProcessHours(sundayHours, mondayHours);
                        }

                        var openTime = sundayHours.First(x => x.Type == "open");
                        var closeTime = sundayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Sunday lastOpening = null;

                        if (sundayHours.First().Type == "close")
                        {
                            sundayHours.RemoveAt(0);
                            return ProcessHours(sundayHours, mondayHours);
                        }

                        if (sundayHours.Last().Type == "open")
                        {
                            lastOpening = sundayHours.Last();
                            sundayHours.Remove(lastOpening);

                            return ProcessHours(sundayHours, mondayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(sundayHours, mondayHours, lastOpening);
                    }
            }
        }
    }
}
