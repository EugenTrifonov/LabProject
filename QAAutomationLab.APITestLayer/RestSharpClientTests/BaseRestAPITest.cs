using NUnit.Framework;
using QAAutomationLab.APITestLayer.RestSharpClientTests.Clients;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    public class BaseRestAPITest
    {
        protected CreateUserClient CreateUserClient { get; set; }
        protected LoginClient LoginClient { get; set; }
        protected GetUserClient GetUserClient { get; set; }
        protected DeleteUserClient DeleteUserClient { get; set; }
        protected CreateApplicationClient CreateApplicationClient { get; set; }
        protected GetApplicationClient GetApplicationClient { get; set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            CreateUserClient = new CreateUserClient("https://api.playgroundtech.io/v1");
            LoginClient = new LoginClient("https://api.playgroundtech.io/v1");
            GetUserClient = new GetUserClient("https://api.playgroundtech.io/v1");
            DeleteUserClient = new DeleteUserClient("https://api.playgroundtech.io/v1");
            CreateApplicationClient = new CreateApplicationClient("https://api.playgroundtech.io/v1");
            GetApplicationClient = new GetApplicationClient("https://api.playgroundtech.io/v1");
        }
    }
}
