using Core.GlobalRepository.SQL.Process;
using Core.Entities.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class ExecutionApplicantRepository : Repository<ExecutionApplicant>, IExecutionApplicantRepository
    {
        private IProcessContext _context;
    	
    
        public ExecutionApplicantRepository(IProcessContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
