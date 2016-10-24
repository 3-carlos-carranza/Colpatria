using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Presentation.Web.Colpatria.Properties;
using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportAppService _reportAppService;

        public ReportController(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LogOut()
        {
            Session["login"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginReportModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = ConfigurationManager.AppSettings.Get("ReportUser");
            var password = ConfigurationManager.AppSettings.Get("ReportPassword");
            if (model.UserName == user && model.Password == password)
            {
                Session["login"] = true;
                return RedirectToAction("Download");
            }
            ModelState.AddModelError("", Resources.InvalidPassword);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Download()
        {
            var session = Session["login"];
            if (session == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Download(DownloadReportModel model)
        {
            var session = Session["login"];
            if (session == null)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", $"attachment; filename=Report {model.StartDate.ToShortDateString()} to {model.EndDate.ToShortDateString()} of {DateTime.Now.ToShortDateString()}.xls");
                    Response.Clear();
                    var result = _reportAppService.GetReportTransactional(model.StartDate, model.EndDate);
                    Response.BinaryWrite(result.GetBuffer());
                    Response.End();
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError("", exception.InnerException?.Message ?? exception.Message);
                }
            }
            return View(model);
        }
    }

    public class LoginReportModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class DownloadReportModel
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}