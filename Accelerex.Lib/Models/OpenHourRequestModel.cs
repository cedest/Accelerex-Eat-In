using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerex.Lib.Model
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
