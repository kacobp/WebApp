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
    
    public partial class Nt_FuncCrudViewModel
    {
    	#region Fields
        
    	private readonly INt_FuncAppService _serviceNt_Func;
    	private readonly INutrienteAppService _serviceNutriente;
    
    	#endregion
    
    	#region Properties
    
    	public Nt_Func Nt_Func { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Nt_FuncCrudViewModel()
        {
            Nt_Func = new Nt_Func();
        }
    
        /// <summary>
        /// Create a new instance of Nt_Func viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceNutriente">Service dependency</param>
        public Nt_FuncCrudViewModel(INt_FuncAppService service, INutrienteAppService serviceNutriente) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceNutriente == null)
                throw new ArgumentNullException("serviceNutriente", PresentationResources.exception_WithoutService);
    
            _serviceNt_Func = service;
            _serviceNutriente = serviceNutriente;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
