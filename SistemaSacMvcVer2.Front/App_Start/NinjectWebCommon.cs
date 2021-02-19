[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SistemaSacMvcVer2.Front.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SistemaSacMvcVer2.Front.App_Start.NinjectWebCommon), "Stop")]

namespace SistemaSacMvcVer2.Front.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using SistemaSacMvcVer2.Aplicación.Servicios;
    using SistemaSacMvcVer2.Dominio.Interfaces;
    using SistemaSacMvcVer2.Dominio.Interfaces.ICtoContrato;
    using SistemaSacMvcVer2.Infraestructura.Interfaces;
    using SistemaSacMvcVer2.Infraestructura.Repositorios.UnitOfWork;
    using SistemaSacMvcVer2.Infraestructura.Servicios.WebServices.Repositorios.UnitOfWebService;
    using System;
    using System.Web;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICtoContratoServicio>().To<CtoContratoServicio>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IUnitOfWebService>().To<UnitOfWebService>();
        }        
    }
}
