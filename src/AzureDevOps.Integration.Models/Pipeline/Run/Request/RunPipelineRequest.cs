using Newtonsoft.Json;

namespace AzureDevOps.Integration.Models.Pipeline.Run.Request
{
    public class RunPipelineRequest
    {
        public string Organization { get; set; }
        public int PipelineId { get; set; }

        public string Project { get; set; }

        [JsonProperty("api-version")]
        public string APIVersion { get; set; }

        public int PipelineVersion { get; set; }
    }
}
