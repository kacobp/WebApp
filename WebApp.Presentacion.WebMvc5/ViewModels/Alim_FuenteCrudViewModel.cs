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
    
    public partial class Alim_FuenteCrudViewModel
    {
    	#region Fields
        
    	private readonly IAlim_FuenteAppService _serviceAlim_Fuente;
    	private readonly IAlimAppService _serviceAlim;
    
    	#endregion
    
    	#region Properties
    
    	public Alim_Fuente Alim_Fuente { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Alim_FuenteCrudViewModel()
        {
            Alim_Fuente = new Alim_Fuente();
        }
    
        /// <summary>
        /// Create a new instance of Alim_Fuente viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
        public Alim_FuenteCrudViewModel(IAlim_FuenteAppService service, IAlimAppService serviceAlim) : this()
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
