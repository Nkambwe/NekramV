using NUnit.Framework;
using Nekram.Models.Application;

namespace Nekram.Tests.ApplicationModuleTests {
    [TestFixture]
    public class AppmoduleTests {
        private Appconfig  _config;

        [SetUp]
        public void Setup() {
            _config = new Appconfig();
        }

        [Test]
        public void NewConfig_IsValid_ReturnsTrue() {
            Assert.IsNotNull(_config);
        }
    }
}
