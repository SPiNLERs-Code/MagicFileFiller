[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MagicFileFiller.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MagicFileFiller.App_Start.NinjectWebCommon), "Stop")]

namespace MagicFileFiller.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Data.Entity;
    using DatabaseContext;
    using DatabaseContext.Interfaces;
    using Ninject.Extensions.NamedScope;
    using Repositories.Interfaces;
    using Repositories;

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
            kernel.Bind<IDatabaseInitializer<MagicFileFillerEntities>>().To<CreateDatabaseIfNotExist>();
            kernel.Bind<IDbContextFactory<MagicFileFillerEntities>>().To<DbContextFactory>().InCallScope();
            kernel.Bind<IDbContextManager>().To<DbContextManager<MagicFileFillerEntities>>().InCallScope(); ;
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InCallScope(); ;

            //kernel.Bind<IChangeRepository>().To<ChangeRepository>().InCallScope();
            kernel.Bind<IWordFieldRepository>().To<WordFieldRepository>().InCallScope();
            kernel.Bind<IWordFileRepository>().To<WordFileRepository>().InCallScope();
        }
    }
}
