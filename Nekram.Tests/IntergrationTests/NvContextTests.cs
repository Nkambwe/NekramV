

using System;
using System.Linq;
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
        public void NvContext_AddBranch() {

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
                IsMain = true,
                IsParent = true,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                Website = "www.youcompanyweb.co.org",
            };

            _context.Branches.Add(company);
            _context.SaveChanges();
        }

        [Test]
        public void NvContext_ExecuteQuery_Returns_True() {

            var parent = _context.Branches.Single(b => b.Alias.Equals("Senk Ass"));

            if (parent != null) {
                var company = new Branch {
                    LegalName = "Beta IT Consult",
                    Alias = "Beta",
                    Address = "104 Amadinda House",
                    City = "Kampala",
                    Country = "Uganda",
                    PostalAddress = "P.O.BOX 222789",
                    Email = "admin.betait@mail.co.org",
                    Telephone = "0390578690338",
                    Mobil = "(256)77045751",
                    Logo = "",
                    IsMain = false,
                    IsParent = false,
                    ParentId = 1,
                    Modified = DateTime.Now,
                    Created = DateTime.Now,
                    Website = "www.betaitconsult.co.ug",
                };

                parent.Branches.Add(company);

                _context.Branches.Add(company);
                _context.SaveChanges();
            }
            
            var result = _context.Branches.Single(b => b.Alias.Equals("Beta"));
            Assert.IsNotNull(result);
        }
    }
}
