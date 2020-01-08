using System;
using System.Data.Entity;
using Nekram.Models.Application;

namespace Nekram.Data {

    public class DropCreateWhenChanged
        : DropCreateDatabaseIfModelChanges<NvContext> {

        /// <summary>
        /// Creates a required system data
        /// </summary>
        /// <param name="context">The context to which the new seed data is added.</param>
        protected override void Seed(NvContext context) {

            //default company
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

            context.Branches.Add(company);
            context.SaveChanges();

        }
    }

}
