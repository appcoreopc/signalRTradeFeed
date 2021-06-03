using Newtonsoft.Json;
using System;

namespace AzureDevOps.Integration.Models.Pipeline.Run.Response
{
    // Getting status of a specific pipeline runs
    public class Self
    {
        public string href { get; set; }
        public Repository repository { get; set; }
        public string refName { get; set; }
        public string version { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }

    public class PipelineWeb
    {
        public string href { get; set; }
    }

    public class Pipeline
    {
        public string href { get; set; }
        public string url { get; set; }
        public int id { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public string folder { get; set; }
    }

    public class Links
    {
        public Self self { get; set; }
        public Web web { get; set; }

        [JsonProperty("pipeline.web")]
        public PipelineWeb PipelineWeb { get; set; }
        public Pipeline pipeline { get; set; }
    }

    public class Repository
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class Repositories
    {
        public Self self { get; set; }
    }

    public class Resources
    {
        public Repositories repositories { get; set; }
    }

    public class PipelineRunResponse
    {
        public Links _links { get; set; }
        public Pipeline pipeline { get; set; }
        public string state { get; set; }
        public string result { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime finishedDate { get; set; }
        public string url { get; set; }
        public Resources resources { get; set; }
        public int id { get; set; }
        public string name { get; set; }
    }
}
