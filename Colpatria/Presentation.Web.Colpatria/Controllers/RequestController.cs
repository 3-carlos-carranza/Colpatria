using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Core.Entities.Enumerations;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.Extensions;
using Crosscutting.Common.Tools.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Presentation.Web.Colpatria.Models;
using Newtonsoft.Json;
using static System.String;

namespace Presentation.Web.Colpatria.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly ICustomActionAppService _customActionAppService;

        public RequestController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager,
            IUserAppService userAppService, ICustomActionAppService customActionAppService) : base(processFlowArgument, processFlowManager)
        {
            _userAppService = userAppService;
            _customActionAppService = customActionAppService;
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
        public ActionResult ValidateProduct(string productType = "")
        {
            if (IsNullOrEmpty(productType))
                return RedirectToAction("ShowInformation", "Messages", new {code = "0"});
            if (
                !((productType ==
                   ProductType.SavingAccount.GetMappingToItemListValue().ToString(CultureInfo.CurrentCulture)) ||
                  (productType ==
                   ProductType.CreditCard.GetMappingToItemListValue().ToString(CultureInfo.CurrentCulture))))
                return RedirectToAction("ShowInformation", "Messages", new {code = "-1"});
            var productId = (ProductType) Convert.ToInt32(productType, CultureInfo.CurrentCulture);
            Session["Product"] = productId;
            return View("Register", new UserViewModel
            {
                ProductId = (int) productId
            });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ReturnRequest(string identification, string simpleId, int productId, int sectionId)
        {
            var user = await _userAppService.FindAsync(identification, identification);
            //var info = _userAppService.GetUserInfoByUserId(user.Id); Get Page
            var identity =
                await _userAppService.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            identity.Label = user.FullName;
            GetAuthenticationManager().SignIn(identity);
            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;

            //set arguments
            var userId = long.Parse(User.Identity.GetUserId(), CultureInfo.InvariantCulture);

            ProcessFlowArgument.User = new User
            {
                Id = userId
            };
            ProcessFlowArgument.Execution = new Execution
            {                
                ProductId = productId,
                Id = ExecutionId, 
            };
            var allPagesWithSections = _userAppService.GetAllPagesWithSections();

            ViewBag.Pages = allPagesWithSections;
            ViewBag.FullName = identity.Label;

            identity.AddClaim(new Claim("ExecutionId", ExecutionId.ToString()));
            identity.AddClaim(new Claim("ProductId", ProductId.ToString()));
            identity.AddClaim(new Claim("FullName", identity.Label));
            identity.AddClaim(new Claim("Pages", JsonConvert.SerializeObject(allPagesWithSections)));

            var url =
                allPagesWithSections.FirstOrDefault(p => p.Id == 3)?
                    .Section.FirstOrDefault(s => s.Id == sectionId)?
                    .Name.Replace(" ", "-");
            ProcessFlowArgument.IsSubmitting = false;

            return Redirect("~/Formularios/" + url);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(FormCollection collection)
        {
            var fields = collection.RemoveUnnecessaryAndEmptyFields().ToFieldValueOrder().RemoveEmptyFields();
            var product = fields.FirstOrDefault(s => s.KeyInt == 12);
            if (product == null)
            {
                return RedirectToAction("ShowInformation", "Messages", new {code = "-1"}); //product not found 
            }
            int productid = 0;
            if (!int.TryParse(product.Value, out productid))
            {
                return RedirectToAction("ShowInformation", "Messages", new { code = "0" }); //invalid product
            }



            var nuser = await _userAppService.GetUserByMappingField(GlobalVariables.FieldToCreateUser, fields);
            var user = await _userAppService.FindAsync(nuser.Identification, nuser.Identification);

            if (user == null)
            {
                nuser.IsNewUser = true;
            }
            else
            {
                nuser = user;
                nuser.IsNewUser = false;
                var currentSectionId =
                    _userAppService.GetValidExecutionByUserAndProduct(user.Id, (int) Session["Product"]);

                if (currentSectionId != 0)
                    return View("ContinueRequest", new UserViewModel { 
                        FirstName = "Wilmar",
                        ProductId = Convert.ToInt32((int) Session["Product"]),
                        CurrentSectionId = currentSectionId
                    });
            }

            var usercreated = new IdentityResult();
            if (nuser.IsNewUser)
                usercreated = await _userAppService.CreateAsync(nuser, nuser.Identification);
            if (!usercreated.Succeeded && usercreated.Errors.Any())
            {
                return View("Register");
            }
            var identity =
                await _userAppService.CreateIdentityAsync(nuser, DefaultAuthenticationTypes.ApplicationCookie);
            identity.Label = nuser.FullName;
            GetAuthenticationManager().SignIn(identity);
            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;

            #region

            BaseProductType = productid;

            #endregion

            InitSetFormArguments(fields);

            var pages = _userAppService.GetAllPagesWithSections();
            ViewBag.Pages = pages;
            ViewBag.FullName = identity.Label;

            var stepresult = await ExecuteFlow(identity, pages);

            return ValidateStepResult(stepresult);
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            return authManager;
        }

        public async Task<ActionResult> HandleRequest()
        {
            var userId = long.Parse(User.Identity.GetUserId());
            ProcessFlowArgument.User = new User {Id = userId};
            ProcessFlowArgument.IsSubmitting = false;
            ProcessFlowArgument.Execution = new Execution {Id = ExecutionId, ProductId = ProductId};
            dynamic stepresult = await Task.Factory.StartNew(() => ExecuteFlow()).ConfigureAwait(false);
            return stepresult;
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        public async Task<ActionResult> RequestAproved()
        {
            MockSubmitInitSetFormArguments();

            dynamic stepresult = await ExecuteFlow();
            return ValidateStepResult(stepresult);
        }

        public async Task<ActionResult> FinalSummary()
        {
            MockSubmitInitSetFormArguments();

            dynamic stepresult = await ExecuteFlow();
            return ValidateStepResult(stepresult);
        }

        public ActionResult EmailRequest()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ValidateAnswer(AnswerRequest answer)
        {
            InitSetAnswersArguments(answer);
            var stepresult = await ExecuteFlow();
            return ValidateStepResult(stepresult);
        }

        [HttpPost]
        public async Task<ActionResult> SaveAdditionalInformation(FormCollection collection)
        {
            var fields = collection.ToFieldValueOrder();
            InitSetFormArguments(fields);

            var stepresult = await ExecuteFlow();
            return ValidateStepResult(stepresult);
        }

        public ActionResult ErrorEvidente()
        {
            return View();
        }
    }
}