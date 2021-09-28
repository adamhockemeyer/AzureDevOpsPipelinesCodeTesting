using NUnit.Framework;
using SampleApp.Controllers;
using Microsoft.Extensions.Logging.Abstractions;

namespace SampleApp.Tests
{
    [TestFixture, Category("Unit")]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(1, "Adam")]
        [TestCase(2, "Susan")]
        [TestCase(3, "Julie")]
        public void Does_Username_Match_Id(int userId, string name)
        {
            // Arrange
            var controller = new HomeController(new NullLogger<HomeController>());

            // Act
            string result = controller.GetUserName(userId);

            // Assert
            Assert.AreEqual(name, result);
        }
    }
}