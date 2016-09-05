using Core.GlobalRepository.Definition.SQL.User;
using Core.Entities.SQL.User;
using Data.Common.Implementation;
using DataAccess.UserModule.UnitOfWork;

namespace DataAccess.UserModule.Repository
{
    
    
    
    public  partial class FieldToCreateUserRepository : Repository<FieldToCreateUser>, IFieldToCreateUserRepository
    {
        private IUserContext _context;
    	
    
        public FieldToCreateUserRepository(IUserContext uow): base(uow)
        {
    	
    	    this.SetContext();
        }
    
            private void SetContext()
            {
                this._context = UnitOfWork as IUserContext;
            }
    
    
    }
}
