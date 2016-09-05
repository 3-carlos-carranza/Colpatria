using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.SQL.User;

namespace DataAccess.UserModule.Repository
{
    partial class UserRepository
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(User user)
        {
            Add(user);
            return Task.FromResult(0);
        }

        public Task UpdateAsync(User user)
        {
            Update(user);
            UnitOfWork.Commit();
            return Task.FromResult(0);
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(long userId)
        {
            return Task.FromResult(Get(u => u.Id == userId));
        }

        public Task<User> FindByNameAsync(string userName)
        {
            return Task.FromResult(GetFiltered(u => u.UserName.Equals(userName)).FirstOrDefault());
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            if (Any(u => u.Id == user.Id))
            {
                UpdateAsync(user);
            }

            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            return Task.FromResult(Get(u => u.UserName == user.UserName).PasswordHash);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(User user, string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user)
        {
            return Task.FromResult(Get(u => u.Id == user.Id).Email);
        }

        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return Task.FromResult(Any(u => u.Email == user.Email && u.EmailConfirmed));
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            UpdateAsync(user);
            UnitOfWork.Commit();

            return Task.FromResult(0);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}