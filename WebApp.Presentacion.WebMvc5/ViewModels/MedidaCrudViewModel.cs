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
    
    public partial class MedidaCrudViewModel
    {
    	#region Fields
        
    	private readonly IMedidaAppService _serviceMedida;
    	private readonly IFactConvAppService _serviceFactConv;
    
    	#endregion
    
    	#region Properties
    
    	public Medida Medida { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public MedidaCrudViewModel()
        {
            Medida = new Medida();
        }
    
        /// <summary>
        /// Create a new instance of Medida viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceFactConv">Service dependency</param>
        public MedidaCrudViewModel(IMedidaAppService service, IFactConvAppService serviceFactConv) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceFactConv == null)
                throw new ArgumentNullException("serviceFactConv", PresentationResources.exception_WithoutService);
    
            _serviceMedida = service;
            _serviceFactConv = serviceFactConv;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
