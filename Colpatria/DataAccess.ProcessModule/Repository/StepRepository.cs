using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class StepRepository : Repository<Step>, IStepRepository
    {
        private IProcessContext _context;
    	
    
        public StepRepository(IProcessContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
