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
    
    public partial class UniMedCrudViewModel
    {
    	#region Fields
        
    	private readonly IUniMedAppService _serviceUniMed;
    	private readonly IAlimAppService _serviceAlim;
    
    	#endregion
    
    	#region Properties
    
    	public UniMed UniMed { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public UniMedCrudViewModel()
        {
            UniMed = new UniMed();
        }
    
        /// <summary>
        /// Create a new instance of UniMed viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
        public UniMedCrudViewModel(IUniMedAppService service, IAlimAppService serviceAlim) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
            _serviceUniMed = service;
            _serviceAlim = serviceAlim;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
