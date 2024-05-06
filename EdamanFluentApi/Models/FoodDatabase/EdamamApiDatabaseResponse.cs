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

    public class Measure
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }

    public class Hint
    {
        [JsonProperty("food")]
        public Food Food { get; set; }

        [JsonProperty("measures")]
        public List<Measure> Measures { get; set; }
    }

    public class EdamamApiDatabaseResponse
    {
        [JsonProperty("hints")]
        public List<Hint> Hints { get; set; }
    }

    public class AutoCompleteItem
    {
        public List<string> Result { get; set; }
    }
}