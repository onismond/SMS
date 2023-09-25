using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SMS.Util.Network
{
    public class MyApi
    {
        public string baseAddress = "http://127.0.0.1/api/";
        public HttpClient client;
        public MyApi(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<TReturn> Post<TReturn>(string address, Dictionary<string, string> values)
        {
            var content = new FormUrlEncodedContent(values);
            using var response = await client.PostAsync(baseAddress + address, content);
            response.EnsureSuccessStatusCode();
            var responseObject = await response.Content.ReadFromJsonAsync<TReturn>();
            //dynamic jsonObj = JsonSerializer.Deserialize<dynamic>(responseString);
            return responseObject;
        }

        public async Task<TReturn> Get<TReturn>(string address)
        {
            var responseObject = await client.GetFromJsonAsync<TReturn>(baseAddress + address);
            //dynamic responseString = await client.GetStringAsync(baseAddress + address);
            //dynamic jsonObj = JsonSerializer.Deserialize<dynamic>(responseString);
            return responseObject;
        }
    }
}
