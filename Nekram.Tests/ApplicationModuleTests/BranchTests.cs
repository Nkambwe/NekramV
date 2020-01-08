

using System.Linq;
using Nekram.Models.Application;
using NUnit.Framework;

namespace Nekram.Tests.ApplicationModuleTests {

    [TestFixture]
    public class BranchTests {

        private Branch _branch;

        [SetUp]
        public void SetUp() {
            _branch = new Branch();
        }

        [TestCase(1)]
        public void Branch_HasNoIdentity_ReturnFalse(int id)  {
            _branch.Id = id;
            var result = _branch.HasNoIdentity();
            Assert.IsFalse(result);
        }

        [TestCase(1, 2)]
        public void Branch_WithSameId_AreEqual_ReturnTrue(int id, int sid) {
            _branch.Id = 1;
            var anotherowber = new Branch { Id = id};
            var aresame = _branch == anotherowber;
            var someco = _branch.Equals(anotherowber);

            var sowner = new Branch { Id=sid};
            var arenotsame = _branch != sowner;
            
            Assert.IsTrue(aresame);
            Assert.IsTrue(someco);
            Assert.AreEqual(_branch, anotherowber);

            Assert.IsTrue(arenotsame);
            Assert.AreNotEqual(_branch, sowner);
        }

        [TestCase("Senk Ink", "309 Avelon", "P.O.Box 30046", "(256)700109803")]
        public void Branch_Version_HasValues(string legal, string address, string postal, string tel) {
            _branch.LegalName = legal;
            _branch.Address = address;
            _branch.PostalAddress = postal;
            _branch.Telephone = tel;

            Assert.That(!string.IsNullOrEmpty(_branch.LegalName));
            Assert.That(!string.IsNullOrEmpty(_branch.Address));
            Assert.That(!string.IsNullOrEmpty(_branch.PostalAddress));
            Assert.That(!string.IsNullOrEmpty(_branch.Telephone));


        }

        [TestCase("Senk Associates")]
        public void BranchLegalName_IsRequired_Returns_True(string legalname) {
            _branch.LegalName = legalname;
            var result = _branch.Validate().Count(x => x.MemberNames.Contains("LegalName"));
            Assert.That(result == 0);
        }

        [TestCase("309 Heavens Gate")]
        public void BranchAddress_IsRequired_Returns_True(string address) {
            _branch.Address = address;
            var result = _branch.Validate().Count(x => x.MemberNames.Contains("Address"));
            Assert.That(result == 0);
        }

        [TestCase("P.O.Box 222786")]
        public void BranchPostalAddress_IsRequired_Returns_True(string postaddress) {
            _branch.PostalAddress = postaddress;
            var result = _branch.Validate().Count(x => x.MemberNames.Contains("PostalAddress"));
            Assert.That(result == 0);
        }

        [TestCase("039785908")]
        public void BranchTelephone_IsRequired_Returns_True(string phone) {
            _branch.Telephone = phone;
            var result = _branch.Validate().Count(x => x.MemberNames.Contains("Telephone"));
            Assert.That(result == 0);
        }
    }
}
