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
            return OpenHourHelper.DoProcessHours(tuesdayHours, wednesdayHours);
        }
    }
}
