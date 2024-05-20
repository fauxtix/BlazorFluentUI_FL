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
        string BaseURL = string.Empty;
        string APP_ID = string.Empty;
        string API_KEY = string.Empty;
        string FROM_LIMIT = string.Empty;
        string TO_LIMIT = string.Empty;

        protected ObservableCollection<Recipe> recipes;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IJsonFileManager _jsonFileManager;
        private readonly IWebHostEnvironment _environment;

        public RecipesService(HttpClient httpClient, IConfiguration config, ProtectedSessionStorage SessionStorage,
            IJsonFileManager jsonFileManager, IWebHostEnvironment environment)
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
            _sessionStorage = SessionStorage;
            _jsonFileManager = jsonFileManager;
            _environment = environment;
        }

        private HttpClient BaseClient
        {
            get
            {
                return _httpClient;
            }
        }

        public async Task<ObservableCollection<Recipe>> SearchRecipes(string ingredient,
                                                                      string diet,
                                                                      string allergie,
                                                                      string limit = "",
                                                                      string cuisineType = "")
        {
            try
            {
                if (string.IsNullOrEmpty(limit))
                {
                    limit = TO_LIMIT;
                }

                string folderPath = Path.Combine(_environment.WebRootPath, "JsonFiles");

                var fileName = $"{ingredient}.json";
                bool fileExists = _jsonFileManager.JsonFileExists(fileName, folderPath, cuisineType);
                if (fileExists)
                {
                    return LoadFromJsonFile(fileName, folderPath, cuisineType);
                }

                //var localstorageResults = await GetSearchedIngredientFromLocalStorage(ingredient);
                //if (localstorageResults is not null)
                //{
                //    return localstorageResults;
                //}

                string search = "";

                if (diet.Equals("") && allergie.Equals("") && cuisineType.Equals(""))
                {
                    search = "/search?q=" + ingredient + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={limit}";
                }
                else
                {
                    if (!string.IsNullOrEmpty(cuisineType) && cuisineType != "All")
                    {
                        search = "/search?q=" + ingredient + $"&cuisineType={cuisineType}" + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={limit}";

                    }
                    else if (!diet.Equals("") && !allergie.Equals(""))
                    {
                        search = "/search?q=" + ingredient + "&diet=" + diet + "&allergie=" + allergie + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={limit}";
                    }
                    else if (!diet.Equals(""))
                    {
                        search = "/search?q=" + ingredient + "&diet=" + diet + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={limit}";
                    }
                    else search = "/search?q=" + ingredient + "&allergie=" + allergie + $"&app_id={APP_ID}&app_key={API_KEY}&from={FROM_LIMIT}&to={limit}";
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

                SaveToJsonFile(fileName, folderPath, cuisineType, recipes);
                //await _sessionStorage.SetAsync(ingredient, recipes);

                return recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("EXCEPTION: " + ex);
                return null;
            }
        }

        private async Task<ObservableCollection<Recipe>> GetSearchedIngredientFromLocalStorage(string ingredientKey)
        {
            try
            {
                var storedIngredientData = await _sessionStorage.GetAsync<ObservableCollection<Recipe>>(ingredientKey);
                if (storedIngredientData.Success)
                {
                    return storedIngredientData.Value;
                }
                else
                {
                    return null; // Return null if no ingredient is stored locally
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error retrieving searched ingredient data from local storage: " + ex.Message);
                return null;
            }
        }

        public List<string> GetCuisineTypes()
        {
            return new List<string>
            {
                "American",
                "Asian",
                "British",
                "Caribbean" ,
                "Central Euope",
                "Chinese" ,
                "Eastern Europe",
                "French",
                "Indian",
                "Italian",
                "Japanese",
                "Kosher",
                "Mediterranean",
                "Mexican",
                "Moddle Eastern",
                "Nordic",
                "South American",
                "South East Asian"
            };
        }
        private void SaveToJsonFile(string fileName, string folderPath, string cuisineType, ObservableCollection<Recipe> recipes)
        {
            _jsonFileManager.WriteToJsonFile(fileName, folderPath, cuisineType, recipes);
        }

        private ObservableCollection<Recipe> LoadFromJsonFile(string fileName, string folderPath, string cuisineType)
        {
            ObservableCollection<Recipe> recipes = _jsonFileManager.ReadFromJsonFile<ObservableCollection<Recipe>>(fileName, folderPath, cuisineType);
            return recipes;
        }

        public List<string> GetJsonFiles(string cuisineType = "")
        {

            // Get the physical path to the wwwroot directory
            var wwwRootPath = Path.Combine(_environment.WebRootPath, "JsonFiles", cuisineType);

            // Check if the directory exists
            if (!Directory.Exists(wwwRootPath))
            {
                // Handle the case when the directory does not exist
                return new List<string>();
            }

            // Get the list of files in the JsonFiles directory
            var files = Directory.GetFiles(wwwRootPath, "", SearchOption.AllDirectories);

            // Extract filenames from full paths
            var filenames = new List<string>();
            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string directoryName = new DirectoryInfo(Path.GetDirectoryName(file)).Name;
                filenames.Add($"({directoryName}) {fileName}");
            }
            return filenames;
        }
    }
}
