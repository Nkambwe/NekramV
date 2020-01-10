using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;

namespace Nekram.Models.Application {

    public class NvUserRole : EntityObject<int> {

        public string Role { get; set; }
        public string RoleLabel { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public bool AddUsr { get; set; }
        public bool EdtUsr { get; set; }
        public bool VieUsr { get; set; }
        public bool DelUsr { get; set; } //Usr is user
        public bool AddClt { get; set; }
        public bool EdtClt { get; set; }
        public bool VieClt { get; set; }
        public bool DelClt { get; set; } //Clt is client
        public bool AddVdr { get; set; }
        public bool EdtVdr { get; set; }
        public bool VieVdr { get; set; }
        public bool DelVdr { get; set; } //Vdr is vendor
        public bool AddPmt { get; set; }
        public bool EdtPmt { get; set; }
        public bool ViePmt { get; set; }
        public bool DelPmt { get; set; } //Pmt is payment
        public bool AddInv { get; set; }
        public bool EdtInv { get; set; }
        public bool VieInv { get; set; }
        public bool DelInv { get; set; } //Inv is invoice
        public bool AddCat { get; set; }
        public bool EdtCat { get; set; }
        public bool VieCat { get; set; }
        public bool DelCat { get; set; } //Cat is category
        public bool AddItm { get; set; }
        public bool EdtItm { get; set; }
        public bool VieItm { get; set; }
        public bool DelItm { get; set; } //Itm is item
        public bool AddOdr { get; set; }
        public bool EdtOdr { get; set; }
        public bool VieOdr { get; set; }
        public bool DelOdr { get; set; } //Odr is order 
        public bool AddStk { get; set; }
        public bool EdtStk { get; set; }
        public bool VieStk { get; set; }
        public bool AdjStk { get; set; } //Adjust stock
        public bool DelStk { get; set; }//Stk is stock
        public bool AddPrc { get; set; }
        public bool EdtPrc { get; set; }
        public bool ViePrc { get; set; }
        public bool DelPrc { get; set; } //Prc is price
        public bool AddSal { get; set; }
        public bool EdtSal { get; set; }
        public bool VieSal { get; set; }
        public bool DelSal { get; set; } //Sal is sale
        public bool AddRol { get; set; }
        public bool EdtRol { get; set; }
        public bool VieRol { get; set; }
        public bool DelRol { get; set; } //Rol is role

        public virtual ICollection<NvUser> Users { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (string.IsNullOrWhiteSpace(Role))
                yield return new ValidationResult("Provide a name for this role in upper case", new[] { "Role" });

            if (string.IsNullOrWhiteSpace(RoleLabel))
                yield return new ValidationResult("Give a designation for this role.", new[] { "RoleLabel" });

            if (Created > DateTime.Now)
                yield return new ValidationResult("Invalid creation date; must be between today and 3 years ago.", new[] { "Created" });

            if (Created > DateTime.Now)
                yield return new ValidationResult("Invalid modified date; must be between today and 3 years ago.", new[] { "Modified" });

        }
    }
}
