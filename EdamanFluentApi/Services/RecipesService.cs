using EdamanFluentApi.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EdamanFluentApi.Services
{
    public class RecipesService : IRecipesService
    {
        string BaseURL = string.Empty;
        string APP_ID = string.Empty;
        string API_KEY = string.Empty;
        string FROM_LIMIT = string.Empty;
        string TO_LIMIT = string.Empty;

        protected ObservableCollection<Recipe> recipes;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public RecipesService(HttpClient httpClient, IConfiguration config)
        {
            recipes = new ObservableCollection<Recipe>();
            _httpClient = httpClient;

            _configuration = config;

            BaseURL = _configuration["EdamanAPISettings:Recipes:BaseUrl"];
            APP_ID = _configuration["EdamanAPISettings:Recipes:APP_ID"];
            API_KEY = _configuration["EdamanAPISettings:Recipes:API_KEY"];
            FROM_LIMIT = _configuration["EdamanAPISettings:Recipes:FROM_LIMIT"];
            TO_LIMIT = _configuration["EdamanAPISettings:Recipes:TO_LIMIT"];

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

                if (diet.Equals("") && allergie.Equals(""))
                {
                    search = "/search?q=" + ingredient + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={TO_LIMIT}";
                }
                else
                {
                    if (!diet.Equals("") && !allergie.Equals(""))
                    {
                        search = "/search?q=" + ingredient + "&diet=" + diet + "&allergie=" + allergie + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={TO_LIMIT}";
                    }
                    else if (!diet.Equals(""))
                    {
                        search = "/search?q=" + ingredient + "&diet=" + diet + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={TO_LIMIT}";
                    }
                    else search = "/search?q=" + ingredient + "&allergie=" + allergie + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={TO_LIMIT}";
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
