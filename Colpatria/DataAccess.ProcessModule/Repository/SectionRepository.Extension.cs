#region Signature

// ----------------------------------------------------------------------- <copyright
// file=SectionRepository.Extension.cs company="Banlinea S.A.S"> Copyright (c) Banlinea Todos los
// derechos reservados. </copyright> <author>Jeysson Stevens Ramirez </author> <Date> 2016 -09-13 -
// 10:13 a. m.</Date> <Update> 2016-09-13 - 11:50 a. m.</Update> -----------------------------------------------------------------------

#endregion Signature

#region

using Core.DataTransferObject.Vib;
using System.Linq;

#endregion

namespace DataAccess.ProcessModule.Repository
{
    partial class SectionRepository
    {
        public StepDetail GetCurrentStepDetailByExecutionId(long executionId)
        {
            var query = (from e in _context.Execution
                         join step in _context.Step on e.CurrentStepId equals step.Id
                         join ss in _context.StepSection on step.Id equals ss.StepId
                         join sec in _context.Section on ss.SectionId equals sec.Id
                         join p in _context.Page on sec.PageId equals p.Id
                         where ss.SectionId == e.CurrentSectionId && ss.StepId == e.CurrentStepId && e.Id == executionId
                         orderby p.Order
                         orderby sec.Order
                         select new StepDetail
                         {
                             Id = step.Id,
                             Name = step.Name,
                             Order = step.Order,
                             PageId = p.Id,
                             PageName = p.Name,
                             SectionId = sec.Id,
                             SectionName = sec.Name,
                             StepType = step.StepType,
                             IsPre = step.IsPre,
                             Description = step.Description,
                             AutoAdvance = step.AutoAdvance,
                             ProcessId = step.ProcessId,
                             StateId = step.StateId,
                             Action = sec.Action,
                             Controller = sec.Controller,
                             ActionMethod = sec.ActionMethod
                         }
            ).FirstOrDefault();

            return query;
        }
    }
}