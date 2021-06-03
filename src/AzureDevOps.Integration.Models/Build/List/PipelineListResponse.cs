﻿
using System.Collections.Generic;

namespace AzureDevOps.Integration.Models.Build.List
{    public class Self
    {
        public string href { get; set; }
    }
        public class Web
    {
        public string href { get; set; }
    }
        public class Links
    {
        public Self self { get; set; }
        public Web web { get; set; }
    }

    public class PipelineItem
    {
        public Links _links { get; set; }
        public string url { get; set; }
        public int id { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public string folder { get; set; }
    }

    public class PipelineListResponse
    {
        public int count { get; set; }
        public List<PipelineItem> value { get; set; }
    }     
}
