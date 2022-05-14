﻿using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class DeleteUserTests:BaseRestAPITest
    {
        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void DeleteUserWithAccessToken(string email, string password)
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

            RestResponse<SuccessMessage> deleteuserresponse = PlaygroundAPIClient.DeleteUser(id);

            Assert.AreEqual(200, (int)deleteuserresponse.StatusCode);
        }

        [Test]
        public void DeleteUserWithoutAcessToken()
        {
            var id = 1;

            RestResponse<SuccessMessage> deleteuserresponse = PlaygroundAPIClient.DeleteUser(id);

            Assert.AreEqual(401, (int)deleteuserresponse.StatusCode);
        }
    }
}
