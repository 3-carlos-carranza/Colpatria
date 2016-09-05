using Microsoft.AspNet.Identity;

namespace Core.GlobalRepository.Definition.SQL.User
{
    public partial interface IUserRepository : 
        IUserPasswordStore<Entities.SQL.User.User, long>, 
        IUserEmailStore<Entities.SQL.User.User, long>,  
        IUserRoleStore<Entities.SQL.User.User, long>
    {
    }
}