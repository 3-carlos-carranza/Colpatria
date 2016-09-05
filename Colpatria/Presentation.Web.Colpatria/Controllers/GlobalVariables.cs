using System.Collections.Generic;
using Application.Main.Definition;
using Core.Entities.SQL.User;
using Crosscutting.DependencyInjectionFactory;

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