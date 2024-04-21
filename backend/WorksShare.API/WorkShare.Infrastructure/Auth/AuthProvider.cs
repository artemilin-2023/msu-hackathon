using RestSharp;
using System.Text.Json.Serialization;
using WorkShare.Application.Abstracts;

namespace WorkShare.Infrastructure.Auth
{
    public class AuthProvider : IAuthProvider
    {
        private class Response
        {
            [JsonPropertyName("user_id")]
            public int UserId { get; set; }
        }

        private readonly RestClient client;
        private const string url = "https://api.test.profcomff.com/auth/";

        public AuthProvider()
        {
            client = new RestClient(url);
        }

        public async Task<int> GetUserIdAsync(string token)
        {
            var request = new RestRequest("session");
            request.AddHeader("Authorization", token);

            var response = await client.GetAsync<List<Response>>(request);
            return response[0].UserId;
        }
    }
}
