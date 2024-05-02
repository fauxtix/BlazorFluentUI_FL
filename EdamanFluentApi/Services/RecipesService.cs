using EdamanFluentApi.Model;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EdamanFluentApi.Services
{
    public class RecipesService : IRecipesService
    {
        const string BaseURL = "https://api.edamam.com/api/recipes/v2";
        const string APP_ID = "8aa2358e";
        const string API_KEY = "0130404d401d25aef31206a71a985fee";
        protected ObservableCollection<Recipe> recipes;

        private readonly HttpClient _httpClient;
        public RecipesService(HttpClient httpClient)
        {
            recipes = new ObservableCollection<Recipe>();
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        private HttpClient BaseClient
        {
            get
            {
                return _httpClient;
            }
        }
        public async Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient, string diet, string allergie)
        {
            try
            {
                string search = "";
                const string fromLimit = "0";
                const string toLimit = "25";

                if (diet.Equals("") && allergie.Equals(""))
                {
                    search = "/search?q=" + ingredient + $"&app_id={APP_ID}&app_key={API_KEY}&from={fromLimit}&to={toLimit}";
                }
                else
                {
                    if (!diet.Equals("") && !allergie.Equals(""))
                    {
                        search = "/search?q=" + ingredient + "&diet=" + diet + "&allergie=" + allergie + $"&app_id={APP_ID}&app_key={API_KEY}&from={fromLimit}&to={toLimit}";
                    }
                    else if (!diet.Equals(""))
                    {
                        search = "/search?q=" + ingredient + "&diet=" + diet + $"&app_id={APP_ID}&app_key={API_KEY}&from={fromLimit}&to={toLimit}";
                    }
                    else search = "/search?q=" + ingredient + "&allergie=" + allergie + $"&app_id={APP_ID}&app_key={API_KEY}&from={fromLimit}&to={toLimit}";
                }

                var response = await BaseClient.GetAsync(string.Format(search, API_KEY,
                   ingredient));

                var json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json)) return null;

                var allRecipesResult = JsonConvert.DeserializeObject<Result>(json);

                var result = new Result(allRecipesResult.hits);

                for (int i = 0; i < result.hits.Count; i++)
                {
                    recipes.Add(result.hits[i].Recipe);
                }
                return recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPTION" + ex);
                return null;
            }
        }
    }
}
