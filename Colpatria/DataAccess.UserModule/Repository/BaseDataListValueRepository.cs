using Core.GlobalRepository.SQL.User;
using Core.Entities.User;
using Data.Common.Implementation;
using DataAccess.UserModule.UnitOfWork;

namespace DataAccess.UserModule.Repository
{
    
    
    
    public  partial class BaseDataListValueRepository : Repository<BaseDataListValue>, IBaseDataListValueRepository
    {
        private IUserContext _context;
    	
    
        public BaseDataListValueRepository(IUserContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IUserContext;
            }
    
    
    }
}
