using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace convertificationatorAPI.Service
{
    public class ForexAPIService { 

        public string getForex(string apiKey)
        {
            var client = new RestClient("http://www.apilayer.net/api");
            var request = new RestRequest("/live")
            {
                Method = Method.GET
            };
            request.AddQueryParameter("access_key", apiKey);
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
    }
}
