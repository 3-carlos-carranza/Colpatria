using System.Linq;
using Core.Entities.SQL.Process;

namespace DataAccess.ProcessModule.Repository
{
    partial class StepRepository
    {
        public Step GetFirstStepbyProcess(int processid)
        {
            return _context.Step.Where(s => s.ProcessId == processid).OrderBy(z => z.Order).FirstOrDefault();
        }
    }
}