

using System;
using Nekram.Data;
using Nekram.Models.Application;
using NUnit.Framework;

namespace Nekram.Tests.IntergrationTests {

    [TestFixture]
    public class NvContextTests {

        private NvContext _context;

        [SetUp]
        public void SetUp() {
            _context = new NvContext();
        }

        [Test]
        public void CanAddBranch_WithContextManager_Returns_True() {

            var company = new Branch {
                LegalName = "Senk Associates",
                Alias = "Senk Ass",
                Address = "309 Helm Street",
                City = "Small Ville",
                Country = "Avelone",
                PostalAddress = "5556-789",
                Email = "admin.yourcomapny@mail.co.org",
                Telephone = "(256)445786908",
                Mobil = "(256)770555555",
                Logo = "",
                Modified = DateTime.Now,
                Created = DateTime.Now,
                Website = "www.youcompanyweb.co.org",
            };

            _context.Branches.Add(company);
            _context.SaveChanges();
        }
    }
}
