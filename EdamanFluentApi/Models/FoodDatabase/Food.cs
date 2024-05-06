using Newtonsoft.Json;

namespace EdamanFluentApi.Model.FoodDatabase
{
    public class Food
    {
        [JsonProperty("foodId")]
        public string FoodId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("knownAs")]
        public string KnownAs { get; set; }

        [JsonProperty("nutrients")]
        public Nutrients Nutrients { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}