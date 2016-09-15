using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.Tools.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(FormCollection collection)
        {
            var fields = collection.RemoveUnnecessaryAndEmptyFields().ToFieldValueOrder().RemoveEmptyFields();

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
            }

            var usercreated = new IdentityResult();
            if (nuser.IsNewUser)
            {
                usercreated = await _userAppService.CreateAsync(nuser, nuser.Identification);
            }
            if (!usercreated.Succeeded && usercreated.Errors.Any()) return View("Register");
            var identity =
                await _userAppService.CreateIdentityAsync(nuser, DefaultAuthenticationTypes.ApplicationCookie);
            identity.Label = nuser.FullName;
            GetAuthenticationManager().SignIn(identity);
            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;
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
            ProcessFlowArgument.Execution = new Execution {Id   =  ExecutionId,ProductId = ProductId };
            
            dynamic stepresult = await ExecuteFlow();
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
        public ActionResult FinalSummary()
        {
            return View();
        }
        public ActionResult EmailRequest()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ValidateAnswer(FormCollection collection)
        {
            var fields = collection.ToFieldValueOrder();
            InitSetFormArguments(fields);

            var stepresult = await ExecuteFlow();
            return ValidateStepResult(stepresult);
        }
    }
}