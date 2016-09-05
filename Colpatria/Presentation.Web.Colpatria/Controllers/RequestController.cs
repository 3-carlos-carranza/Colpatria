using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Core.DataTransferObject.SQL;
using Core.Entities.SQL.User;
using Microsoft.AspNet.Identity;
using Presentation.Web.Colpatria.Models;

namespace Presentation.Web.Colpatria.Controllers
{
    public class RequestController : BaseController
    {
        private readonly IUserAppService _userAppService;

        public RequestController(IProcessFlowArgument processFlowArgument,
            IProcessFlowService processFlowService, IUserAppService userAppService) :
                base(processFlowArgument, processFlowService)
        {
            _userAppService = userAppService;
        }

        public ActionResult Register()
        {
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(UserViewModel collection)
        {
            var user = await _userAppService.FindAsync(collection.Identification, collection.Identification);
            var nuser = MappingUser(collection);

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
                usercreated = await _userAppService.CreateAsync(nuser, collection.Identification);
            }
            if (usercreated.Succeeded || !usercreated.Errors.Any())
            {
                var identity =
                await _userAppService.CreateIdentityAsync(nuser, DefaultAuthenticationTypes.ApplicationCookie);
                identity.Label = nuser.FullName;

                var principal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = principal;
                HttpContext.User = principal;

                var pages = _userAppService.GetAllPagesWithSections();
                ViewBag.Pages = pages;
                ViewBag.FullName = identity.Label;

                if (true)
                {
                    ProcessFlowArgument.ExecutionArgument = new ExecutionArgument
                    {
                        IsPost = false,
                        UserId = long.Parse(identity.GetUserId()),
                        UserName = identity.GetUserName()
                    };

                    //En desarrollo
                    dynamic stepresult = await ExecuteFlow(identity, pages);

                }

            }
            return View("Index");
        }

        public User MappingUser(UserViewModel collection) => new User()
        {
            FirstName = collection.FirstName.Split(' ')[0],
            MiddleName = collection.FirstName.Split(' ')[1],
            LastName = collection.FirstLastName,
            SecondLastName = collection.SecondLastName,
            IdentificationType = collection.IdentificationType,
            Identification = collection.Identification,
            DateOfExpedition = collection.DateOfExpedition,
            Email = collection.Email,
            PhoneNumber = collection.Telephone,
            UserName = collection.Identification
        };

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