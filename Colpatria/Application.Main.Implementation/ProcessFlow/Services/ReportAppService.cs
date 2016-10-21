using System;
using System.IO;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Tools.ExcelGenerator;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class ReportAppService : IReportAppService
    {
        private readonly IReportRepository _reportRepository;

        public ReportAppService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public MemoryStream GetReportTransactional(DateTime startdate, DateTime enddate)
        {
            MemoryStream ms = null;
            var data = _reportRepository.GetReportTransactional(startdate, enddate);
            using (var excel = new ExcelGenerator(data))
            {
                ms = excel.WriteExcelToStream();
            }
            return ms;
        }
    }
}