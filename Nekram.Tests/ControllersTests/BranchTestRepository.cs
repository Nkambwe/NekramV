using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Nekram.Models.Application;
using Nekram.Models.RepositoryInterfaces;

namespace Nekram.Tests.ControllersTests {

    public class BranchTestRepository :IBranchRepository {

        public List<Branch> Branches = new List<Branch>();

        public Branch FindById(int id, out string error) {
            error = string.Empty;
            return Branches.FirstOrDefault(b => b.Id == id);
        }

        public Branch FindById(out string error, int id, params Expression<Func<Branch, object>>[] filter) {
            return FindAll(out error, filter).FirstOrDefault(b => b.Id == id);
        }

        public IQueryable<Branch> FindAll(out string error) {
            error = string.Empty;
            return Branches.AsQueryable();
        }

        public IQueryable<Branch> FindAll(out string error, params Expression<Func<Branch, object>>[] filter) {

            error = string.Empty;

            for (var i = 0; i < 23; i++) {
                Branches.Add(new Branch {
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
                    Website = "www.youcompanyweb.co.org"
                });
            }

            Branches.Insert(11, new Branch {
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
                Website = "www.betaitconsult.co.ug"
            });

            return Branches.AsQueryable();
        }

        public IEnumerable<Branch> FindAll(out string error, Expression<Func<Branch, bool>> predicate, params Expression<Func<Branch, object>>[] filter)  {
            error = string.Empty;

            for (var i = 0; i < 23; i++) {
                Branches.Add(new Branch {
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
                    Website = "www.youcompanyweb.co.org"
                });
            }

            Branches.Insert(11, new Branch {
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
                Website = "www.betaitconsult.co.ug"
            });

            return Branches.AsQueryable();
        }

        public void Add(Branch branch, out string error) {
            error = string.Empty;

            if(branch != null)
             Branches.Add(branch);
        }

        public void Remove(Branch branch, out string error) {
            error = string.Empty;
            if (branch != null)
                Branches.Remove(branch);
        }

        public void Remove(int id, out string error) {
            var branch = FindById(id, out error);

            if (branch != null)
                Branches.Remove(branch);
        }

        public IEnumerable<Branch> FindByAlias(string alias) {
            throw new NotImplementedException();
        }
    }
}
