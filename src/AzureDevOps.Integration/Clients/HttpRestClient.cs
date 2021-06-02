using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureDevOps.Integration.REST.Clients
{
    public class HttpRestClient
    {
        private const string JsonMediaType = "application/json";
        private const string AuthenticationHeaderMethod = "Basic";

        private readonly string _personalaccesstoken;

        public HttpRestClient(string patToken)
        {
            _personalaccesstoken = patToken;
        }
        public async Task ExecuteGetAsync(string targetUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(JsonMediaType));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderMethod,
                    Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", "", _personalaccesstoken))));

                using (HttpResponseMessage response = await client.GetAsync(targetUrl))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
            }
        }

        public async Task ExecutePostAsync(string targetUrl, string payload)
        {          
            StringContent content = new StringContent(payload, System.Text.Encoding.UTF8, JsonMediaType);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonMediaType));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderMethod, Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", _personalaccesstoken))));
                              
                using (HttpResponseMessage response = await client.PostAsync(targetUrl, content))
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
            }
        }
    }
}
