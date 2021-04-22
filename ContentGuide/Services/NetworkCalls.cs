using System;
using RestSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

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
                string loginData = JsonConvert.SerializeObject(ojObject);
                return loginData;
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

        public string SaveUserPreferences(string token, string emailAddress, string selectedGenres)
        {
            Console.WriteLine("call to api");
            var client = new RestClient("https://content-guide.herokuapp.com/user-preferences");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"email_address\": \"" + emailAddress + "\",\"preferences\": [" + selectedGenres + "]}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return response.StatusCode.ToString();
            }
            catch
            {
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
                Console.WriteLine(response);
                return response.Content;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string Movies(string token, string preferences)
        {
            Console.WriteLine(preferences);
            var client = new RestClient("https://content-guide.herokuapp.com/personalized-movies");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer "+token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"categories\" : [\n        "+preferences+"    ]\n}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string TVshows(string token, string preferences)
        {
            Console.WriteLine(preferences);
            var client = new RestClient("https://content-guide.herokuapp.com/personalized-tv-shows");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"categories\" : [\n    "+preferences+"    ]\n}", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }

        public string ContentDetails(string token, string name)
        {
            var client = new RestClient("https://content-guide.herokuapp.com/content-details");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\n    \"name\" :    \""+ name +"\"\n    }", ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                JObject joResponse = JObject.Parse(response.Content);
                JObject ojObject = (JObject)joResponse;
                string jsonData = JsonConvert.SerializeObject(ojObject["data"]);
                return jsonData;
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return "null";
            }
        }
    }
}
