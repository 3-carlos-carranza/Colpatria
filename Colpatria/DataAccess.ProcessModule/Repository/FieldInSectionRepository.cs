using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class FieldInSectionRepository : Repository<FieldInSection>, IFieldInSectionRepository
    {
        private IProcessContext _context;
    	
    
        public FieldInSectionRepository(IProcessContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
