//   -----------------------------------------------------------------------
//   <copyright file=User.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

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