using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.ProcessModel;
using Microsoft.AspNet.Identity;

namespace Core.Entities.User
{

   

    partial class User :IProcessFlowUser
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