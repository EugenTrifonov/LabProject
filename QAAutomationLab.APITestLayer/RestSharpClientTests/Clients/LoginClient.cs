using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    public class LoginClient:BaseRestAPIClient
    {
        public string Url { get; private set; }

        public LoginClient(string url)
            : base(url)
        {
            Url = url + "/login";
        }

        public RestResponse<SucessfullLogInUser> LogIn(string email, string password)
        {
            RestRequest request = CreateRequest(Url, Method.Post);

            request.AddBody(new UserData { Email = email, Password = password });

            return ExecuteAsyncRequest<SucessfullLogInUser>(request);
        }
    }
}
