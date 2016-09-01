using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Controllers
{
    public class RequestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(string check = "false")
        {
            
            ViewBag.Checked = Convert.ToBoolean(check);
            return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        public ActionResult Validacion()
        {
            return View();
        }
    }
}