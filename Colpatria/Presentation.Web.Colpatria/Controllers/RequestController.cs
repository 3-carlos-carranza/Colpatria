using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Core.Entities.Enumerations;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Crosscutting.Common.Extensions;
using Crosscutting.Common.Tools.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Presentation.Web.Colpatria.Models;
using Presentation.Web.Colpatria.Properties;
using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.String;

namespace Presentation.Web.Colpatria.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IUserAppService _userAppService;

        public RequestController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager,
            IUserAppService userAppService) : base(processFlowArgument, processFlowManager)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ContinueRequest(ModelLogin modelLogin)
        {
            if (!ModelState.IsValid) return View(modelLogin);
            var user = await _userAppService.FindAsync(modelLogin.Identification, modelLogin.DocumentType, modelLogin.Identification + ConfigurationManager.AppSettings["Salt"]);
            if (user != null)
            {
                //var info = _userAppService.GetUserInfoByUserId(user.Id); Get Page
                var identity =
                    await _userAppService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                identity.Label = user.FullName;
                GetAuthenticationManager().SignIn(identity);
                var principal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = principal;
                HttpContext.User = principal;
                //set arguments
                long.Parse(User.Identity.GetUserId(), CultureInfo.InvariantCulture);

                ProcessFlowArgument.User = user;

                var response = _userAppService.GetRequestBySimpleId(modelLogin.SimpleId);
                Session["Product"] = (ProductType)response.ProductId;

                ProcessFlowArgument.Execution = new Execution
                {
                    Id = response.Id,
                    ProductId = response.ProductId
                };

                var pages = _userAppService.GetAllPagesWithSections();
                ViewBag.Pages = pages;
                ViewBag.FullName = identity.Label;

                var stepresult = await ExecuteFlowAsync(identity, pages);

                return ValidateStepResult(stepresult);
            }
            ModelState.AddModelError("", Resources.RequestController_ContinueRequest_No_Active_Request);
            return View(modelLogin);
        }

        public ActionResult EmailRequest()
        {
            return View();
        }

        public ActionResult ErrorEvidente()
        {
            return View();
        }

        public async Task<ActionResult> FinalSummary()
        {
            dynamic stepresult = await ExecuteFlowAsync();
            return ValidateStepResult(stepresult);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (bool.Parse(ConfigurationManager.AppSettings.Get("IsDevelop")))
            {
                return View();
            }
            return Redirect(ConfigurationManager.AppSettings.Get("SiteToRedirect"));
        }

        [AllowAnonymous]
        public ActionResult InternalLogin()
        {
            return View("ContinueRequest");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(FormCollection collection)
        {
            var fields = collection.RemoveUnnecessaryAndEmptyFields().ToFieldValueOrder().RemoveEmptyFields();
            var product = fields.FirstOrDefault(s => s.KeyInt == 12);
            if (product == null)
            {
                return RedirectToAction("ShowInformation", "Messages", new { code = "-1" }); //product not found
            }
            int productid;
            if (!int.TryParse(product.Value, out productid))
            {
                return RedirectToAction("ShowInformation", "Messages", new { code = "0" }); //invalid product
            }

            var nuser = await _userAppService.GetUserByMappingField(GlobalVariables.FieldToCreateUser, fields);

            if (!nuser.IdentificationType.HasValue)
            {
                return RedirectToAction("ShowInformation", "Messages", new { code = "100" }); //invalid Document type
            }

            var user = await _userAppService.FindAsync(nuser.Identification, nuser.IdentificationType.Value, nuser.Identification + ConfigurationManager.AppSettings["Salt"]);

            //re-take Request
            if (user != null)
            {
                nuser = user;
                nuser.IsNewUser = false;
                var response =
                    _userAppService.GetValidExecutionByUserAndProduct(user.Id, (int)Session["Product"]);

                if (response != 0)
                {
                    return View("ContinueRequest");
                }
            }

            //new user and new request
            nuser.IsNewUser = true;
            if (nuser.IsNewUser)
            {
                var usercreated = await
                    _userAppService.CreateAsync(nuser,
                        nuser.Identification + ConfigurationManager.AppSettings["Salt"]);
                if (!usercreated.Succeeded && usercreated.Errors.Any())
                {
                    return View("Register");
                }
                //error creating user
                if (!usercreated.Succeeded | usercreated.Errors.Any())
                {
                    foreach (var error in usercreated.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                    var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    var message = Join(", ", allErrors.Select(s => s.ErrorMessage).ToArray());
                    TempData["Message"] = message;
                    return View("Register", new UserViewModel
                    {
                        ProductId = Convert.ToInt32((int)Session["Product"])
                    });
                }
            }
            var identity =
                await _userAppService.CreateIdentityAsync(nuser, DefaultAuthenticationTypes.ApplicationCookie);
            identity.Label = nuser.FullName;
            GetAuthenticationManager().SignIn(identity);
            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;
            BaseProductType = productid;
            BaseProductType = productid;

            InitSetFormArguments(fields);
            var pages = _userAppService.GetAllPagesWithSections();
            ViewBag.Pages = pages;
            ViewBag.FullName = identity.Label;

            var stepresult = await ExecuteFlowAsync(identity, pages);

            return ValidateStepResult(stepresult);
        }

        public async Task<ActionResult> RequestAproved()
        {
            dynamic stepresult = await ExecuteFlowAsync();
            return ValidateStepResult(stepresult);
        }

        [HttpPost]
        public async Task<ActionResult> SaveAdditionalInformation(FormCollection collection)
        {
            var fields = collection.ToFieldValueOrder();
            InitSetFormArguments(fields);

            var stepresult = await ExecuteFlowAsync();
            return ValidateStepResult(stepresult);
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ValidateAnswer(AnswerRequest answer)
        {
            InitSetAnswersArguments(answer);
            var stepresult = await ExecuteFlowAsync();
            return ValidateStepResult(stepresult);
        }

        [AllowAnonymous]
        public ActionResult ValidateProduct(string productType = "")
        {
            if (IsNullOrEmpty(productType))
            {
                return RedirectToAction("ShowInformation", "Messages", new { code = "0" });
            }
            if (
                !((productType ==
                   ProductType.SavingAccount.GetMappingToItemListValue().ToString(CultureInfo.CurrentCulture)) ||
                  (productType ==
                   ProductType.CreditCard.GetMappingToItemListValue().ToString(CultureInfo.CurrentCulture))))
            {
                return RedirectToAction("ShowInformation", "Messages", new { code = "-1" });
            }
            var productId = (ProductType)Convert.ToInt32(productType, CultureInfo.CurrentCulture);
            Session["Product"] = productId;
            return View("Register", new UserViewModel
            {
                ProductId = (int)productId
            });
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            return authManager;
        }
    }
}