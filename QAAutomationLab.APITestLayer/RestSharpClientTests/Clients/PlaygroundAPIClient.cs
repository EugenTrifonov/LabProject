using QAAutomationLab.APITestLayer.RestSharpClientTests.Models;
using QAAutomationLab.CoreLayer.Clients;
using RestSharp;

namespace QAAutomationLab.APITestLayer.RestSharpClientTests.Clients
{
    public class PlaygroundAPIClient:BaseRestAPIClient
    {
        public string Url { get; private set; }

        public PlaygroundAPIClient(string url)
            : base(url) 
        {
            Url = url;
        }

        public RestResponse<SucessfullLogInUser> LogIn(string email, string password)
        {
            string url = Url + "/login";

            RestRequest request = CreateRequest(url, Method.Post);

            request.AddBody(new UserData { Email = email, Password = password });

            return ExecuteAsyncRequest<SucessfullLogInUser>(request);
        }

        public RestResponse<NewUser> GetUser(int id)
        {
            string url = Url + "/users/{Id}";

            RestRequest request = CreateRequest(url, Method.Get);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<NewUser>(request);
        }

        public RestResponse<ApplicationData> GetApp(int id)
        {
            string url = Url + "/application/{Id}";

            RestRequest request = CreateRequest(url, Method.Get);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<ApplicationData>(request);
        }

        public RestResponse<ApplicationData> UpdateApp(int id, AppElements data)
        {
            string url = Url + "/application/{Id}";

            RestRequest request = CreateRequest(url, Method.Put);
            request.AddUrlSegment("Id", id);
            request.AddBody(data);

            return ExecuteAsyncRequest<ApplicationData>(request);
        }

        public RestResponse<SuccessMessage> DeleteApp(int id)
        {
            string url = Url + "/application/{Id}";

            RestRequest request = CreateRequest(url, Method.Delete);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<SuccessMessage>(request);
        }

        public RestResponse<SuccessMessage> DeleteUser(int id)
        {
            string url = Url + "/users/{Id}";

            RestRequest request = CreateRequest(url, Method.Delete);
            request.AddUrlSegment("Id", id);

            return ExecuteAsyncRequest<SuccessMessage>(request);
        }

        public RestResponse<NewUser> CreateUser(string email, string password)
        {
            string url = Url + "/users";

            RestRequest request = CreateRequest(url, Method.Post);

            request.AddBody(new UserData { Email = email, Password = password });

            return ExecuteAsyncRequest<NewUser>(request);
        }

        public RestResponse<ApplicationData> CreateApp(AppElements data)
        {
            string url = Url + "/application";

            RestRequest request = CreateRequest(url, Method.Post);

            request.AddBody(data);

            return ExecuteAsyncRequest<ApplicationData>(request);
        }
    }
}
