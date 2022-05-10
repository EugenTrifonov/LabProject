using RestSharp.Authenticators;
using System.Text.Json.Serialization;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests.Models
{
    public class SucessfullLogInUser
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
