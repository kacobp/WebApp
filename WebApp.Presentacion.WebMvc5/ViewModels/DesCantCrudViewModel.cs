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
    
    public partial class DesCantCrudViewModel
    {
    	#region Fields
        
    	private readonly IDesCantAppService _serviceDesCant;
    	private readonly IAlimAppService _serviceAlim;
    	private readonly IDesechoAppService _serviceDesecho;
    
    	#endregion
    
    	#region Properties
    
    	public DesCant DesCant { get; set; }
    	public List<SelectListItem> Alims { get; set; }
    	public List<SelectListItem> Desechos { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public DesCantCrudViewModel()
        {
            DesCant = new DesCant();
        }
    
        /// <summary>
        /// Create a new instance of DesCant viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
    	/// <param name="serviceDesecho">Service dependency</param>
        public DesCantCrudViewModel(IDesCantAppService service, IAlimAppService serviceAlim, IDesechoAppService serviceDesecho) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    		if (serviceDesecho == null)
                throw new ArgumentNullException("serviceDesecho", PresentationResources.exception_WithoutService);
    
            _serviceDesCant = service;
            _serviceAlim = serviceAlim;
            _serviceDesecho = serviceDesecho;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
