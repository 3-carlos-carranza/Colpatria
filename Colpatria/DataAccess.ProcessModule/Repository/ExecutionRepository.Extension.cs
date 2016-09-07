using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Core.DataTransferObject.SQL;
using Core.Entities.SQL.Process;

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

        public Execution GetLatestRequest(long userId, long product, int process, string requestType)
        {
            throw new NotImplementedException();
        }

        public Execution GetRequestbyUserAndRequestSimpleId(long userId, string simpleId, long product)
        {
            throw new NotImplementedException();
        }

        public PageSection GetNextSectionAndPage(int sectionId, int processId)
        {
            var context = UnitOfWork as DbContext;
            return
                context?.Database.SqlQuery<PageSection>("GetNextSectionAndPage @CurrentSectionId, @ProcessId",
                    new SqlParameter { ParameterName = "CurrentSectionId", Value = sectionId },
                    new SqlParameter { ParameterName = "ProcessId", Value = processId }).First();
        }

        private void AssociateUserWithRequest(long executionId, long userId)
        {
            var executionApplicant = new ExecutionApplicant()
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