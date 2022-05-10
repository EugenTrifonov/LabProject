using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class LoginApiTests:BaseRestAPITest
    {

        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void LogInWithCorrectData(string email, string password)
        {
            RestResponse<SucessfullLogInUser> response = LoginClient.LogIn(email, password);

            Assert.AreEqual(200, (int)response.StatusCode);
        }

        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "Adsfdsf2")]
        public void LoginWithIncorrectData(string email, string password) 
        {
            RestResponse<SucessfullLogInUser> response = LoginClient.LogIn(email, password);

            Assert.AreEqual(422, (int)response.StatusCode);
        }

        [Test]
        [TestCase(null, "AbF61Hsn4")]
        [TestCase("fsfsfsfsf234@mail.ru", null)]
        public void LoginWithNullData(string email, string password)
        {
            RestResponse<SucessfullLogInUser> response = LoginClient.LogIn(email, password);

            Assert.AreEqual(422, (int)response.StatusCode);
        }
    }
}
