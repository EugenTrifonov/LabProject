using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests.Clients
{
    public class CreateApplicationClient:BaseRestAPIClient
    {
        public string Url { get; private set; }

        public CreateApplicationClient(string url)
            : base(url)
        {
            Url = url + "/application";
        }

        public RestResponse<ApplicationData> CreateApp(AppElements data)
        {
            RestRequest request = CreateRequest(Url, Method.Post);

            request.AddBody(data);

            return ExecuteAsyncRequest<ApplicationData>(request);
        }
    }
}
