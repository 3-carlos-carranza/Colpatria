#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ContainerInitializer.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 12:30 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using Application.Main.Implementation;
using Data.DataCredito;
using Data.Inalambria;
using Data.MongoModule;
using DataAccess.ProcessModule;
using DataAccess.UserModule;
using Microsoft.Practices.Unity;

#endregion

namespace Crosscutting.DependencyInjectionFactory
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {
            container.InitializeProcessRepository();
            container.InitializeUserRepository();
            container.InitializeMongoRepository();
            container.InitializeAppService();
            container.InitializeDataCreditoRepository();
            container.InitializeDataInalambriaRepository();
        }
    }
}