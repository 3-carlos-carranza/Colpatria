using System.ComponentModel.DataAnnotations.Schema;
using Banlinea.ProcessFlow.Model;
using Microsoft.AspNet.Identity;

namespace Core.Entities.User
{
    public class IdentityUser : IProcessFlowUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
    }

    partial class User : IdentityUser, IUser<long>
    {
        private bool? _isnewuser;

        public string FullName => FirstName + " " + MiddleName + " " + LastName + " " + SecondLastName;

        [NotMapped]
        public bool IsNewUser
        {
            get
            {
                return _isnewuser != null && _isnewuser.Value;
            }
            set { _isnewuser = value; }
        }
    }
}