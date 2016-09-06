using Core.Entities.SQL.Process;
using Core.GlobalRepository.Definition.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class ExtendedDataListRepository : Repository<ExtendedDataList>, IExtendedDataListRepository
    {
        private IProcessContext _context;
    	
    
        public ExtendedDataListRepository(IProcessContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
