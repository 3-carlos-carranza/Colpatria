using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.SQL.Process;

namespace Core.GlobalRepository.Definition.SQL.Process
{
    partial interface IStepRepository
    {
        Step GetFirstStepbyProcess(int processid);
    }
}
