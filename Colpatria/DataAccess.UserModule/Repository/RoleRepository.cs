using Core.GlobalRepository.SQL.User;
using Core.Entities.User;
using Data.Common.Implementation;
using DataAccess.UserModule.UnitOfWork;

namespace DataAccess.UserModule.Repository
{
    
    
    
    public  partial class RoleRepository : Repository<Role>, IRoleRepository
    {
        private IUserContext _context;
    	
    
        public RoleRepository(IUserContext uow): base(uow)
        {
    	
    	    SetContext();
        }
    
            private void SetContext()
            {
                _context = UnitOfWork as IUserContext;
            }
    
    
    }
}
