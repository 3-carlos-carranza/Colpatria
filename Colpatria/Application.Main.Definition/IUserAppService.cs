using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities.SQL.Process;
using Core.Entities.SQL.User;
using Crosscutting.Common.Tools;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;

namespace Application.Main.Definition
{
    public interface IUserAppService
    {
        Task<IdentityResult> ConfirmEmailAsync(long user, string token);
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<ClaimsIdentity> CreateIdentityAsync(User user, string type);
        Task<User> FindAsync(string email, string password);
        Task<User> FindByIdAsync(long userId);
        Task<User> FindByNameAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(long id);
        Task<string> GeneratePasswordResetTokenAsync(long id);
        Task<bool> IsEmailConfirmedAsync(long id);
        Execution GetRequestUserByRequestId(long requestid);
        Task SendEmailAsync(long id, string subject, string body);
        Task<IdentityResult> UpdateAsync(long user);
        Task<IdentityResult> UpdateUserAndPassword(User user, string newPassword);
        Task<IQueryable<string>> UsersAreRegistered(IEnumerable<string> cleanEmailsList);
        IEnumerable<Page> GetAllPagesWithSections();
        IEnumerable<FieldToCreateUser> GetMappingFieldToCreateUsers();
        Task<User> GetUserByMappingField(IEnumerable<FieldToCreateUser> mappingfields, IEnumerable<FieldValueOrder> fields);
    }
}