using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
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
        public async Task<ActionResult> Register(UserViewModel formCollection)
        {
            var user = await _userAppService.FindAsync(formCollection.Email, formCollection.Identification.ToString());
            var usercreated = new IdentityResult();
            if (user == null)
            {
                //usercreated = await _userAppService.CreateAsync(user, user.Identification);
            }
            else
            {
                user.IsNewUser = false;
            }


            
            

            return View("Index");
        }

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