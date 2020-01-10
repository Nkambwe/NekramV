/* Class      : BranchViewModel
 * Mapps T0   : Branch Model class
 * Description: Class represents the view of the company branch
 * Created On : Jan-10-2020
 */

using System;

namespace Nekram.App.Areas.Branches.ViewModels {
    public class BranchViewModel {
        public int Id { get; set; }
        public string LegalName { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalAddress { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mobil { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public bool IsMain { get; set; }
        public bool IsParent { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}