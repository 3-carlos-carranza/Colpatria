using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class StepSectionRepository : Repository<StepSection>, IStepSectionRepository
    {
        private IProcessContext _context;
    	
    
        public StepSectionRepository(IProcessContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
