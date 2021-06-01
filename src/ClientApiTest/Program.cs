using System;
using System.Threading.Tasks;
using AzureDevOps.Integration.REST.Clients;
using Flurl.Http;

namespace ClientApiTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var c = new HttpRestClient("");
            //await c.Execute("https://dev.azure.com/wwnz/API/_apis/build/builds?api-version=6.0");

            await c.Execute("https://dev.azure.com/WWNZ/API/_apis/pipelines/677/runs/76870?api-version=6.0-preview.1");
        }
    }
}
