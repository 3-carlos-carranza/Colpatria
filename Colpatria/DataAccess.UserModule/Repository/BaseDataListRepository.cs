using Core.GlobalRepository.SQL.User;
using Core.Entities.User;
using Data.Common.Implementation;
using DataAccess.UserModule.UnitOfWork;

namespace DataAccess.UserModule.Repository
{
    
    
    
    public  partial class BaseDataListRepository : Repository<BaseDataList>, IBaseDataListRepository
    {
        private IUserContext _context;
    	
    
        public BaseDataListRepository(IUserContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IUserContext;
            }
    
    
    }
}
