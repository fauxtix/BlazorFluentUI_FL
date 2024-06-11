using EdamanFluentApi.Models.Recipes;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using EdamanFluentApi.Services.Interfaces.Edaman;

namespace EdamanFluentApi.Services.Implementations.Edaman
{
    public class RecipesService : IRecipesService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IJsonFileManager _jsonFileManager;
        private readonly IWebHostEnvironment _environment;

        private readonly string _baseURL;
        private readonly string _appID;
        private readonly string _apiKey;
        private readonly string _fromLimit;
        private readonly string _toLimit;
        private readonly ObservableCollection<Recipe> _recipes;

        public RecipesService(HttpClient httpClient, IConfiguration configuration, ProtectedSessionStorage sessionStorage,
            IJsonFileManager jsonFileManager, IWebHostEnvironment environment)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _sessionStorage = sessionStorage;
            _jsonFileManager = jsonFileManager;
            _environment = environment;

            _baseURL = _configuration["EdamanAPISettings:Recipes:BaseUrl"];
            _appID = _configuration["EdamanAPISettings:Recipes:APP_ID"];
            _apiKey = _configuration["EdamanAPISettings:Recipes:API_KEY"];
            _fromLimit = _configuration["EdamanAPISettings:Recipes:FROM_LIMIT"];
            _toLimit = _configuration["EdamanAPISettings:Recipes:TO_LIMIT"];

            _httpClient.BaseAddress = new Uri(_baseURL);

            _recipes = new ObservableCollection<Recipe>();
        }

        public async Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient, string diet, string allergie, string limit = "", string cuisineType = "")
        {
            try
            {
                limit = string.IsNullOrEmpty(limit) ? _toLimit : limit;
                string folderPath = Path.Combine(_environment.WebRootPath, "JsonFiles");
                string fileName = $"{ingredient}.json";

                if (_jsonFileManager.JsonFileExists(fileName, folderPath, cuisineType))
                {
                    return LoadFromJsonFile(fileName, folderPath, cuisineType);
                }

                string searchQuery = BuildSearchQuery(ingredient, diet, allergie, limit, cuisineType);
                HttpResponseMessage response = await _httpClient.GetAsync(searchQuery);
                string json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json))
                {
                    return null;
                }

                var allRecipesResult = JsonConvert.DeserializeObject<Result>(json);
                foreach (var hit in allRecipesResult.hits)
                {
                    _recipes.Add(hit.Recipe);
                }

                //await _sessionStorage.SetAsync(ingredient, _recipes);
                return _recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPTION: {ex}");
                return null;
            }
        }

        private string BuildSearchQuery(string ingredient, string diet, string allergie, string limit, string cuisineType)
        {
            var queryParams = new List<string>
            {
                $"q={ingredient}",
                $"app_id={_appID}",
                $"app_key={_apiKey}",
                $"from={_fromLimit}",
                $"to={limit}"
            };

            if (!string.IsNullOrEmpty(cuisineType) && cuisineType.ToLower() != "all")
            {
                queryParams.Add($"cuisineType={cuisineType}");
            }
            else
            {
                if (!string.IsNullOrEmpty(diet))
                {
                    queryParams.Add($"diet={diet}");
                }

                if (!string.IsNullOrEmpty(allergie))
                {
                    queryParams.Add($"allergie={allergie}");
                }
            }

            return $"/search?{string.Join("&", queryParams)}";
        }

        private async Task<ObservableCollection<Recipe>> GetSearchedIngredientFromLocalStorage(string ingredientKey)
        {
            try
            {
                var storedIngredientData = await _sessionStorage.GetAsync<ObservableCollection<Recipe>>(ingredientKey);
                return storedIngredientData.Success ? storedIngredientData.Value : null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error retrieving searched ingredient data from local storage: {ex.Message}");
                return null;
            }
        }

        public List<string> GetCuisineTypes()
        {
            return new List<string>
            {
                "American", "Asian", "British", "Caribbean", "Central European", "Chinese", "Eastern European",
                "French", "Indian", "Italian", "Japanese", "Kosher", "Mediterranean", "Mexican",
                "Middle Eastern", "Nordic", "South American", "South East Asian"
            };
        }

        private void SaveToJsonFile(string fileName, string folderPath, string cuisineType, ObservableCollection<Recipe> recipes)
        {
            _jsonFileManager.WriteToJsonFile(fileName, folderPath, cuisineType, recipes);
        }

        private ObservableCollection<Recipe> LoadFromJsonFile(string fileName, string folderPath, string cuisineType)
        {
            return _jsonFileManager.ReadFromJsonFile<ObservableCollection<Recipe>>(fileName, folderPath, cuisineType);
        }

        public List<string> GetJsonFiles(string cuisineType = "")
        {
            string wwwRootPath = Path.Combine(_environment.WebRootPath, "JsonFiles", cuisineType);

            if (!Directory.Exists(wwwRootPath))
            {
                return new List<string>();
            }

            var files = Directory.GetFiles(wwwRootPath, "*", SearchOption.AllDirectories);
            return files
                .Select(file => $"({new DirectoryInfo(Path.GetDirectoryName(file)).Name}) {Path.GetFileNameWithoutExtension(file)}")
                .ToList();
        }
    }
}