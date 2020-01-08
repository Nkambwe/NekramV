
using System;
using System.Collections.Generic;
using Nekram.Models.Application;
using Nekram.Models.Collections;
using NUnit.Framework;

namespace Nekram.Tests.CollectionsTests {

    [TestFixture]
    public class NvCollectionTest {

        private NvCollection<int> _collection;

        [SetUp]
        public void SetUp() {
            _collection = new NumericCollection(new List<int>{1,2,3,4});
        }

        [Test]
        public void NewCollection_CanAddValues_Return_True()
        {
            var result = _collection.Count;
            Assert.AreEqual(4, result);
        }

        [Test]
        public void NewCollection_AddsValuesFromAnotherCollection_Return_True() {
            var collection1 = new NumericCollection(new List<int> { 1, 2, 3 });
            var collection2 = new NumericCollection(collection1);
            var result = collection2.Count;
            Assert.AreEqual(3, result);
        }

        [Test]
        public void NewCollection_CanAddRangeOfValues_Return_True() {
            var collection1 = new NumericCollection(new List<int> { 1, 2, 3 });
            var collection2 = new NumericCollection();
            collection2.AddRange(collection1);
            var result = collection2.Count;
            Assert.AreEqual(3, result);
        }

        [Test]
        public void NewCollection_SortCollectionWithSpecifiedComparer_SortsCorrectly_Return_True() {

            var branches = new Branches {
                new Branch {LegalName = "First Branch", Address = "123 Park Avenue", PostalAddress = "555", Telephone = "039 777"},
                new Branch {LegalName = "Second Branch", Address = "456 Heavens Gate", PostalAddress = "520", Telephone = "045 888"},
                new Branch {LegalName = "Third Branch", Address = "789 Calvil Street", PostalAddress = "390", Telephone = "039 333"},
                new Branch {LegalName = "Fourth Branch", Address = "101 Murpple", PostalAddress = "482", Telephone = "045 554"}
            };

            branches.Sort(new BranchComparer());

            Assert.AreEqual("First Branch", branches[0].LegalName);
            Assert.AreEqual("Fourth Branch", branches[1].LegalName);
            Assert.AreEqual("Second Branch", branches[2].LegalName);
            Assert.AreEqual("Third Branch", branches[3].LegalName);
        }

    }

    internal class NumericCollection :NvCollection<int> {
        public NumericCollection() { }

        public NumericCollection(IList<int> initialList)
            : base(initialList) { }

        public NumericCollection(NvCollection<int> collection)
            : base(collection) { }

    }

    public class BranchComparer : IComparer<Branch> {

        public int Compare(Branch branch, Branch otherBranch) {
            if (branch == null && otherBranch == null ||
                (branch == null || otherBranch == null))
                return 0;

            return string.Compare(branch.LegalName, otherBranch.LegalName, StringComparison.CurrentCultureIgnoreCase);
        }

    }

}
