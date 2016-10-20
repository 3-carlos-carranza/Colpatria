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
                    string filename = "File.pdf";
                    string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Path/To/File/" + filename;
                    byte[] filedata = System.IO.File.ReadAllBytes(filepath);
                    string contentType = MimeMapping.GetMimeMapping(filepath);

                    var cd = new System.Net.Mime.ContentDisposition
                    {
                        FileName = $"Base {model.StartDate} - {model.EndDate} .xls",
                        Inline = true,
                    };

                    Response.AppendHeader("Content-Disposition", cd.ToString());

                    return File(filedata, contentType);
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