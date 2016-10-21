using System;
using Crosscutting.Common.Tools.ExcelGenerator;

namespace Core.GlobalRepository.SQL.Process
{
    public interface IReportRepository
    {
        ReportDto GetReportTransactional(DateTime startdate, DateTime enddate);
    }
}