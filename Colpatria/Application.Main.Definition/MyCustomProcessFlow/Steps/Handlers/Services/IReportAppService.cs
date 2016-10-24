using System;
using System.IO;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IReportAppService
    {
        MemoryStream GetReportTransactional(DateTime startdate, DateTime enddate);
    }
}