#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=HomeController.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 12:25 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Web.Mvc;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using AutoMapper;
using Core.DataTransferObject.Vib;
using Core.Entities.Logging;

#endregion

namespace Presentation.Web.Colpatria.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILoggingAppService _loggingAppService;

        public HomeController(IProcessFlowArgument processFlowArgument, IProcessFlowManager processFlowManager,
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