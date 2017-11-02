using System.Web.Mvc;
using WebApp;
using WebApp.Controllers;
using Xunit;

namespace WebApp.Tests.Controllers
{    
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Home Page", result.ViewBag.Title);
        }
    }
}
