#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=GlobalVariables.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 12:20 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.Entities.User;
using Crosscutting.DependencyInjectionFactory;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    public static class GlobalVariables
    {
        static GlobalVariables()
        {
            var userAppService = Factory.Resolver<IUserAppService>();
            FieldToCreateUser = userAppService.GetMappingFieldToCreateUsers();
        }

        public static IEnumerable<FieldToCreateUser> FieldToCreateUser { get; }
    }
}