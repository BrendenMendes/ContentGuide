using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace ContentGuide.Services
{
    public class NetworkCalls
    {
        public NetworkCalls()
        {

        }

        public string Login(string email_address, string password)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"email_address\" : \""+email_address+"\",\n    \"password\" : \""+password+"\"\n}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                JObject joResponse = JObject.Parse(response.Content);
                JObject ojObject = (JObject)joResponse;
                string token = (string)ojObject["token"];
                return token;
            }
            catch(Exception error) {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string Signup(string username, string email_address, string password)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/signup");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"username\" : \""+username+"\",\n    \"email_address\" : \""+email_address+"\",\n    \"password\" : \""+password+"\"\n}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                JObject joResponse = JObject.Parse(response.Content);
                JObject ojObject = (JObject)joResponse;
                string token = (string)ojObject["token"];
                return token;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string Trending(string token)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/trending");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer "+token);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string Movies(string token)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/personalized-movies");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"categories\" : [\n        \"Action\",\"Adventure\"\n    ]\n}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string TVshows(string token)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/personalized-tv-shows");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"categories\" : [\n        \"Action\",\"Adventure\"\n    ]\n}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return response.Content;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }
    }
}
