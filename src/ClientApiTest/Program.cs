using System;
using System.Threading.Tasks;
using AzureDevOps.Integration.Models.Pipeline.Run.Request;
using AzureDevOps.Integration.REST.Clients;
using Newtonsoft.Json;

namespace ClientApiTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var c = new HttpRestClient("g5ia7mwddvuf22bslp6lxfqs5mqx4b5gb7sfxd2q65odgngcvkjq");

            //await c.Execute("https://dev.azure.com/wwnz/API/_apis/build/builds?api-version=6.0");

            //await c.ExecuteGetAsync("https://dev.azure.com/WWNZ/API/_apis/pipelines/677/runs/76870?api-version=6.0-preview.1");

            // queue a build 
            // https://dev.azure.com/{organization}/{project}/_apis/build/builds?api-version=6.0

            var newBuild = new RunPipelineRequest
            {
                Organization = "WWNZ",
                Project = "API", 
                APIVersion = "6.0",               
                PipelineId = 677, 
                PipelineVersion = 6
            };

            var json = JsonConvert.SerializeObject(newBuild);
            await c.ExecutePostAsync($"https://dev.azure.com/{newBuild.Organization}/{newBuild.Project}/_apis/pipelines/{newBuild.PipelineId}/runs?api-version=6.0-preview.1", json);
        }
    }

   
}
