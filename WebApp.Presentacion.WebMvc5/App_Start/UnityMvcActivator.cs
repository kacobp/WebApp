using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;
using WebApp.Presentacion.WebMvc5.UnityContainer;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApp.Presentacion.WebMvc5.UnityMvcActivator), nameof(WebApp.Presentacion.WebMvc5.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebApp.Presentacion.WebMvc5.UnityMvcActivator), nameof(WebApp.Presentacion.WebMvc5.UnityMvcActivator.Shutdown))]

namespace WebApp.Presentacion.WebMvc5
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));

            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}