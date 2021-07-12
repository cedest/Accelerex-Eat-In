using Newtonsoft.Json;
using System.Collections.Generic;

namespace Accelerex.Lib.Models
{

    public class OpenHourRequestModel
    {
        [JsonProperty(PropertyName = "monday")]
        public List<Monday> Monday { get; set; }

        [JsonProperty(PropertyName = "tuesday")]
        public List<Tuesday> Tuesday { get; set; }

        [JsonProperty(PropertyName = "wednesday")]
        public List<Wednesday> Wednesday { get; set; }

        [JsonProperty(PropertyName = "thursday")]
        public List<Thursday> Thursday { get; set; }

        [JsonProperty(PropertyName = "friday")]
        public List<Friday> Friday { get; set; }

        [JsonProperty(PropertyName = "saturday")]
        public List<Saturday> Saturday { get; set; }

        [JsonProperty(PropertyName = "sunday")]
        public List<Sunday> Sunday { get; set; }

    }
}
