

using Nekram.Repositories.Application;
using NUnit.Framework;

namespace Nekram.Tests.ApplicationModuleTests {

    [TestFixture()]
    public class AppconfirepoTests {

        private AppconfigRepository _configrepo;

        [SetUp]
        public void Setup() {
            _configrepo = new AppconfigRepository();
        }

        [Test]
        public void NewConfigRepo_IsValid_ReturnsTrue() {
            Assert.IsNotNull(_configrepo);
        }
    }
}
