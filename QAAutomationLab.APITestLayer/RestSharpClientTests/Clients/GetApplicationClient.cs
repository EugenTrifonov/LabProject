using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests.Clients
{
    public class GetApplicationClient:BaseRestAPIClient
    {
        public string Url { get; private set; }

        public GetApplicationClient(string url)
            : base(url)
        {
            Url = url + "/application/{Id}";
        }

        public RestResponse<ApplicationData> GetApp(int id)
        {
            RestRequest request = CreateRequest(Url, Method.Get);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<ApplicationData>(request);
        }

        public RestResponse<ApplicationData> UpdateApp(int id,AppElements data)
        {
            RestRequest request = CreateRequest(Url, Method.Put);
            request.AddUrlSegment("Id", id);
            request.AddBody(data);

            return ExecuteAsyncRequest<ApplicationData>(request);
        }

        public RestResponse<SuccessMessage> DeleteApp(int id)
        {
            RestRequest request = CreateRequest(Url, Method.Delete);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<SuccessMessage>(request);
        }
    }
}
