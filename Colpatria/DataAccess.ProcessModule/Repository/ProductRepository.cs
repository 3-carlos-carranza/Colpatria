using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.UnitOfWork;
using Data.Common.Implementation;
namespace DataAccess.ProcessModule.Repository
{
    
    
    
    public  partial class ProductRepository : Repository<Product>, IProductRepository
    {
        private IProcessContext _context;
    	
    
        public ProductRepository(IProcessContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IProcessContext;
            }
    
    
    }
}
