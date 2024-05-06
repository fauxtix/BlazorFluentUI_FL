using Newtonsoft.Json;

namespace EdamanFluentApi.Models.Recipes
{
    public partial class Digest
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("sub", NullValueHandling = NullValueHandling.Ignore)]
        public Digest[] Sub { get; set; }
    }
}
