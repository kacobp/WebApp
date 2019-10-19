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
    
    public partial class Nt_FuenteCrudViewModel
    {
    	#region Fields
        
    	private readonly INt_FuenteAppService _serviceNt_Fuente;
    	private readonly INt_CantAppService _serviceNt_Cant;
    
    	#endregion
    
    	#region Properties
    
    	public Nt_Fuente Nt_Fuente { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Nt_FuenteCrudViewModel()
        {
            Nt_Fuente = new Nt_Fuente();
        }
    
        /// <summary>
        /// Create a new instance of Nt_Fuente viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceNt_Cant">Service dependency</param>
        public Nt_FuenteCrudViewModel(INt_FuenteAppService service, INt_CantAppService serviceNt_Cant) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceNt_Cant == null)
                throw new ArgumentNullException("serviceNt_Cant", PresentationResources.exception_WithoutService);
    
            _serviceNt_Fuente = service;
            _serviceNt_Cant = serviceNt_Cant;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
