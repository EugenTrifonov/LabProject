using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests
{
    public class DeleteUserClient : BaseRestAPIClient
    {
        public string Url { get; private set; }

        public DeleteUserClient(string url)
            : base(url)
        {
            Url = url + "/users/{Id}";
        }

        public RestResponse<SuccessMessage> DeleteUser(int id)
        {
            RestRequest request = CreateRequest(Url, Method.Delete);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<SuccessMessage>(request);
        }
    }
}
