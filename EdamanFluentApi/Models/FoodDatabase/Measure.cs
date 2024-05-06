using Newtonsoft.Json;

namespace EdamanFluentApi.Model.FoodDatabase
{
    public class Measure
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }
}