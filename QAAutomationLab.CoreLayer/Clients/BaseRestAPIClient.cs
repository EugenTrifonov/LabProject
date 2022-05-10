using System.Threading.Tasks;
using RestSharp;

namespace QAAutomationLab.CoreLayer.Clients
{
    public abstract class BaseRestAPIClient
    {
        protected BaseRestAPIClient(string url)
        {
            Client = new RestClient(url);
            BaseUrl = url;
        }

        public RestClient Client { get; protected set; }

        public string BaseUrl{ get; private set; }

        public RestRequest CreateRequest(string resourse, Method method)
        {
            var request = new RestRequest(resourse, method);

            request.RequestFormat = DataFormat.Json;

            return request;
        }

        public void AddHeader(string name, string value)
        {
            Client.AddDefaultHeader(name, value);
        }

        public RestResponse ExecuteAsyncRequest(RestRequest request)
        {
            var response = Client.ExecuteAsync(request);

            return response.Result;
        }

        public RestResponse<T> ExecuteAsyncRequest<T>(RestRequest request)
        {
            var response = Client.ExecuteAsync<T>(request);

            return response.Result;
        }
    }
}
