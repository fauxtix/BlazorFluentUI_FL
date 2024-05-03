using Newtonsoft.Json;

namespace EdamanFluentApi.Services
{
    public class AutoCompleteFoodDatabaseService : IAutoCompleteFoodDatabaseService
    {
        string BaseURL = string.Empty;
        string BaseURLAutoComplete = string.Empty;
        string APP_ID = string.Empty;
        string API_KEY = string.Empty;
        string TO_LIMIT = string.Empty;

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AutoCompleteFoodDatabaseService(HttpClient httpClient, IConfiguration configuration) 
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseURL = _configuration["EdamanAPISettings:FoodDatabase:BaseUrlAutoComplete"];
            APP_ID = _configuration["EdamanAPISettings:FoodDatabase:APP_ID"];
            API_KEY = _configuration["EdamanAPISettings:FoodDatabase:API_KEY"];
            TO_LIMIT = _configuration["EdamanAPISettings:FoodDatabase:TO_LIMIT"];

            _httpClient.BaseAddress = new Uri(BaseURL);

        }
        private HttpClient BaseClient
        {
            get
            {
                return _httpClient;
            }
        }

        public async Task<List<string>> RetrieveAutoCompleteItems(string query)
        {
            List<string> autoCompleteItems = new();
            string apiUrl = $"?app_id={APP_ID}&app_key={API_KEY}&q={query}&limit={TO_LIMIT}";
            try
            {
                HttpResponseMessage response = await BaseClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var stringList = JsonConvert.DeserializeObject<List<string>>(responseBody);
                    autoCompleteItems.AddRange(stringList);
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

            return autoCompleteItems;
        }

    }
}
