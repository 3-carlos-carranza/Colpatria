using Microsoft.Practices.Unity;

namespace Crusscutting.DependencyInjectionFactory
{
    public static class Factory
    {
        private static readonly DiContainer Container;


        public static TServicio Resolver<TServicio>()
        {
            return Container.Current.Resolve<TServicio>();
        }

        static Factory()
        {
            Container = new DiContainer();
        }
    }
}