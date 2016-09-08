using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Core.DataTransferObject.SQL;
using Core.Entities.SQL.Process;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace Presentation.Web.Colpatria.Controllers
{
    public class BaseController : Controller
    {
        public IProcessFlowArgument ProcessFlowArgument;
        public IProcessFlowService ProcessFlowService;
        public ISubmitFormArgument SubmitFormArgument;

        public BaseController(IProcessFlowArgument processFlowArgument,
            IProcessFlowService processFlowService,
            ISubmitFormArgument submitFormArgument)
        {
            ProcessFlowArgument = processFlowArgument;
            ProcessFlowService = processFlowService;
            SubmitFormArgument = submitFormArgument;
        }

        public long ExecutionId
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var data = identity.Claims.FirstOrDefault(c => c.Type == "ExecutionId")?.Value;
                return !string.IsNullOrEmpty(data) ? long.Parse(data) : 0;
            }
        }

        public IEnumerable<Page> Pages
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var data = identity.Claims.Where(c => c.Type == "Pages").Select(c => c.Value).FirstOrDefault();
                if (!string.IsNullOrEmpty(data))
                {
                    return JsonConvert.DeserializeObject<List<Page>>(data);
                }
                return null;
            }
        }

        public string FullName
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var data = identity.Claims.Where(c => c.Type == "FullName").Select(c => c.Value).FirstOrDefault();
                return data;
            }
        }
        public string Code
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var data = identity.Claims.Where(c => c.Type == "Code").Select(c => c.Value).FirstOrDefault();
                return data;
            }
        }

        public async Task<dynamic> ExecuteFlow(ClaimsIdentity identity = null, IEnumerable<Page> pages = null)
        {
            dynamic stepresult = await ProcessFlowService.RunFlow(ProcessFlowArgument);

            return stepresult;
        }

        public void InitSetFormArguments(List<FieldValueOrder> form, bool ismanualrequest = false)
        {
            ProcessFlowArgument.IsSubmitting = true;
            var userId = long.Parse(User.Identity.GetUserId());
            ProcessFlowArgument.ExecutionArgument = new ExecutionArgument
            {
                IsPost = false,
                UserId = userId,
                UserName = User.Identity.GetUserName(),
                ProductId = 1
            };
            ProcessFlowArgument.StepArgument =
                (StepArgument)SubmitFormArgument.Make(form, User.Identity.GetUserName(), 1);
            if (ExecutionId != 0)
            {
                ProcessFlowArgument.StepArgument.Execution = new Execution
                {
                    Id = ExecutionId,
                    UserId = userId
                };
            }
        }
    }
}