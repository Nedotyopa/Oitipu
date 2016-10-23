using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToplivoCodeFirst.Controllers;
using System.Web.Mvc;
using Moq;
using System.Web;

namespace ToplivoCodeFirst.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //имитация сессии
            var context = new Mock<ControllerContext>();
            var session = new Mock<HttpSessionStateBase>();
            context.Setup(m => m.HttpContext.Session).Returns(session.Object);

            // Arrange
            HomeController controller = new HomeController();
            controller.ControllerContext = context.Object;
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
