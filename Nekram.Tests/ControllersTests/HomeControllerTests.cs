using System.Web.Mvc;
using Nekram.App.Controllers;
using NUnit.Framework;

namespace Nekram.Tests.ControllersTests {

    [TestFixture()]
    public class HomeControllerTests {

        private HomeController _controller;

        [SetUp]
        public void SetUp() { _controller = new HomeController(); }

        [Test]
        public void Index_HasNoModel_ReturnTrue() {
            var result = _controller.Index() as ViewResult;
            // ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(null, result.Model);
        }
    }
}
