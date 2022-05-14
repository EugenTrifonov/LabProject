﻿using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class GetApplicationTests:BaseRestAPITest
    {
        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void GetApplicationWithAccessToken(string email, string password)
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

            RestResponse<ApplicationData> crateApplicationResponse = PlaygroundAPIClient.CreateApp(appData);

            var appId = JsonConvert.DeserializeObject<ApplicationData>(crateApplicationResponse.Content, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            }).applicant_id;

            RestResponse<ApplicationData> getApplicationResponse = PlaygroundAPIClient.GetApp(appId);

            Assert.AreEqual(200, (int)getApplicationResponse.StatusCode);
        }

        [Test]
        public void GetApplicationWithoutAccessToken()
        {
            var id = 1;

            RestResponse<ApplicationData> getApplicationResponse = PlaygroundAPIClient.GetApp(id);

            Assert.AreEqual(401, (int)getApplicationResponse.StatusCode);
        }
    }
}
