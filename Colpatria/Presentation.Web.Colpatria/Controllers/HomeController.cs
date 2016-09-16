//   -----------------------------------------------------------------------
//   <copyright file=HomeController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using AutoMapper;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Core.DataTransferObject.Vib;
using Core.Entities.Logging;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILoggingAppService _loggingAppService;

        public HomeController(IProcessFlowArgument processFlowArgument,
            IProcessFlowManager processFlowManager,
            ILoggingAppService loggingAppService) : base(processFlowArgument, processFlowManager)
        {
            _loggingAppService = loggingAppService;
        }


        public ActionResult Index()
        {
            var colpatriaLogs = _loggingAppService.GetAllColpatriaLogs();
            var resultMapper = Mapper.Map<IEnumerable<ColpatriaLog>, IEnumerable<ColpatriaLogDto>>(colpatriaLogs);
            return View(resultMapper);
        }
    }
}