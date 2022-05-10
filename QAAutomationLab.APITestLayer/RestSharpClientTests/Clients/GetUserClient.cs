using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    public class GetUserClient:BaseRestAPIClient
    {
        public string Url { get; private set; }

        public GetUserClient(string url)
            : base(url)
        {
            Url = url + "/users/{Id}";
        }

        public RestResponse<NewUser> GetUser(int id)
        {
            RestRequest request = CreateRequest(Url, Method.Get);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<NewUser>(request);
        }
    }
}
