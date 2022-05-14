using Newtonsoft.Json;
using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class GetUserAPITest:BaseRestAPITest
    {
        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void GetUserWithAccessToken(string email, string password)
        {
            PlaygroundAPIClient.CreateUser(email, password);

            RestResponse<SucessfullLogInUser> response = PlaygroundAPIClient.LogIn(email, password);

            var data = JsonConvert.DeserializeObject<SucessfullLogInUser>(response.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            var token = data.Token;
            int id = data.Id;

            PlaygroundAPIClient.Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

            RestResponse<NewUser> getuserresponse = PlaygroundAPIClient.GetUser(id);

            PlaygroundAPIClient.DeleteUser(id);

            Assert.AreEqual(200, (int)getuserresponse.StatusCode);
        }

        [Test]
        public void GetUserWithoutAcessToken()
        {
            var id = 1;

            RestResponse<NewUser> getuserresponse = PlaygroundAPIClient.GetUser(id);

            Assert.AreEqual(401, (int)getuserresponse.StatusCode);
        }
    }
}
