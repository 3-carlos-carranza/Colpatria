using System.Collections.Generic;
using System.Web.Mvc;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using AutoMapper;
using Core.DataTransferObject.Mongo;
using Core.Entities.Mongo;

namespace Presentation.Web.Colpatria.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILoggingAppService _loggingAppService;
        private readonly IProcessFlowArgument _processFlowArgument;
        private readonly IProcessFlowService _processFlowService;

        public HomeController(ILoggingAppService loggingAppService, 
            IProcessFlowArgument processFlowArgument, 
            IProcessFlowService processFlowService,
            ISubmitFormArgument submitFormStepArgument) 
            : base(processFlowArgument, processFlowService, submitFormStepArgument)
        {
            _loggingAppService = loggingAppService;
            this._processFlowArgument = processFlowArgument;
            this._processFlowService = processFlowService;
        }

        public ActionResult Index()
        {
            var colpatriaLogs = _loggingAppService.GetAllColpatriaLogs();
            var resultMapper = Mapper.Map<IEnumerable<ColpatriaLog>, IEnumerable<ColpatriaLogDto>>(colpatriaLogs);
            return View(resultMapper);
        }
    }
}