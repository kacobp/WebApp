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
    
    public partial class DesechoCrudViewModel
    {
    	#region Fields
        
    	private readonly IDesechoAppService _serviceDesecho;
    	private readonly IDesCantAppService _serviceDesCant;
    
    	#endregion
    
    	#region Properties
    
    	public Desecho Desecho { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public DesechoCrudViewModel()
        {
            Desecho = new Desecho();
        }
    
        /// <summary>
        /// Create a new instance of Desecho viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceDesCant">Service dependency</param>
        public DesechoCrudViewModel(IDesechoAppService service, IDesCantAppService serviceDesCant) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceDesCant == null)
                throw new ArgumentNullException("serviceDesCant", PresentationResources.exception_WithoutService);
    
            _serviceDesecho = service;
            _serviceDesCant = serviceDesCant;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
