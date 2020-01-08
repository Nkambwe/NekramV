

using Nekram.Models.Application;
using NUnit.Framework;

namespace Nekram.Tests.ApplicationModuleTests {

    [TestFixture]
    public class BranchTests {

        private Branch _owner;

        [SetUp]
        public void SetUp() {
            _owner = new Branch();
        }

        [TestCase(1)]
        public void NvUser_HasNoIdentity_ReturnFalse(int id)  {
            _owner.Id = id;
            var result = _owner.HasNoIdentity();
            Assert.IsFalse(result);
        }

        [TestCase(1, 2)]
        public void NvUser_WithSameId_AreEqual_ReturnTrue(int id, int sid) {
            _owner.Id = 1;
            var anotherowber = new Branch { Id = id};
            var aresame = _owner == anotherowber;
            var someco = _owner.Equals(anotherowber);

            var sowner = new Branch { Id=sid};
            var arenotsame = _owner != sowner;
            
            Assert.IsTrue(aresame);
            Assert.IsTrue(someco);
            Assert.AreEqual(_owner, anotherowber);

            Assert.IsTrue(arenotsame);
            Assert.AreNotEqual(_owner, sowner);
        }

        [TestCase("Senk Ink", "309 Avelon", "P.O.Box 30046", "(256)700109803")]
        public void NvUSer_Version_HasValues(string legal, string address, string postal, string tel) {
            _owner.LegalName = legal;
            _owner.Address = address;
            _owner.PostalAddress = postal;
            _owner.Telephone = tel;

            Assert.That(!string.IsNullOrEmpty(_owner.LegalName));
            Assert.That(!string.IsNullOrEmpty(_owner.Address));
            Assert.That(!string.IsNullOrEmpty(_owner.PostalAddress));
            Assert.That(!string.IsNullOrEmpty(_owner.Telephone));


        }
    }
}
