using EdamanFluentApi.Model.FoodDatabase;
using EdamanFluentApi.Services.Interfaces.Edaman;
using Newtonsoft.Json;

namespace EdamanFluentApi.Services.Implementations.Edaman
{
    public class FoodDatabaseService : IFoodDatabaseService
    {
        string BaseURL = string.Empty;
        string APP_ID = string.Empty;
        string API_KEY = string.Empty;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FoodDatabaseService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseURL = _configuration["EdamanAPISettings:FoodDatabase:BaseUrl"];
            APP_ID = _configuration["EdamanAPISettings:FoodDatabase:APP_ID"];
            API_KEY = _configuration["EdamanAPISettings:FoodDatabase:API_KEY"];

            _httpClient.BaseAddress = new Uri(BaseURL);
        }

        private HttpClient BaseClient
        {
            get
            {
                return _httpClient;
            }
        }
        public async Task<List<Food>> RetrieveAllFoodItems(string query)
        {
            List<Food> allFoodItems = new List<Food>();

            string apiUrl = $"parser?ingr={query}&app_id={APP_ID}&app_key={API_KEY}&nutrition-type=cooking";

            try
            {
                HttpResponseMessage response = await BaseClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    EdamamApiDatabaseResponse foodResponse = JsonConvert.DeserializeObject<EdamamApiDatabaseResponse>(responseBody);

                    if (foodResponse.Hints != null && foodResponse.Hints.Any())
                    {
                        foreach (var hint in foodResponse.Hints)
                        {
                            allFoodItems.Add(new Food
                            {
                                FoodId = hint.Food.FoodId,
                                Label = hint.Food.Label,
                                KnownAs = hint.Food.KnownAs,
                                Nutrients = hint.Food.Nutrients,
                                Category = hint.Food.Category,
                                CategoryLabel = hint.Food.CategoryLabel,
                                Image = hint.Food.Image
                            });
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return allFoodItems;
        }
    }
}
