﻿using System.Web.Mvc;

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

        public ActionResult TermsAndConditions()
        {
            return View();
        }
        public ActionResult Validacion()
        {
            return View();
        }
        public ActionResult FormAsks()
        {
            return View();
        }
        public ActionResult RequestAproved()
        {
            return View();
        }
        public ActionResult FinalSummary()
        {
            return View();
        }

        public ActionResult EmailRequest()
        {
            return View();
        }
    }
}