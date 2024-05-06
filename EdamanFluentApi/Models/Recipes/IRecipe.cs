using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Models.Recipes
{
    public interface IRecipe
    {
        [JsonProperty("uri")]
        Uri Uri { get; set; }

        [JsonProperty("label")]
        string Label { get; set; }

        [JsonProperty("image")]
        Uri Image { get; set; }

        [JsonProperty("source")]
        string Source { get; set; }

        [JsonProperty("url")]
        Uri Url { get; set; }

        [JsonProperty("shareAs")]
        Uri ShareAs { get; set; }

        [JsonProperty("yield")]
        long Yield { get; set; }

        [JsonProperty("cautions")]
        string[] Cautions { get; set; }

        [JsonProperty("ingredientLines")]
        string[] IngredientLines { get; set; }

        [JsonProperty("ingredients")]
        Ingredient[] IngredientsRecipe { get; set; }

        [JsonProperty("calories")]
        double Calories { get; set; }

        [JsonProperty("totalWeight")]
        double TotalWeight { get; set; }

        [JsonProperty("totalTime")]
        long TotalTime { get; set; }

        [JsonProperty("totalNutrients")]
        Dictionary<string, Total> TotalNutrients { get; set; }

        [JsonProperty("totalDaily")]
        Dictionary<string, Total> TotalDaily { get; set; }

        [JsonProperty("digest")]
        Digest[] Digest { get; set; }

        double RecipeCalories { get; }
    }
}
