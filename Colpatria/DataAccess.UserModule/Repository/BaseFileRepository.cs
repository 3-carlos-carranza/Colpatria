using Core.GlobalRepository.SQL.User;
using Core.Entities.User;
using Data.Common.Implementation;
using DataAccess.UserModule.UnitOfWork;

namespace DataAccess.UserModule.Repository
{
    
    
    
    public  partial class BaseFileRepository : Repository<BaseFile>, IBaseFileRepository
    {
        private IUserContext _context;
    	
    
        public BaseFileRepository(IUserContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IUserContext;
            }
    
    
    }
}
