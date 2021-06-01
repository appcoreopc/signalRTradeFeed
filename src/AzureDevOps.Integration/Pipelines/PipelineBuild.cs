using System.Threading.Tasks;
using Flurl.Http;
namespace AzureDevOps.Integration.REST.Pipelines
{
    public class PipelineBuild
    {

    }

    class PipelineBuildApiClient
    {
        private readonly string _url; 

        public PipelineBuildApiClient(string url)
        {
            _url = url;
        }

        public async Task Execute()
        {
          await _url.GetJsonAsync<string>();
        }
    }
}
