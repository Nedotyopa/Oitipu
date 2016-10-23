using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToplivoCodeFirst.Controllers;
using System.Web.Mvc;

namespace ToplivoCodeFirst.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Топливная база", result.ViewBag.Message);
        }

        
    }
}
