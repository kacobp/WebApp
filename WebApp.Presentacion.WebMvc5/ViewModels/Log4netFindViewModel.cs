//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using WebApp.Aplicacion.AppServices;

//using WebApp.Aplicacion.Dtos;
using WebApp.Dominio.Entidades;
using WebApp.Presentacion.WebMvc5.Resources;
using WebApp.Presentacion.WebMvc5.Models;
using WebApp.Transversales.Caching;
//using WebApp.Transversales.Framework;
using WebApp.Transversales.Log;
using WebApp.Transversales.Log4net;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

#endregion

namespace WebApp.Presentacion.WebMvc5.ViewModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Log4netFindViewModel : ViewModelBase<Log4net>
    {
    	#region Fields
            
    	private readonly ILog4netAppService _serviceLog4net;
    
    	#endregion
    
    	#region Properties
    
    	public Log4netFindModel Log4net { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Log4netFindViewModel()
        {
            Log4net = new Log4netFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Log4net viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
        public Log4netFindViewModel(ILog4netAppService service) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    
            _serviceLog4net = service;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
