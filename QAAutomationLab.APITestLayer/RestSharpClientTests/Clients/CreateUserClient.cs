using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    public class CreateUserClient : BaseRestAPIClient
    {
        public string Url { get; private set; }

        public CreateUserClient(string url)
            : base(url)
        {
            Url = url + "/users";
        }

        public RestResponse<NewUser> CreateUser(string email, string password)
        {
            RestRequest request = CreateRequest(Url, Method.Post);

            request.AddBody(new UserData { Email = email, Password = password });

            return ExecuteAsyncRequest<NewUser>(request);
        }
    }
}
