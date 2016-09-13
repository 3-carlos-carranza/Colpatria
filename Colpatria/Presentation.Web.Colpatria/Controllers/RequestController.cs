#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=RequestController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 2:34 p. m.</Date>
//   <Update> 2016-09-08 - 2:37 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.Tools.Web;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IUserAppService _userAppService;
        private readonly IEvidenteAppService _evidenteAppService;

        public RequestController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager,
            IUserAppService userAppService, IEvidenteAppService evidenteAppService) : base(processFlowArgument, processFlowManager)
        {
            _userAppService = userAppService;
            _evidenteAppService = evidenteAppService;
        }


        public ActionResult Register()
        {
            return View("Index");
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
            if (!usercreated.Succeeded && usercreated.Errors.Any()) return View("Index");
            var identity =
                await _userAppService.CreateIdentityAsync(nuser, DefaultAuthenticationTypes.ApplicationCookie);
            identity.Label = nuser.FullName;
            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;
            InitSetFormArguments(fields);

            var pages = _userAppService.GetAllPagesWithSections();
            ViewBag.Pages = pages;
            ViewBag.FullName = identity.Label;
            
            
            IProcessFlowResponse stepresult = await ExecuteFlow(identity, pages);
            identity.AddClaim(new Claim("RequestId", stepresult.Execution.Id.ToString()));
            identity.AddClaim(new Claim("ProductId", stepresult.Execution.ProductId.ToString()));
            identity.AddClaim(new Claim("FullName", identity.Label));
            identity.AddClaim(new Claim("Pages", JsonConvert.SerializeObject(pages)));
            return ValidateStepResult(stepresult);
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

        public ActionResult Validation()
        {
            var model = _evidenteAppService.GetQuestions(new QuestionsSettings());
            return View(model);
        }

        public ActionResult FormQuestions()
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

        public ActionResult Index2()
        {
            return View();
        }
    }
}