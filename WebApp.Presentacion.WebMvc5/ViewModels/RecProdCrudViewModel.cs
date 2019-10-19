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
    
    public partial class RecProdCrudViewModel
    {
    	#region Fields
        
    	private readonly IRecProdAppService _serviceRecProd;
    	private readonly IAlimAppService _serviceAlim;
    	private readonly IRecetaAppService _serviceReceta;
    
    	#endregion
    
    	#region Properties
    
    	public RecProd RecProd { get; set; }
    	public List<SelectListItem> Recetas { get; set; }
    	public List<SelectListItem> Alims { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RecProdCrudViewModel()
        {
            RecProd = new RecProd();
        }
    
        /// <summary>
        /// Create a new instance of RecProd viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
    	/// <param name="serviceReceta">Service dependency</param>
        public RecProdCrudViewModel(IRecProdAppService service, IAlimAppService serviceAlim, IRecetaAppService serviceReceta) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    		if (serviceReceta == null)
                throw new ArgumentNullException("serviceReceta", PresentationResources.exception_WithoutService);
    
            _serviceRecProd = service;
            _serviceAlim = serviceAlim;
            _serviceReceta = serviceReceta;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
