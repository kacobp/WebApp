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
    
    public partial class Nt_CantFindViewModel : ViewModelBase<Nt_Cant>
    {
    	#region Fields
            
    	private readonly INt_CantAppService _serviceNt_Cant;
    	private readonly IAlimAppService _serviceAlim;
    	private readonly INutrienteAppService _serviceNutriente;
    	private readonly INt_FuenteAppService _serviceNt_Fuente;
    
    	#endregion
    
    	#region Properties
    
    	public Nt_CantFindModel Nt_Cant { get; set; }
    	public List<SelectListItem> Alims { get; set; }
    	public List<SelectListItem> Nt_Fuentes { get; set; }
    	public List<SelectListItem> Nutrientes { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Nt_CantFindViewModel()
        {
            Nt_Cant = new Nt_CantFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Nt_Cant viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
    	/// <param name="serviceNutriente">Service dependency</param>
    	/// <param name="serviceNt_Fuente">Service dependency</param>
        public Nt_CantFindViewModel(INt_CantAppService service, IAlimAppService serviceAlim, INutrienteAppService serviceNutriente, INt_FuenteAppService serviceNt_Fuente) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    		if (serviceNutriente == null)
                throw new ArgumentNullException("serviceNutriente", PresentationResources.exception_WithoutService);
    		if (serviceNt_Fuente == null)
                throw new ArgumentNullException("serviceNt_Fuente", PresentationResources.exception_WithoutService);
    
            _serviceNt_Cant = service;
            _serviceAlim = serviceAlim;
            _serviceNutriente = serviceNutriente;
            _serviceNt_Fuente = serviceNt_Fuente;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
