using Newtonsoft.Json;

namespace EdamanFluentApi.Model.FoodDatabase
{
    public class Nutrients
    {
        [JsonProperty("ENERC_KCAL")]
        public double Energy { get; set; }

        [JsonProperty("PROCNT")]
        public double Protein { get; set; }

        [JsonProperty("FAT")]
        public double Fat { get; set; }

        [JsonProperty("CHOCDF")]
        public double Carbohydrates { get; set; }

        [JsonProperty("FIBTG")]
        public double Fiber { get; set; }
    }
}