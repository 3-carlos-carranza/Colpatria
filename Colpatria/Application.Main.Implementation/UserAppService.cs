﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition;
using Core.Entities.SQL.Process;
using Core.Entities.SQL.User;
using Core.GlobalRepository.Definition.SQL.User;
using Crosscutting.Common.Tools;
using Crosscutting.Common.Tools.DataType;
using Microsoft.AspNet.Identity;

namespace Application.Main.Implementation
{
    public class UserAppService : UserManager<User, long>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFieldToCreateUserRepository _fieldToCreateUserRepository;
        public UserAppService(IUserRepository userRepository, 
            IFieldToCreateUserRepository fieldToCreateUserRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _fieldToCreateUserRepository = fieldToCreateUserRepository;
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

        public IEnumerable<FieldToCreateUser> GetMappingFieldToCreateUsers()
        {
            return _fieldToCreateUserRepository.GetAll().ToList();
        }

        public Task<User> GetUserByMappingField(IEnumerable<FieldToCreateUser> mappingfields, IEnumerable<FieldValueOrder> fields)
        {
            var fieldValueTypes = mappingfields.Select(s =>
            {
                var fieldValueOrders = fields as IList<FieldValueOrder> ?? fields.ToList();
                return new FieldValueType
                {
                    DataType = s.DataType,
                    Key = s.ColumnName,
                    Value =
                        fieldValueOrders.First(f => f.Key == s.BaseFieldId.ToString(CultureInfo.InvariantCulture)) ==
                        null
                            ? ""
                            : fieldValueOrders.First(f => f.Key == s.BaseFieldId.ToString(CultureInfo.InvariantCulture))
                                .Value ?? ""
                };
            })
                  .Where(s => !string.IsNullOrEmpty(s.Value))
                  .ToList();

            var user = new User();
            ObjectExtension<User>.MapDictinaryToObject(user, fieldValueTypes);

            return Task.FromResult(user);
        }
    }
}