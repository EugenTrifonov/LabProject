using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class DeleteAppTests:BaseRestAPITest
    {
        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void DeleteAppWithAcessToken(string email, string password)
        {
            PlaygroundAPIClient.CreateUser(email, password);

            RestResponse<SucessfullLogInUser> response = PlaygroundAPIClient.LogIn(email, password);

            var data = JsonConvert.DeserializeObject<SucessfullLogInUser>(response.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            var token = data.Token;
            int id = data.Id;

            var appData = new AppElements()
            {
                phone_number = "1234567",
                Email = email,
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com"
            };

            PlaygroundAPIClient.Client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");

            RestResponse<ApplicationData> createApplicationResponse = PlaygroundAPIClient.CreateApp(appData);

            var app_data = JsonConvert.DeserializeObject<ApplicationData>(createApplicationResponse.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            var appId = app_data.applicant_id;

            RestResponse<SuccessMessage> deleteApplicationResponse = PlaygroundAPIClient.DeleteApp(appId);

            Assert.AreEqual(200, (int)deleteApplicationResponse.StatusCode);
        }
    }
}
