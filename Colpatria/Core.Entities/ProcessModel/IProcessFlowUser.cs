#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IProcessFlowUser.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 12:17 p. m.</Date>
//   <Update> 2016-09-08 - 12:17 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Microsoft.AspNet.Identity;

#endregion

namespace Core.Entities.ProcessModel
{
    public interface IProcessFlowUser : IUser<long>
    {
        new long Id { get; set; }
    }
}