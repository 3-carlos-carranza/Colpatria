using System;
using System.Web.Mvc;
using Banlinea.Framework.Logging.Insights.Mvc;
using Presentation.Web.Colpatria.Filters;

namespace Presentation.Web.Colpatria
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters == null) throw new ArgumentNullException(nameof(filters));
            filters.Add(new AiHandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new SessionExpireAttribute());
        }

    }
}