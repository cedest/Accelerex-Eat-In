using Accelerex.Lib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Model
{
    public class Tuesday
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<Tuesday> tuesdayHours, List<Wednesday> wednesdayHours)
        {
            switch (tuesdayHours.Count)
            {
                case 0:
                    return "Closed";
                case 1:
                    return OpenHourHelper.ProcessOneEntry(tuesdayHours, wednesdayHours);
                case 2:
                    {
                        if (tuesdayHours.First().Type == "close")
                        {
                            tuesdayHours.RemoveAt(0);
                            return ProcessHours(tuesdayHours, wednesdayHours);
                        }

                        var openTime = tuesdayHours.First(x => x.Type == "open");
                        var closeTime = tuesdayHours.First(x => x.Type == "close");

                        return OpenHourHelper.ProcessTwoEntries(openTime, closeTime);
                    }
                default:
                    {
                        Tuesday lastOpening = null;

                        if (tuesdayHours.First().Type == "close")
                        {
                            tuesdayHours.RemoveAt(0);
                            return ProcessHours(tuesdayHours, wednesdayHours);
                        }

                        if (tuesdayHours.Last().Type == "open")
                        {
                            lastOpening = tuesdayHours.Last();
                            tuesdayHours.Remove(lastOpening);

                            return ProcessHours(tuesdayHours, wednesdayHours);
                        }

                        return OpenHourHelper.ProcessAllEntries(tuesdayHours, wednesdayHours, lastOpening);
                    }
            }
        }
    }
}
