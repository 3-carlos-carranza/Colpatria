using System.Web.Mvc;
using Banlinea.Framework.Logging.Insights.Mvc;

namespace Presentation.Web.Colpatria
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AiHandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }

    }
}