namespace AzureDevOps.Integration.Models.User.Project.Response
{
    public class ProjectInfoResponse
    {
        public string AzureDevOpsOrganizationName { get; set; }

        public string AzureDevOpsProjectName { get; set; }

        public int AzureDevOpsPipelineId { get; set; }
        
        public string ProjectName { get; set; }

    }
}
