using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class CreateApplicationAPITests : BaseRestAPITest
    {
        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void CreateApplicationWithAcessToken(string email, string password)
        {
            PlaygroundAPIClient.CreateUser(email, password);

            RestResponse<SucessfullLogInUser> loginResponse = PlaygroundAPIClient.LogIn(email, password);

            var data = JsonConvert.DeserializeObject<SucessfullLogInUser>(loginResponse.Content, new JsonSerializerSettings()
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

            Assert.AreEqual(200, (int)createApplicationResponse.StatusCode);
        }

        [Test]
        public void CreateApplicationWithoutAcessToken()
        {
            var appData = new AppElements()
            {
                phone_number = "1234567",
                Email = "vdsfsgdr@gmail.com",
                LinkedIn = "linkedin.com",
                Github = "github.com",
                HomePage = "www.homepage.com"
            };

            RestResponse<ApplicationData> createApplicationResponse = PlaygroundAPIClient.CreateApp(appData);

            Assert.AreEqual(401, (int)createApplicationResponse.StatusCode);
        }
    }
}
