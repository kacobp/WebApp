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
    
    public partial class Alim_FuenteFindViewModel : ViewModelBase<Alim_Fuente>
    {
    	#region Fields
            
    	private readonly IAlim_FuenteAppService _serviceAlim_Fuente;
    	private readonly IAlimAppService _serviceAlim;
    
    	#endregion
    
    	#region Properties
    
    	public Alim_FuenteFindModel Alim_Fuente { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Alim_FuenteFindViewModel()
        {
            Alim_Fuente = new Alim_FuenteFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Alim_Fuente viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
        public Alim_FuenteFindViewModel(IAlim_FuenteAppService service, IAlimAppService serviceAlim) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
            _serviceAlim_Fuente = service;
            _serviceAlim = serviceAlim;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
