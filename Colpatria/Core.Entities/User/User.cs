namespace Core.Entities.User
{
    using System;
    using System.Collections.Generic;

    public partial class User
    {
        public int AccessFailedCount { get; set; }

        public virtual ICollection<BaseFieldValue> BaseFieldValue { get; } = new HashSet<BaseFieldValue>();

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfExpedition { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public override long Id { get; set; }
        public string Identification { get; set; }
        public int? IdentificationType { get; set; }
        public string LastName { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public string MiddleName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecondLastName { get; set; }
        public string SecurityStamp { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UserRole> UserRole { get; } = new HashSet<UserRole>();
    }
}