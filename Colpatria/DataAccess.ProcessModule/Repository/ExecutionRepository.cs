using Core.Entities.SQL.Process;
using Core.GlobalRepository.Definition.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class ExecutionRepository : Repository<Execution>, IExecutionRepository
    {
        private IProcessContext _context;
    	
    
        public ExecutionRepository(IProcessContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
