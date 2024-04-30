using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Model
{
    public partial class Total
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

    }
}
