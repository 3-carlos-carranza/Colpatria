using Presentation.Web.Colpatria.Extensions;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Filters
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var ctx = HttpContext.Current;
            var hasAllowAnonimouseAttribute = filterContext.ActionDescriptor.HasAllowAnonimouseAttribute();
            if (!hasAllowAnonimouseAttribute && HttpContext.Current.Session["Product"] == null)
            {
                filterContext.Result = new RedirectResult("~/Messages/SessionExpired");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}