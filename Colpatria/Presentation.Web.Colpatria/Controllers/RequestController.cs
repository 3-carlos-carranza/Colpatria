#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=RequestController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 12:19 p. m.</Update>
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
using Application.Main.Implementation.ProcessFlow.Arguments;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;
using Crosscutting.Common.Tools.Web;
using Microsoft.AspNet.Identity;

#endregion

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

            //var submitFormStepArgument = SubmitFormArgument.Make(fields, identity.GetUserName(), 1);

            var principal = new ClaimsPrincipal(identity);
            Thread.CurrentPrincipal = principal;
            HttpContext.User = principal;

            ProcessFlowArgument.Execution= new Execution
            {
                
                UserId = long.Parse(identity.GetUserId()),
                ProductId = 1
            };
            

            var pages = _userAppService.GetAllPagesWithSections();
            ViewBag.Pages = pages;
            ViewBag.FullName = identity.Label;

            //ProcessFlowArgument.StepArgument = (StepArgument) SubmitFormArgument.Make(fields, identity.GetUserName(), 1);
            dynamic stepresult = await ExecuteFlow(identity, pages);
            return stepresult;
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        public ActionResult Validation()
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

        public ActionResult Index2()
        {
            return View();
        }
    }
}