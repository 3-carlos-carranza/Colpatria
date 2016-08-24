using System.Collections.Generic;
using System.Web.Mvc;
using Application.Main.Definition;
using AutoMapper;
using Core.DataTransferObject.Mongo;
using Core.Entities.Mongo;

namespace Presentation.Web.Colpatria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoggingAppService _loggingAppService;

        public HomeController(ILoggingAppService loggingAppService)
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