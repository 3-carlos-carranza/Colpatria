using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.DataTransferObject.Vib;
using Core.Entities.Process;
using Core.Entities.User;
using Core.GlobalRepository.SQL.Process;
using Core.GlobalRepository.SQL.User;
using Crosscutting.Common.Tools.Contracts;
using Crosscutting.Common.Tools.DataType;
using Crosscutting.Common.Tools.Extensions;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class UserAppService : UserManager<User, long>, IUserAppService
    {
        private readonly IExtendedFieldRepository _extendedFieldRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFieldToCreateUserRepository _fieldToCreateUserRepository;
        private readonly IExecutionRepository _executionRepository;

        public UserAppService(IUserRepository userRepository,
            IFieldToCreateUserRepository fieldToCreateUserRepository,
            IExtendedFieldRepository extendedFieldRepository, IExecutionRepository executionRepository) : base(userRepository)
        {
            _userRepository = userRepository;
            _fieldToCreateUserRepository = fieldToCreateUserRepository;
            _extendedFieldRepository = extendedFieldRepository;
            _executionRepository = executionRepository;
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
            return _extendedFieldRepository.GetAllPagesWithSection();
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
                    Value = fieldValueOrders.FirstOrDefault(f => f.Key == s.BaseFieldId.ToString(CultureInfo.InvariantCulture))?.Value
                };
            })
                  .Where(s => !string.IsNullOrEmpty(s.Value))
                  .ToList();

            var user = new User();
            ObjectExtensions.MapDictionaryToObject(user, fieldValueTypes);

            return Task.FromResult(user);
        }

        public UserInfoDto GetUserInfoByExecutionId(long executionId)
        {
            return _userRepository.GetUserInfoByExecutionId(executionId);
        }

        public int? GetValidExecutionByUserAndProduct(long userId, int productId)
        {
            return _executionRepository.GetValidExecutionByUserAndProduct(userId, productId);
        }
    }
}