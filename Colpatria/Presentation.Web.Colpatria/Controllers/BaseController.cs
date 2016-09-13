#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=BaseController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 6:12 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Core.Entities.Process;
using Core.Entities.User;
using Crosscutting.Common.JSON;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Presentation.Web.Colpatria.Models;

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

        public long ProductId
        {
            get
            {
                //Get the current claims principal
                var identity = (ClaimsPrincipal) Thread.CurrentPrincipal;
                var data = identity.Claims.FirstOrDefault(c => c.Type == "ProductId")?.Value;
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

        public async Task<IProcessFlowResponse> ExecuteFlow(ClaimsIdentity identity = null,
            IEnumerable<Page> pages = null)
        {
            return await ProcessFlowManager.StartFlow(ProcessFlowArgument, null);
        }

        public void InitSetFormArguments(List<FieldValueOrder> form)
        {
            ProcessFlowArgument.IsSubmitting = true;
            var userId = long.Parse(User.Identity.GetUserId());
            ProcessFlowArgument = new ProcessFlowArgument
            {
                User = new User
                {
                    Id = userId
                },
                Execution = new Execution
                {
                    ProductId = 1,
                    Id = ExecutionId
                }
            };
        }


        protected ActionResult ValidateStepResult(IProcessFlowResponse stepresult)
        {
            if (!(stepresult is IShowScreenResponse))
            {
                return Json(new JsonResponse {Status = true, Message = "Paso no Devuelve una interfaz"});
            }
            var result = stepresult as IShowScreenResponse;
            switch (result.InterfaceTypeResponse)
            {
                case InterfaceTypeResponse.ShowForm:
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
                case InterfaceTypeResponse.ShowModal:
                    var json = new JsonResponse {Status = true};
                    json.SetModalWithPartial(ModalType.Kendo, Url.Action(result.Action, "Modals"));
                    TempData["Jsonresponse"] = json;
                    return RedirectToAction("Index", "Home");
                case InterfaceTypeResponse.Redirect:
                    var url =
                        Pages.Select(s => s.Section.FirstOrDefault(sc => sc.Id == stepresult.Execution.CurrentSectionId))
                            .FirstOrDefault()?.Name.Replace(" ", "-");
                    return Redirect("~/Formularios/" + url);
                default:
                    return Json(new JsonResponse {Status = false, Message = "interfaz deconocida"});
            }


            return null;
        }
    }
}