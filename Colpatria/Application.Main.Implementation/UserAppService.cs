using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition;
using Core.Entities.SQL.Process;
using Core.Entities.SQL.User;
using Core.GlobalRepository.Definition.SQL.User;
using Microsoft.AspNet.Identity;

namespace Application.Main.Implementation
{
    public class UserAppService : UserManager<User, long>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        public UserAppService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public override Task<User> FindByIdAsync(long userId)
        {
            return Task.FromResult(_userRepository.Get(s => s.Id == userId));
        }

        public Execution GetRequestUserByRequestId(long requestid)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(long user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateUserAndPassword(User user, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<string>> UsersAreRegistered(IEnumerable<string> cleanEmailsList)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Page> GetAllPagesWithSections()
        {
            throw new System.NotImplementedException();
        }
    }
}