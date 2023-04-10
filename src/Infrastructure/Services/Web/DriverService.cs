using Kasi.Domain.Entities;

namespace Kasi.Infrastructure.Services.Web
{
    public class DriverService : IDriverService
    {
        private readonly HttpClient _httpClient;

        public DriverService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private Encoding encoding = Encoding.UTF8;
        private string mediaType = "application/json";
        private string route = "drivers";


        public async Task<Driver> CreateAsync(Driver request)
        {
            try
            {
                StringContent itemJson = new StringContent(JsonSerializer.Serialize(request), encoding, mediaType );

                HttpResponseMessage response = await _httpClient.PostAsync(route, itemJson);

                if(response.IsSuccessStatusCode)
                {
                    Stream responseBody = await response.Content.ReadAsStreamAsync();
                    
                    Driver? newDriver = await JsonSerializer.DeserializeAsync<Driver>(
                        responseBody,
                        new JsonSerializerOptions{PropertyNameCaseInsensitive = true}
                    );

                    return newDriver??new Driver();
                }

                return new Driver();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage reponse = await _httpClient.DeleteAsync($"{route}/{id}");
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public async Task<IEnumerable<Driver>> QueryAsync()
        {
            try
            {
                Stream reponse = await _httpClient.GetStreamAsync(route);

                IEnumerable<Driver>? drivers = await JsonSerializer.DeserializeAsync<IEnumerable<Driver>>(
                    reponse,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
                );

                return drivers??new List<Driver>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public async Task<Driver?> ReadAsync(int id)
        {
            try
            {
                Stream reponse = await _httpClient.GetStreamAsync($"{route}/{id}");

                Driver? driver = await JsonSerializer.DeserializeAsync<Driver>(
                    reponse,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true}
                );

                return driver;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }

        public async Task<Driver?> UpdateAsync(Driver request)
        {
            try
            {
                StringContent itemJson = new StringContent(JsonSerializer.Serialize(request), encoding, mediaType);

                HttpResponseMessage response = await _httpClient.PostAsync($"{route}/{request.Id}", itemJson);

                if(response.IsSuccessStatusCode)
                {
                    Stream responseBody = await response.Content.ReadAsStreamAsync();
                    
                    Driver? updatedDriver = await JsonSerializer.DeserializeAsync<Driver>(
                        responseBody,
                        new JsonSerializerOptions{PropertyNameCaseInsensitive = true}
                    );

                    return updatedDriver;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
                throw e;
            }
        }
    }
}