using Newtonsoft.Json;

namespace EdamanFluentApi.Model.FoodDatabase
{

    public class EdamamApiDatabaseResponse
    {
        [JsonProperty("hints")]
        public List<Hint> Hints { get; set; }
    }
}