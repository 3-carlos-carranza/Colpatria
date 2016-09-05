using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;

namespace Core.Entities.SQL.User
{
    partial class User : IUser<long>
    {
        private bool? _isnewuser;
        public string FullName => FirstName + " " + MiddleName + " " + LastName + " " + SecondLastName;

        [NotMapped]
        public bool IsNewUser
        {
            get
            {
                if (_isnewuser != null)
                {
                    return _isnewuser.Value;
                }
                return false;
            }
            set { _isnewuser = value; }
        }
    }
}