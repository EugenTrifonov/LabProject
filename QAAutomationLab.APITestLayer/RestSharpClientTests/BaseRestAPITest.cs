using Newtonsoft.Json;
using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Clients;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    public class BaseRestAPITest
    {
        protected PlaygroundAPIClient PlaygroundAPIClient { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            PlaygroundAPIClient = new PlaygroundAPIClient("https://api.playgroundtech.io/v1");
        }

        [TearDown]
        public void TearDown()
        {
            string email = "jjhfdgsfwwer@mail.ru";
            string password = "AbF61Hsn4";

            RestResponse<SucessfullLogInUser> response = PlaygroundAPIClient.LogIn(email, password);

            var data = JsonConvert.DeserializeObject<SucessfullLogInUser>(response.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            var token = data.Token;
            int id = data.Id;

            PlaygroundAPIClient.Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

            RestResponse<SuccessMessage> deleteuserresponse = PlaygroundAPIClient.DeleteUser(id);
        }
    }
}
