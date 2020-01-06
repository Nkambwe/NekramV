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

        [TestCase("","","")]
        public void NewConfig_IsNull_ReturnsTrue(string module, string version, string name) {
            _config.ApplicationName = name;
            _config.Modules = module;
            _config.Version = version;
            Assert.IsTrue(_config.IsNull);
        }

        [TestCase("Nekram v105")]
        public void NewConfig_Application_HasAname(string appname) {

            _config.ApplicationName = appname;
            Assert.That(!string.IsNullOrEmpty(_config.ApplicationName));
        }

        [TestCase(null, "")]
        public void NewConfig_ApplicationName_IsNullOrEmpty(string nullable, string empty) {
            _config.ApplicationName = nullable;
            Assert.IsNull(_config.ApplicationName);

            _config.ApplicationName = empty;
            Assert.IsEmpty(_config.ApplicationName);
        }

        [TestCase(null, "")]
        public void NewConfig_Version_IsNullOrEmpty(string nullable, string empty) {
            _config.Version = nullable;
            Assert.IsNull(_config.Version);

            _config.Version = empty;
            Assert.IsEmpty(_config.Version);
        }
    }
}
