namespace Kasi.Web.Client.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public TeamService(HttpClient httpClient)
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
        private string route = "api/team";

        public async Task<TeamResponse> CreateAsync(TeamRequest request)
        {
            // request.Id = 6;
            Console.WriteLine($"Request: {request}, {request.Name}");

            try
            {
                StringContent itemJson = new StringContent(JsonSerializer.Serialize(request), encoding, mediaType );
                Console.WriteLine($"Request StringContent: {itemJson}");

                HttpResponseMessage response = await _httpClient.PostAsync(route, itemJson);

                if(response.IsSuccessStatusCode)
                {
                    Stream responseBody = await response.Content.ReadAsStreamAsync();
                    Console.WriteLine($"Request Stream Response Body: {responseBody}");

                    // TODO: Unable to do JSON Desrilization To Entity. PLEASE FIX
                    // Team? newTeam = await JsonSerializer.DeserializeAsync<Team>(responseBody);

                    // Console.WriteLine(newTeam);
                    // Console.WriteLine($"Request newTeam: {newTeam.Id}, {newTeam.Name}");

                    // return newTeam??new Team();
                    return new TeamResponse();
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

        public async Task<IEnumerable<TeamResponse>> QueryAsync()
        {
            try
            {
                Stream reponse = await _httpClient.GetStreamAsync(route);

                IEnumerable<TeamResponse>? teams = await JsonSerializer.DeserializeAsync<IEnumerable<TeamResponse>>(
                    reponse,
                    _options
                );

                return teams??new List<TeamResponse>();
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

        public async Task<TeamResponse?> ReadAsync(string id)
        {
            try
            {
                Stream reponse = await _httpClient.GetStreamAsync($"{route}/{id}");

                TeamResponse? team = await JsonSerializer.DeserializeAsync<TeamResponse>(
                    reponse,
                    _options
                );

                return team;
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

        public async Task<bool> UpdateAsync(string id, TeamRequest request)
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