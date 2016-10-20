using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Presentation.Web.Colpatria.Models;
using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager) : base(processFlowArgument, processFlowManager)
        {
            //Default CTOR
        }

        [AllowAnonymous]
        public ActionResult Error500() => View();

        [AllowAnonymous]
        public ActionResult NotFound() => View();

        [AllowAnonymous]
        public ActionResult SessionExpired() => View();

        [AllowAnonymous]
        public ActionResult ShowInformation(string code = "")
        {
            var message = Properties.Resources.ResourceManager.GetString(code);
            var errorm = new ErrorViewModel
            {
                Message = string.IsNullOrEmpty(message) ? "No se encuentra el producto." : message
                ,
                Icon = ""
                ,
                Title = "Importante"
            };
            return View(errorm);
        }
    }
}