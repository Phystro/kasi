namespace Kasi.Web.Client.Services
{
    public class DriverService : IDriverService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public DriverService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                // PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        private Encoding encoding = Encoding.UTF8;
        private string mediaType = "application/json";
        private string route = "api/driver";


        public async Task<DriverResponse> CreateAsync(DriverRequest request)
        {            
            try
            {
                StringContent itemJson = new StringContent(JsonSerializer.Serialize(request), encoding, mediaType );

                HttpResponseMessage response = await _httpClient.PostAsync(route, itemJson);

                if(response.IsSuccessStatusCode)
                {
                    Stream responseBody = await response.Content.ReadAsStreamAsync();

                    // TODO: Unable to do JSON Desrilization To Entity. PLEASE FIX
                    // Driver? newDriver = await JsonSerializer.DeserializeAsync<Driver>(
                    //     responseBody,
                    //     new JsonSerializerOptions{PropertyNameCaseInsensitive = true}
                    // );

                    // return newDriver??new Driver();
                    return new DriverResponse();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Error creating driver: {response.StatusCode} {errorResponse}");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error deserializing JSON response: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error: {e.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                HttpResponseMessage reponse = await _httpClient.DeleteAsync($"{route}/{id}");
                return reponse.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error: {e.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<DriverResponse>> QueryAsync()
        {
            try
            {
                Stream reponse = await _httpClient.GetStreamAsync(route);

                IEnumerable<DriverResponse>? drivers = await JsonSerializer.DeserializeAsync<IEnumerable<DriverResponse>>(
                    reponse,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
                );

                return drivers??new List<DriverResponse>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error deserializing JSON response: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error: {e.Message}");
                throw;
            }
        }

        public async Task<DriverResponse?> ReadAsync(string id)
        {
            try
            {
                Stream reponse = await _httpClient.GetStreamAsync($"{route}/{id}");

                DriverResponse? driver = await JsonSerializer.DeserializeAsync<DriverResponse>(
                    reponse,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
                );

                return driver;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error deserializing JSON response: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error: {e.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(string id, DriverRequest request)
        {
            try
            {
                StringContent itemJson = new StringContent(JsonSerializer.Serialize(request), encoding, mediaType);

                HttpResponseMessage response = await _httpClient.PutAsync($"{route}/{id}", itemJson);

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Error deserializing JSON response: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unknown error: {e.Message}");
                throw;
            }
        }
    }
}
