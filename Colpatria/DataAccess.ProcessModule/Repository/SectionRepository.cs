using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class SectionRepository : Repository<Section>, ISectionRepository
    {
        private IProcessContext _context;
    	
    
        public SectionRepository(IProcessContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
