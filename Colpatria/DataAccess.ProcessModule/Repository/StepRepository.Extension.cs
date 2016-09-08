#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=StepRepository.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 3:39 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using System.Linq;
using Core.Entities.Process;

#endregion

namespace DataAccess.ProcessModule.Repository
{
    partial class StepRepository
    {
        public Step GetFirstStepbyProcess(int processid)
        {
            return _context.Step.Where(s => s.ProcessId == processid).OrderBy(z => z.Order).FirstOrDefault();
        }

        public IEnumerable<Step> GetAllStepsEnablesByProduct(int productId)
        {
            return (from pp in _context.ProductProcess
                join p in _context.Process on pp.ProcessId equals p.Id
                join s in _context.Step on p.Id equals s.ProcessId
                where s.Enable
                select s).ToList();
        }
    }
}