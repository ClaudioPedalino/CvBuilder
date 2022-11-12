using Newtonsoft.Json;

namespace CvBuilder.AppUI.Clients
{
    public interface IUserServiceClient
    {
        Task<List<GetUserResponse>> GetUsers();
    }

    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string BASE_URL = "https://localhost:7031";


        public UserServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<GetUserResponse>> GetUsers()
        {
            var result = new List<GetUserResponse>();

            var response = await _httpClient.GetAsync(new Uri($"{BASE_URL}/user"));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<GetUserResponse>>(jsonResponse);
            }

            return result;

        }
    }
}
