//   -----------------------------------------------------------------------
//   <copyright file=RequestController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common;
using Crosscutting.Common.Tools.DataType;
using Crosscutting.Common.Tools.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Presentation.Web.Colpatria.Enumerations;
using Presentation.Web.Colpatria.Models;

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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string productType)
        {
            if (!(productType == ProductType.Ca.GetMappingToItemListValue().ToString() || 
                productType == ProductType.Tc.GetMappingToItemListValue().ToString()))
            {
                return View("NotFound", new ErrorViewModel());
            }
            
            Session["ProductType"] = Convert.ToInt32(productType);
            return View("Register");
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
            ProcessFlowArgument.Execution = new Execution {Id = ExecutionId, ProductId = ProductId};

            dynamic stepresult = ExecuteFlow();
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
    }
}