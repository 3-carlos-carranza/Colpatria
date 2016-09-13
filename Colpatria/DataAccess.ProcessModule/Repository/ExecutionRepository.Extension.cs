#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ExecutionRepository.Extension.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-12  - 10:18 a. m.</Date>
//   <Update> 2016-09-13 - 11:38 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;
using Core.Entities.ProcessModel;

#endregion

namespace DataAccess.ProcessModule.Repository
{
    partial class ExecutionRepository
    {
        public Execution CreateRequest(Execution execution)
        {
            var nextSectionAndPage = GetNextSectionAndPage(0, execution.ProcessId);

            execution.CurrentPageId = nextSectionAndPage.PageId;
            execution.CurrentSectionId = nextSectionAndPage.SectionId;

            Add(execution);

            AssociateUserWithRequest(execution.Id, execution.UserId);
            UnitOfWork.Commit();

            execution.CurrentPageId = _context.Section.First(s => s.Id == execution.CurrentSectionId).PageId;
            UnitOfWork.Commit();

            return execution;
        }

        


        public Execution GetRequestById(long id)
        {
            var request = GetFiltered(s => s.Id == id).FirstOrDefault();
            if (request == null)
            {
                return null;
            }
            request.CurrentPageId = _context.Section.First(s => s.Id == request.CurrentSectionId).PageId;
            return request;
        }

        public StepDetail GetNextStepWithType(int step, int section, int processId, StepType type)
        {
            var context = UnitOfWork as DbContext;
            return
                context?.Database.SqlQuery<StepDetail>(
                    "GetNextStepbyStepType @CurrentStepId,@CurrentSectionId, @ProcessId, @StepType",
                    new SqlParameter {ParameterName = "CurrentStepId", Value = step},
                    new SqlParameter {ParameterName = "CurrentSectionId", Value = section},
                    new SqlParameter {ParameterName = "ProcessId", Value = processId},
                    new SqlParameter {ParameterName = "StepType", Value = (int) type}
                ).First();
        }

        public PageSection GetNextSectionAndPage(int sectionId, int processId)
        {
            var context = UnitOfWork as DbContext;
            return
                context?.Database.SqlQuery<PageSection>("GetNextSectionAndPage @CurrentSectionId, @ProcessId",
                    new SqlParameter {ParameterName = "CurrentSectionId", Value = sectionId},
                    new SqlParameter {ParameterName = "ProcessId", Value = processId}).First();
        }

        private void AssociateUserWithRequest(long executionId, long userId)
        {
            var executionApplicant = new ExecutionApplicant
            {
                ExecutionId = executionId,
                UserId = userId,
                Applicant = 1,
                IsMain = true
            };
            _context.ExecutionApplicant.Add(executionApplicant);
        }
    }
}