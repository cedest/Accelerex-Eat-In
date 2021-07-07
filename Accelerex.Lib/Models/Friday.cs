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
            return OpenHourHelper.DoProcessHours(fridayHours, saturdayHours);
        }
    }
}
