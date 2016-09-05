using System.Web.Mvc;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;

namespace Presentation.Web.Colpatria.Controllers
{
    public class BaseController : Controller
    {
        public IProcessFlowArgument ProcessFlowArgument;
        public IProcessFlowService ProcessFlowService;

        public BaseController(IProcessFlowArgument processFlowArgument, IProcessFlowService processFlowService)
        {
            ProcessFlowArgument = processFlowArgument;
            ProcessFlowService = processFlowService;
        }
    }
}