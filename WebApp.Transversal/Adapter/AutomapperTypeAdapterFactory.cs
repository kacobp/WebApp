// -----------------------------------------------------------------------
// <copyright file="AutomapperTypeAdapterFactory.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Adapter
{
    #region Using Directives

    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        #region Constructors and Destructors
        private readonly IMapper mapper;

        #region Constructor

        /// <summary>
        /// Create a new Automapper type adapter factory
        /// </summary>
        public AutomapperTypeAdapterFactory()
        {
            // Scan all assemblies finding Automapper Profile
            var profiles = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType == typeof(Profile));

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });


            configuration.AssertConfigurationIsValid();

            mapper = configuration.CreateMapper();

            //Mapper.Initialize(cfg =>
            //{
            //    foreach (var item in profiles.Where(item => item.FullName != "AutoMapper.SelfProfiler`2"))
            //        cfg.AddProfile(Activator.CreateInstance(item) as Profile);
            //});
        }

        #endregion

        /// <summary>
        ///     Create a new Automapper type adapter factory
        /// </summary>
        //public AutomapperTypeAdapterFactory()
        //{
        //    // **********************************************
        //    // Uncomment below if LoaderExceptions occur
        //    // **********************************************
        //    var asm = AppDomain.CurrentDomain.GetAssemblies();
        //    foreach (var a in asm)
        //    {
        //        Debug.Print("Getting types: {0}", a.FullName);
        //        try
        //        {
        //            var types = a.GetTypes()
        //                .Where(t => t.BaseType == typeof(Profile))
        //                .ToList();
        //            foreach (var type in types)
        //            {
        //                Debug.Print("Type Reflected: {0}", type.Name);
        //            }
        //        }
        //        catch (ReflectionTypeLoadException refEx)
        //        {
        //            Debug.Print("**************** ReflectionTypeLoadException ****************");
        //            foreach (var loaderException in refEx.LoaderExceptions)
        //            {
        //                Debug.Print(loaderException.Message);
        //            }

        //            var helpMsg = string.Format("Error reflecting type. Check references to assembly [{0}] in the calling application (most likely using UnityContainer)", a.FullName);
        //            LoggerFactory.CreateLog().Warning(helpMsg, refEx);
        //            Debug.Assert(false, helpMsg, refEx.Message);
        //        }
        //    }

        //    try
        //    {
        //        // Scan all assemblies finding Automapper Profile
        //        var profiles = AppDomain.CurrentDomain.GetAssemblies()
        //            .SelectMany(a => a.GetTypes())
        //            .Where(t => t.BaseType == typeof(Profile));

        //        Mapper.Initialize(cfg =>
        //        {
        //            var mapTypes = profiles.Where(item => item.FullName != "AutoMapper.SelfProfiler`2").ToList();
        //            foreach (var item in mapTypes)
        //            {
        //                cfg.AddProfile(Activator.CreateInstance(item) as Profile);
        //            }
        //        });
        //    }
        //    catch (ReflectionTypeLoadException refEx)
        //    {
        //        Debug.Print("**************** ReflectionTypeLoadException ****************");
        //        foreach (var loaderException in refEx.LoaderExceptions)
        //        {
        //            Debug.Print(loaderException.Message);
        //        }

        //        var helpMsg = string.Format("Error reflecting type. Loader Exceptions: {0}", string.Join("\r\n", refEx.LoaderExceptions.Select(lEx => lEx.Message)));
        //        LoggerFactory.CreateLog().Warning(helpMsg, refEx);
        //        Debug.Assert(false, helpMsg, refEx.Message);
        //        throw;
        //    }
        //}

        #endregion

        #region Public Methods and Operators
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter(mapper);
        }

        //private Assembly[] GetAssemblies()
        //{
        //    var assemblies = new List<Assembly>();
        //    var dependencies = DependencyContext.Default.RuntimeLibraries.Where(p =>
        //        p.Type.Equals("Project", StringComparison.CurrentCultureIgnoreCase));
        //    foreach (var library in dependencies)
        //    {
        //        var name = new AssemblyName(library.Name);
        //        var assembly = Assembly.Load(name);
        //        assemblies.Add(assembly);
        //    }

        //    return assemblies.ToArray();
        //}

        #endregion
    }
}