using Core.GlobalRepository.SQL.Process;
using Core.Entities.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class ExtendedFieldValueRepository : Repository<ExtendedFieldValue>, IExtendedFieldValueRepository
    {
        private IProcessContext _context;
    	
    
        public ExtendedFieldValueRepository(IProcessContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
