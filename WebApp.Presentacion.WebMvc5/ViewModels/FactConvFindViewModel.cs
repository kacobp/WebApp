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
    
    public partial class FactConvFindViewModel : ViewModelBase<FactConv>
    {
    	#region Fields
            
    	private readonly IFactConvAppService _serviceFactConv;
    	private readonly IAlimAppService _serviceAlim;
    	private readonly IMedidaAppService _serviceMedida;
    
    	#endregion
    
    	#region Properties
    
    	public FactConvFindModel FactConv { get; set; }
    	public List<SelectListItem> Alims { get; set; }
    	public List<SelectListItem> Medidas { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public FactConvFindViewModel()
        {
            FactConv = new FactConvFindModel();
        }
    
        /// <summary>
        /// Create a new instance of FactConv viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
    	/// <param name="serviceMedida">Service dependency</param>
        public FactConvFindViewModel(IFactConvAppService service, IAlimAppService serviceAlim, IMedidaAppService serviceMedida) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    		if (serviceMedida == null)
                throw new ArgumentNullException("serviceMedida", PresentationResources.exception_WithoutService);
    
            _serviceFactConv = service;
            _serviceAlim = serviceAlim;
            _serviceMedida = serviceMedida;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
