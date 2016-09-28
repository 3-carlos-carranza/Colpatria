using System.Web.Mvc;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;

namespace Presentation.Web.Colpatria.Controllers
{
    public class MessagesController : BaseController
    {
        public MessagesController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager) : base(processFlowArgument, processFlowManager)
        {
        }
        [AllowAnonymous]
        public ActionResult NotFound()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Error500()
        {
            return View();
        }
    }
}