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
    
    public partial class RecProdFindViewModel : ViewModelBase<RecProd>
    {
    	#region Fields
            
    	private readonly IRecProdAppService _serviceRecProd;
    	private readonly IAlimAppService _serviceAlim;
    	private readonly IRecetaAppService _serviceReceta;
    
    	#endregion
    
    	#region Properties
    
    	public RecProdFindModel RecProd { get; set; }
    	public List<SelectListItem> Recetas { get; set; }
    	public List<SelectListItem> Alims { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RecProdFindViewModel()
        {
            RecProd = new RecProdFindModel();
        }
    
        /// <summary>
        /// Create a new instance of RecProd viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
    	/// <param name="serviceReceta">Service dependency</param>
        public RecProdFindViewModel(IRecProdAppService service, IAlimAppService serviceAlim, IRecetaAppService serviceReceta) : this()
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
