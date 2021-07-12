using Accelerex.Lib.Helpers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Accelerex.Lib.Models
{
    public class DaysOfWeekModel<TDay1, TDay2> where TDay1 : class, new() where TDay2 : class, new()
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        public static string ProcessHours(List<TDay1> todayHours, List<TDay2> nextDayHours)
        {
            return OpenHourHelper.DoProcessHours(todayHours, nextDayHours);
        }
    }
}
