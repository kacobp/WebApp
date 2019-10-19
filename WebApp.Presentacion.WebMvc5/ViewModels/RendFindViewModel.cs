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
    
    public partial class RendFindViewModel : ViewModelBase<Rend>
    {
    	#region Fields
            
    	private readonly IRendAppService _serviceRend;
    	private readonly IRendCantAppService _serviceRendCant;
    
    	#endregion
    
    	#region Properties
    
    	public RendFindModel Rend { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RendFindViewModel()
        {
            Rend = new RendFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Rend viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceRendCant">Service dependency</param>
        public RendFindViewModel(IRendAppService service, IRendCantAppService serviceRendCant) : this()
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
