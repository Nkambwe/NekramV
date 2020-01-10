

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Nekram.Infrastructure;
using Nekram.Models.Audits;

namespace Nekram.Models.Application {

    public class NvUser : EntityObject<int>, IOwned<Branch> {

        public int BranchId { get; set; }

        private string _usercode;
        public string Usercode {
            get { return string.IsNullOrWhiteSpace(_usercode) ? string.Empty : _usercode; }
            set { _usercode = value; }
        }

        private string _username;
        public string Username {
            get { return string.IsNullOrWhiteSpace(_username) ? string.Empty : _username; }
            set { _username = value; }
        }

        private string _loginname;
        public string LoginName {
            get { return string.IsNullOrWhiteSpace(_loginname) ? string.Empty : _loginname; }
            set { _loginname = value; }
        }

        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }

        private string _password;

        public string Password {
            get { return string.IsNullOrWhiteSpace(_password) ? string.Empty : _password; }
            set { _password = value; }
        }

        private string _stores;
        public string StoresToAccess {
            get { return string.IsNullOrWhiteSpace(_stores) ? string.Empty : _stores; }
            set { _stores = value; }
        }

        private string _email;
        public string Email {
            get { return string.IsNullOrWhiteSpace(_email) ? string.Empty : _email; }
            set { _email = value; }
        }

        private string _question;
        public string Question {
            get { return string.IsNullOrWhiteSpace(_question) ? string.Empty : _question; }
            set { _question = value; }
        }

        private string _anwser;
        public string Answer {
            get { return string.IsNullOrWhiteSpace(_anwser) ? string.Empty : _anwser; }
            set { _anwser = value; }
        }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public int RoleId { get; set; }
        public int CompanyId { get; set; }

        public virtual NvUserRole Role { get; set; }
        public virtual List<LoginStation> Warkstations { get; set; }
        public virtual NvUserPreference Preferences { get; set; }
        public virtual Branch Owner { get; set; }
        public virtual ICollection<NvUserLog> Logs { get; set; }
        public virtual ICollection<NvLogAchieve> Achieves { get; set; }
        public virtual ICollection<NvUserSession> Sessions { get; set; }
        
        /// <summary>
        /// Validates this object. It validates dependencies between properties and also calls Validate on child collections;
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns>A IEnumerable of ValidationResult. The IEnumerable is empty when the object is in a valid state.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {

            if (string.IsNullOrWhiteSpace(Usercode))
                yield return new ValidationResult("User code is required", new[] { "Usercode" });

            if (string.IsNullOrWhiteSpace(Username))
                yield return new ValidationResult("User name is required", new[] { "Username" });

            if (string.IsNullOrWhiteSpace(LoginName))
                yield return new ValidationResult("Login name is required", new[] { "LoginName" });

            if (string.IsNullOrWhiteSpace(Password))
                yield return new ValidationResult("User password is required", new[] { "Password" });

            if (Created > DateTime.Now)
                yield return new ValidationResult("Invalid creation date; must be between today and 3 years ago.", new[] { "Created" });

            if (Created > DateTime.Now)
                yield return new ValidationResult("Invalid modified date; must be between today and 3 years ago.", new[] { "Modified" });
        }
        public override string ToString() {
            var strvalue = string.IsNullOrWhiteSpace(Usercode) ? Username : (string.IsNullOrWhiteSpace(Username) ? Usercode : $"{Usercode}-{Username}");
            return strvalue;
        }

    }
}
