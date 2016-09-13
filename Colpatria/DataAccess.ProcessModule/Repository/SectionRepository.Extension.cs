#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=SectionRepository.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-13  - 10:13 a. m.</Date>
//   <Update> 2016-09-13 - 10:18 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Linq;
using Core.Entities.Process;

#endregion

namespace DataAccess.ProcessModule.Repository
{
    partial class SectionRepository
    {
        public Section GetSectionByExecution(long executionId)
        {
            var query = (from e in _context.Execution
                join step in _context.Step on e.CurrentStepId equals step.Id
                join ss in _context.StepSection on step.Id equals ss.StepId
                join sec in _context.Section on ss.SectionId equals sec.Id
                join p in _context.Page on sec.PageId equals p.Id
                where ss.SectionId == e.CurrentSectionId && ss.StepId == e.CurrentStepId
                orderby p.Order
                orderby sec.Order
                select sec
            ).FirstOrDefault();

            return query;
        }
    }
}