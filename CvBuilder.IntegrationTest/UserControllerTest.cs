using CvBuilder.Core.UserCases.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace CvBuilder.IntegrationTest
{
    public class UserControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Theory]
        [InlineData("claudio.dpedalino@gmail.com", "Temporal1#")]
        public async Task Test1(string user, string pass)
        {
            var result = new List<GetUserResponse>();

            var client = _factory.CreateClient();
            var response = await client.GetAsync("/user");

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<GetUserResponse>>(jsonResponse);
            }

            Assert.NotEmpty(result);
        }
    }
}