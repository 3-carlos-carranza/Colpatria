using System.Web;
using System.Web.Mvc;

namespace Crosscutting.Common.Tools.Web
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            if (HttpContext.Current.Session["Product"] == null)
            {
                filterContext.Result = new RedirectResult("~/Request/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}