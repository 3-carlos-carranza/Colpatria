using Core.GlobalRepository.Definition.SQL.User;
using DataAccess.UserModule.Repository;
using DataAccess.UserModule.UnitOfWork;
using Microsoft.Practices.Unity;

namespace DataAccess.UserModule
{
    public static class UserDependencyRepository
    {
        public static void InitializeUserRepository(this IUnityContainer container)
        {
            container.RegisterType<IUserContext, UserContext>(new PerResolveLifetimeManager());
            container.RegisterType<IBaseDataListRepository, BaseDataListRepository>();
            container.RegisterType<IBaseDataListValueRepository, BaseDataListValueRepository>();
            container.RegisterType<IBaseFieldRepository, BaseFieldRepository>();
            container.RegisterType<IBaseFieldValueRepository, BaseFieldValueRepository>();
            container.RegisterType<IBaseFileRepository, BaseFileRepository>();
            container.RegisterType<IFieldToCreateUserRepository, FieldToCreateUserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();
        }
    }
}