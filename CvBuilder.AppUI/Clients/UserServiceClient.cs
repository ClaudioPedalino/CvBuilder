using CvBuilder.AppUI.Models;
using CvBuilder.AppUI.Models.Queries;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CvBuilder.AppUI.Clients
{
    public interface IUserServiceClient
    {
        Task<List<GetUserResponse>> GetUsers();
        Task<AuthenticationResult> Login(LoginQuery request);
    }

    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly string BASE_URL = "https://localhost:7031";


        public UserServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJjbGF1ZGlvLmRwZWRhbGlub0BnbWFpbC5jb20iLCJqdGkiOiI0Y2M0MDY1YS02YzYyLTRhYWUtYmZkNS1mYWEwNjAwYThlMDAiLCJhdXRoX3RpbWUiOiIxMS8xMS8yMDIyIiwiZW1haWwiOiJjbGF1ZGlvLmRwZWRhbGlub0BnbWFpbC5jb20iLCJuYmYiOjE2NjgyMDg5MzUsImV4cCI6MTY2ODIyMzMzMSwiaWF0IjoxNjY4MjA4OTM1fQ.Gdd2h_F7QtGzZH8jIAkKz8aYxYm7moaMPH6WmRI4cN8");
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

        public async Task<AuthenticationResult> Login(LoginQuery request)
        {
            var result = new AuthenticationResult();

            //var response = await _httpClient.PostAsJsonAsync(new Uri($"{BASE_URL}/user/login"), request);
            var response = await _httpClient.PostAsync(new Uri($"{BASE_URL}/user/login"), JsonContent.Create(request));

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<AuthenticationResult>(jsonResponse);

            }

            return result;
        }
    }
}
