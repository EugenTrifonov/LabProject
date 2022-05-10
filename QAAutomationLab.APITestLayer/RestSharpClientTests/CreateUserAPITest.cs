using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    [TestFixture]
    public class CreateUserAPITest:BaseRestAPITest
    {
        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru","AbF61Hsn4")]
        public void CreateUserWithCorrectData(string email,string password)
        {
            RestResponse<NewUser> response = CreateUserClient.CreateUser(email, password);

            Assert.AreEqual(201, (int)response.StatusCode);
        }

        [Test]
        [TestCase("jjhfdgsfwwer@mail.ru", "AbF61Hsn4")]
        public void CreateUserWithExistingData(string email, string password)
        {
            RestResponse<NewUser> response = CreateUserClient.CreateUser(email, password);

            Assert.AreEqual(500, (int)response.StatusCode);
        }

        [Test]
        [TestCase("hgffdsdaq@mail.ru", null)]
        [TestCase("null", "AbF61Hsn4")]
        public void CreateUserWithoutFullData(string email, string password)
        {
            RestResponse<NewUser> response = CreateUserClient.CreateUser(email, password);

            Assert.AreEqual(422, (int)response.StatusCode);
        }
    }
}
