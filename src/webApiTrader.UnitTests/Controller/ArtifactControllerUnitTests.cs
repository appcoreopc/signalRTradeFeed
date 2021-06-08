using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using webApiTrader.Controllers;
using Microsoft.Extensions.Options;
using webApiTrader.Configurations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webApiTrader.UnitTests.Controller
{
    [TestClass]
    public class ArtifactControllerUnitTests
	{
		[TestMethod]
		public async Task WhenGetProjectsCalled_Then_Return_JsonResult()
		{
			// Arrange
			var mockRepo = new Mock<IOptions<ApplicationSettings>>();
			//mockRepo.Setup(repo => repo.ListAsync())
			//   .ReturnsAsync(GetTestSessions());
			var controller = new ArtifactController(mockRepo.Object);

			// Act
			var result = await controller.GetProjects();

			// Assert
			Assert.IsInstanceOfType(result, typeof(OkObjectResult));
		}
    }
}
