using Newtonsoft.Json;

namespace EdamanFluentApi.Model.FoodDatabase
{
    public class Hint
    {
        [JsonProperty("food")]
        public Food Food { get; set; }

        [JsonProperty("measures")]
        public List<Measure> Measures { get; set; }
    }
}