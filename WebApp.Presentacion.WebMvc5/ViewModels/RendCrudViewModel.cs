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
    
    public partial class RendCrudViewModel
    {
    	#region Fields
        
    	private readonly IRendAppService _serviceRend;
    	private readonly IRendCantAppService _serviceRendCant;
    
    	#endregion
    
    	#region Properties
    
    	public Rend Rend { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RendCrudViewModel()
        {
            Rend = new Rend();
        }
    
        /// <summary>
        /// Create a new instance of Rend viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceRendCant">Service dependency</param>
        public RendCrudViewModel(IRendAppService service, IRendCantAppService serviceRendCant) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceRendCant == null)
                throw new ArgumentNullException("serviceRendCant", PresentationResources.exception_WithoutService);
    
            _serviceRend = service;
            _serviceRendCant = serviceRendCant;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
