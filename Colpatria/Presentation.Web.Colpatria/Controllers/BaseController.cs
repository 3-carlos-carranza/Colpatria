using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.JSON;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Presentation.Web.Colpatria.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Presentation.Web.Colpatria.Controllers
{
    public class BaseController : Controller
    {
        private readonly IProcessFlowManager _processFlowManager;

        public BaseController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager)
        {
            if (processFlowArgument == null) throw new ArgumentNullException(nameof(processFlowArgument));
            if (processFlowManager == null) throw new ArgumentNullException(nameof(processFlowManager));
            ProcessFlowArgument = processFlowArgument;
            _processFlowManager = processFlowManager;
        }

        public BaseController(IProcessFlowManager processFlowManager)
        {
            if (processFlowManager == null) throw new ArgumentNullException(nameof(processFlowManager));
            _processFlowManager = processFlowManager;
        }

        public int BaseProductType { get; set; }

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

        public long ExecutionId
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var data = identity.Claims.FirstOrDefault(c => c.Type == "ExecutionId")?.Value;
                return !string.IsNullOrEmpty(data) ? long.Parse(data, CultureInfo.InvariantCulture) : 0;
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

        public IProcessFlowArgument ProcessFlowArgument { get; set; }

        public long ProductId
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
                var data = identity.Claims.FirstOrDefault(c => c.Type == "ProductId")?.Value;
                return !string.IsNullOrEmpty(data) ? long.Parse(data, CultureInfo.InvariantCulture) : 0;
            }
        }

        public async Task<IProcessFlowResponse> ExecuteFlow(ClaimsIdentity identity = null,
            IEnumerable<Page> pages = null)
        {
            IProcessFlowResponse result = await _processFlowManager.StartFlow(ProcessFlowArgument);
            if (identity != null)
            {
                identity.AddClaim(new Claim("ExecutionId", result.Execution.Id.ToString()));
                identity.AddClaim(new Claim("ProductId", result.Execution.ProductId.ToString()));
                identity.AddClaim(new Claim("FullName", identity.Label));
                if (pages != null)
                {
                    identity.AddClaim(new Claim("Pages", JsonConvert.SerializeObject(pages)));
                }
            }
            return result;
        }

        public void InitSetAnswersArguments(AnswerRequest answer)
        {
            var userId = long.Parse(User.Identity.GetUserId(), CultureInfo.InvariantCulture);

            ProcessFlowArgument.User = new User
            {
                Id = userId
            };
            ProcessFlowArgument.Execution = new Execution
            {
                ProductId = 1,
                Id = ExecutionId
            };
            ProcessFlowArgument.IsSubmitting = true;
            var arg = ProcessFlowArgument as IAnswerQuestionArgument;
            arg.AnswerRequest = answer;
            ProcessFlowArgument = arg;
        }

        public void InitSetFormArguments(IList<FieldValueOrder> form)
        {
            if (BaseProductType == 0)
            {
                BaseProductType = (int)ProductId;
            }

            var userId = long.Parse(User.Identity.GetUserId(), CultureInfo.InvariantCulture);

            ProcessFlowArgument.User = new User
            {
                Id = userId
            };
            ProcessFlowArgument.Execution = new Execution
            {
                Id = ExecutionId,
                ProductId = BaseProductType
            };
            ProcessFlowArgument.IsSubmitting = true;
            var arg = ProcessFlowArgument as ISubmitFormArgument;
            if (arg == null) return;
            ((List<FieldValueOrder>)arg.Form).AddRange(form);
            ProcessFlowArgument = arg;
        }

        protected ActionResult ValidateStepResult(IProcessFlowResponse stepresult)
        {
            if (!(stepresult is IShowScreenResponse))
            {
                return Json(new JsonResponse { Status = true, Message = "Paso no Devuelve una interfaz" });
            }
            var result = (IShowScreenResponse)stepresult;
            switch (result.ShowScreenType)
            {
                case ShowScreenType.ShowForm:
                    if (result.Action == null && result.PartialView == null)
                    {
                        var error = new ErrorViewModel
                        {
                            Message =
                                "No se pudo obtener la información necesaria para mostrar esta pantalla.",
                            Title = "Error al obtener la Pagina",
                            Icon = "remove"
                        };
                        return View("~/Views/Error/Index.cshtml", error);
                    }
                    if (result.Action != null)
                    {
                        return View(result.Action, stepresult);
                    }
                    return PartialView(result.PartialView, stepresult);

                case ShowScreenType.ShowModal:
                    var json = new JsonResponse { Status = true };
                    json.SetModalWithPartial(ModalType.Kendo, Url.Action(result.Action, "Modals"));
                    TempData["Jsonresponse"] = json;
                    return RedirectToAction("Register", "Request");

                case ShowScreenType.Redirect:
                    var url =
                        Pages.Select(s => s.Section.FirstOrDefault(sc => sc.Id == stepresult.Execution.CurrentSectionId))
                            .FirstOrDefault()?.Name.Replace(" ", "-");
                    return Redirect("~/Formularios/" + url);

                default:
                    return Json(new JsonResponse { Status = false, Message = "interfaz deconocida" });
            }
        }
    }
}