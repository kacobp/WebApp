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
    
    public partial class RendCantFindViewModel : ViewModelBase<RendCant>
    {
    	#region Fields
            
    	private readonly IRendCantAppService _serviceRendCant;
    	private readonly IAlimAppService _serviceAlim;
    	private readonly IRendAppService _serviceRend;
    
    	#endregion
    
    	#region Properties
    
    	public RendCantFindModel RendCant { get; set; }
    	public List<SelectListItem> Rends { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RendCantFindViewModel()
        {
            RendCant = new RendCantFindModel();
        }
    
        /// <summary>
        /// Create a new instance of RendCant viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
    	/// <param name="serviceRend">Service dependency</param>
        public RendCantFindViewModel(IRendCantAppService service, IAlimAppService serviceAlim, IRendAppService serviceRend) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    		if (serviceRend == null)
                throw new ArgumentNullException("serviceRend", PresentationResources.exception_WithoutService);
    
            _serviceRendCant = service;
            _serviceAlim = serviceAlim;
            _serviceRend = serviceRend;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
