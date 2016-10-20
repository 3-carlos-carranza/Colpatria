using Core.DataTransferObject.Vib;
using Microsoft.AspNet.Identity;

namespace Core.GlobalRepository.SQL.User
{
    public partial interface IUserRepository : 
        IUserPasswordStore<Entities.User.User, long>, 
        IUserEmailStore<Entities.User.User, long>,  
        IUserRoleStore<Entities.User.User, long>
    {
        UserInfoDto GetUserInfoByExecutionId(long executionId);
        UserInfoDto GetUserInfoByUserId(long userId);
    }
}