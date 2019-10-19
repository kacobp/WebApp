//===================================================================================
// © CBP
//===================================================================================

#region

using WebApp.Aplicacion.AppServices;

//using Aplicacion.Dtos;
using WebApp.Dominio.Entidades;
using WebApp.Presentacion.WebMvc5.Resources;
using WebApp.Transversales.Caching;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace WebApp.Presentacion.WebMvc5.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log4netCrudViewModel
    {
    	#region Fields
        
    	private readonly ILog4netAppService _serviceLog4net;
    
    	#endregion
    
    	#region Properties
    
    	public Log4net Log4net { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Log4netCrudViewModel()
        {
            Log4net = new Log4net();
        }
    
        /// <summary>
        /// Create a new instance of Log4net viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        public Log4netCrudViewModel(ILog4netAppService service) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    
            _serviceLog4net = service;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
