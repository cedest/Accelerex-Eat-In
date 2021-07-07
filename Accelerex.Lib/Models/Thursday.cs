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
            return OpenHourHelper.DoProcessHours(thursdayHours, fridayHours);
        }
    }
}
