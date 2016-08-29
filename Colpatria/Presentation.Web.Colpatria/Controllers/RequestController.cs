using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Controllers
{
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(FormCollection collection)
        {
            return View();
        }
    }
}