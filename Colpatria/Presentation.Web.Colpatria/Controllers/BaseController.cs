#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=BaseController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 2:34 p. m.</Date>
//   <Update> 2016-09-08 - 2:44 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    public class BaseController : Controller
    {
        public readonly IProcessFlowManager ProcessFlowManager;
        public IProcessFlowArgument ProcessFlowArgument;

        public BaseController(IProcessFlowArgument processFlowArgument,
            IProcessFlowManager processFlowManager)
        {
            ProcessFlowArgument = processFlowArgument;
            ProcessFlowManager = processFlowManager;
        }

        public long ExecutionId
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                var data = identity.Claims.FirstOrDefault(c => c.Type == "ExecutionId")?.Value;
                return !string.IsNullOrEmpty(data) ? long.Parse(data) : 0;
            }
        }

        public IEnumerable<Page> Pages
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
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
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                var data = identity.Claims.Where(c => c.Type == "FullName").Select(c => c.Value).FirstOrDefault();
                return data;
            }
        }

        public string Code
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                var data = identity.Claims.Where(c => c.Type == "Code").Select(c => c.Value).FirstOrDefault();
                return data;
            }
        }

        public async Task<dynamic> ExecuteFlow(ClaimsIdentity identity = null, IEnumerable<Page> pages = null)
        {
            dynamic stepresult = await ProcessFlowManager.StartFlow(ProcessFlowArgument, null);
            return stepresult;
        }

        public void InitSetFormArguments(List<FieldValueOrder> form, bool ismanualrequest = false)
        {
            ProcessFlowArgument.IsSubmitting = true;
            var userId = long.Parse(User.Identity.GetUserId());
            ProcessFlowArgument = new ProcessFlowArgument
            {
                User = new User
                {
                    Id = userId
                }
            };
            if (ExecutionId != 0)
            {
                ProcessFlowArgument.Execution = new Execution
                {
                    Id = ExecutionId,
                    UserId = userId
                };
            }
        }
    }
}