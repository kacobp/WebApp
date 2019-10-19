//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

//using Aplicacion.AppServices;

using WebApp.Aplicacion.AppServices;
using WebApp.Datos.Core;
using WebApp.Datos.DataModel;
using WebApp.Datos.Repository;
using WebApp.Dominio.Core.UnitOfWork;
using WebApp.Dominio.IRepository;
//using WebApp.Servicio.WCF.WcfServices;
using WebApp.Transversales.Adapter;
using WebApp.Transversales.Log;
using WebApp.Transversales.Validator;
using System.Data.Entity;
using Unity;
using Unity.AspNet.Mvc;
//using Unity.Injection;

#endregion

namespace WebApp.Presentacion.WebMvc5.UnityContainer
{
    using System;
    using System.Collections.Generic;
    
    /// <summary>
    /// DI container accessor
    /// </summary>
    public partial class UnityConfig
    {
    	#region Unity Container
    
        private static readonly Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
    		var container = new Unity.UnityContainer();
    
    		ConfigureContainer(container);
    		//ConfigureCustomContainer(container);
            ConfigureFactories();
    		//ConfigureCustomFactories();
            return container;
        });
    
    	/// <summary>
    	/// Configured Unity Container.
    	/// </summary>
    	public static IUnityContainer Container => container.Value;
    
        #endregion
    
    	#region Methods
    
        /// <summary>
        /// Registers the type mappings with the Unity container
        /// </summary>
        /// <param name="container">The unity container to configure</param>
        private static void ConfigureContainer(IUnityContainer container)
        {
    
            //-> Log
            //container.RegisterType<ILogger, Logger>(new InjectionMethod(nameof(Logger.Attach), typeof(ILog)));
            //container.RegisterType<ILog, ObserverTraceLog>(new InjectionConstructor("debug"));
    
            //-> Unit of Work
            container.RegisterType<DbContext, DatabaseContext>(new PerRequestLifetimeManager());
            container.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager());
    
    		//-> Adapters
            //container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());	
    
    		#region Model -> "..\..\WebApp.Datos\DataModel\DatabaseModel.edmx"
    
    		//-> Repositories
    		container.RegisterType<IAlimRepository, AlimRepository>();
    		container.RegisterType<IAlim_FuenteRepository, Alim_FuenteRepository>();
    		container.RegisterType<IAlim_GrpRepository, Alim_GrpRepository>();
    		container.RegisterType<IDesCantRepository, DesCantRepository>();
    		container.RegisterType<IDesechoRepository, DesechoRepository>();
    		container.RegisterType<IFactConvRepository, FactConvRepository>();
    		container.RegisterType<IFamRecRepository, FamRecRepository>();
    		container.RegisterType<IImagenesRepository, ImagenesRepository>();
    		container.RegisterType<ILog4netRepository, Log4netRepository>();
    		container.RegisterType<ILoginAttemptsRepository, LoginAttemptsRepository>();
    		container.RegisterType<IMedidaRepository, MedidaRepository>();
    		container.RegisterType<INt_CantRepository, Nt_CantRepository>();
    		container.RegisterType<INt_FuenteRepository, Nt_FuenteRepository>();
    		container.RegisterType<INt_FuncRepository, Nt_FuncRepository>();
    		container.RegisterType<INt_GrpRepository, Nt_GrpRepository>();
    		container.RegisterType<INt_Grp_CantRepository, Nt_Grp_CantRepository>();
    		container.RegisterType<INutrienteRepository, NutrienteRepository>();
    		container.RegisterType<IPasswordRepository, PasswordRepository>();
    		container.RegisterType<IPermisosUsuarioRepository, PermisosUsuarioRepository>();
    		container.RegisterType<IRecetaRepository, RecetaRepository>();
    		container.RegisterType<IRecProdRepository, RecProdRepository>();
    		container.RegisterType<IRendRepository, RendRepository>();
    		container.RegisterType<IRendCantRepository, RendCantRepository>();
    		container.RegisterType<IRolUsuarioRepository, RolUsuarioRepository>();
    		container.RegisterType<IUniMedRepository, UniMedRepository>();
    		container.RegisterType<IUserPasswordsRepository, UserPasswordsRepository>();
    		container.RegisterType<IUserPhotosRepository, UserPhotosRepository>();
    		container.RegisterType<IUsuarioRepository, UsuarioRepository>();
    		
    		//-> Application services
    		container.RegisterType<IAlimAppService, AlimAppService>();
    		container.RegisterType<IAlim_FuenteAppService, Alim_FuenteAppService>();
    		container.RegisterType<IAlim_GrpAppService, Alim_GrpAppService>();
    		container.RegisterType<IDesCantAppService, DesCantAppService>();
    		container.RegisterType<IDesechoAppService, DesechoAppService>();
    		container.RegisterType<IFactConvAppService, FactConvAppService>();
    		container.RegisterType<IFamRecAppService, FamRecAppService>();
    		container.RegisterType<IImagenesAppService, ImagenesAppService>();
    		container.RegisterType<ILog4netAppService, Log4netAppService>();
    		container.RegisterType<ILoginAttemptsAppService, LoginAttemptsAppService>();
    		container.RegisterType<IMedidaAppService, MedidaAppService>();
    		container.RegisterType<INt_CantAppService, Nt_CantAppService>();
    		container.RegisterType<INt_FuenteAppService, Nt_FuenteAppService>();
    		container.RegisterType<INt_FuncAppService, Nt_FuncAppService>();
    		container.RegisterType<INt_GrpAppService, Nt_GrpAppService>();
    		container.RegisterType<INt_Grp_CantAppService, Nt_Grp_CantAppService>();
    		container.RegisterType<INutrienteAppService, NutrienteAppService>();
    		container.RegisterType<IPasswordAppService, PasswordAppService>();
    		container.RegisterType<IPermisosUsuarioAppService, PermisosUsuarioAppService>();
    		container.RegisterType<IRecetaAppService, RecetaAppService>();
    		container.RegisterType<IRecProdAppService, RecProdAppService>();
    		container.RegisterType<IRendAppService, RendAppService>();
    		container.RegisterType<IRendCantAppService, RendCantAppService>();
    		container.RegisterType<IRolUsuarioAppService, RolUsuarioAppService>();
    		container.RegisterType<IUniMedAppService, UniMedAppService>();
    		container.RegisterType<IUserPasswordsAppService, UserPasswordsAppService>();
    		container.RegisterType<IUserPhotosAppService, UserPhotosAppService>();
    		container.RegisterType<IUsuarioAppService, UsuarioAppService>();
    
    		#endregion
    }
    	
        /// <summary>
        /// Factories configuration
        /// </summary>
        private static void ConfigureFactories()
        {
            //LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());
    		//TypeAdapterFactory.SetCurrent(new AutomapperTypeAdapterFactory());
        }
    
        #endregion
    }
}
