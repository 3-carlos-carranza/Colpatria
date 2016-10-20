using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Presentation.Web.Colpatria.Properties;

namespace Presentation.Web.Colpatria.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
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
            ModelState.AddModelError("",Resources.InvalidPassword);
            return View(model);
        }
        [HttpGet]
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
        public ActionResult Download(DownloadReportModel model)
        {
            var session = Session["login"];
            if (session == null)
            {
                return RedirectToAction("Login");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string filename = "File.pdf";
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Path/To/File/" + filename;
            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName =$"Base {model.StartDate} - {model.EndDate} .xls",
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
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