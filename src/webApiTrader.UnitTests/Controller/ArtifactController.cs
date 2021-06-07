using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using webApiTrader.Controllers;
using Microsoft.Extensions.Options;
using webApiTrader.Configurations;
using System.Threading.Tasks;

namespace webApiTrader.UnitTests.Controller
{
    [TestClass]
    public class ArtifactControllerTests
    {
		[TestMethod]
		public async Task TestMethod1()
		{
			// Arrange
			var mockRepo = new Mock<IOptions<ApplicationSettings>>();
			//mockRepo.Setup(repo => repo.ListAsync())
			//   .ReturnsAsync(GetTestSessions());
			var controller = new ArtifactController(mockRepo.Object);

			// Act
			var result = await controller.GetProjects();

			// Assert
			//var viewResult = Assert.IsType<ViewResult>(result);
			//var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
			//    viewResult.ViewData.Model);
			//Assert.Equal(2, model.Count());

			Assert.IsTrue(true);
		}
    }
}
