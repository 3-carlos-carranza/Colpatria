#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=AllowedUrlConstraint.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-12  - 5:39 p. m.</Date>
//   <Update> 2016-09-12 - 5:39 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Routing;
using Core.Entities.Process;
using Newtonsoft.Json;

#endregion

namespace Presentation.Web.Colpatria
{
    public class AllowedUrlConstraint : IRouteConstraint
    {
        public IEnumerable<Page> Pages
        {
            get
            {
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                var data = identity.Claims.Where(c => c.Type == "Pages").Select(c => c.Value).FirstOrDefault();
                return !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<List<Page>>(data) : null;
            }
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var urlList = new List<string>();

            foreach (var page in Pages)
            {
                urlList.AddRange(page.Section.Select(s => s.Name.Replace(" ", "-")));
            }
            urlList = urlList.Distinct().ToList();

            return urlList.Any(url => url == (string) values["RequestStep"]);
        }
    }
}