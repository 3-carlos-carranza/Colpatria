using Core.GlobalRepository.SQL.Process;
using DataAccess.ProcessModule.Repository;
using DataAccess.ProcessModule.UnitOfWork;
using Microsoft.Practices.Unity;

namespace DataAccess.ProcessModule
{
    public static class ProcessDependencyRepository
    {
        public static void InitializeProcessRepository(this IUnityContainer container)
        {
            container.RegisterType<IProcessContext, ProcessContext>(new PerResolveLifetimeManager());
            container.RegisterType<IExecutionApplicantRepository, ExecutionApplicantRepository>();
            container.RegisterType<IExecutionRepository, ExecutionRepository>();
            container.RegisterType<IExtendedDataListRepository, ExtendedDataListRepository>();
            container.RegisterType<IExtendedFieldRepository, ExtendedFieldRepository>();
            container.RegisterType<IExtendedFieldValueRepository, ExtendedFieldValueRepository>();
            container.RegisterType<IExtendedFileRepository, ExtendedFileRepository>();
            container.RegisterType<IExtendedListRepository, ExtendedListRepository>();
            container.RegisterType<IFieldInSectionRepository, FieldInSectionRepository>();
            container.RegisterType<IPageRepository, PageRepository>();
            container.RegisterType<IProcessRepository, ProcessRepository>();
            container.RegisterType<IProductProcessRepository, ProductProcessRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ISectionRepository, SectionRepository>();
            container.RegisterType<IStateRepository, StateRepository>();
            container.RegisterType<IStepRepository, StepRepository>();
            container.RegisterType<IStepSectionRepository, StepSectionRepository>();
        }
    }
}