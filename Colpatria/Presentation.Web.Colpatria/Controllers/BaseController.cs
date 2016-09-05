using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Core.Entities.SQL.Process;

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

        public async Task<dynamic> ExecuteFlow(ClaimsIdentity identity = null, IEnumerable<Page> pages = null)
        {
            return null;
        }
    }
}