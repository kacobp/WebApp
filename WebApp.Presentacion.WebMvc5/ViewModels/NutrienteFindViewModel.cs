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
    
    public partial class NutrienteFindViewModel : ViewModelBase<Nutriente>
    {
    	#region Fields
            
    	private readonly INutrienteAppService _serviceNutriente;
    	private readonly INt_CantAppService _serviceNt_Cant;
    	private readonly INt_FuncAppService _serviceNt_Func;
    	private readonly INt_GrpAppService _serviceNt_Grp;
    
    	#endregion
    
    	#region Properties
    
    	public NutrienteFindModel Nutriente { get; set; }
    	public List<SelectListItem> Nt_Funcs { get; set; }
    	public List<SelectListItem> Nt_Grps { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public NutrienteFindViewModel()
        {
            Nutriente = new NutrienteFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Nutriente viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceNt_Cant">Service dependency</param>
    	/// <param name="serviceNt_Func">Service dependency</param>
    	/// <param name="serviceNt_Grp">Service dependency</param>
        public NutrienteFindViewModel(INutrienteAppService service, INt_CantAppService serviceNt_Cant, INt_FuncAppService serviceNt_Func, INt_GrpAppService serviceNt_Grp) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceNt_Cant == null)
                throw new ArgumentNullException("serviceNt_Cant", PresentationResources.exception_WithoutService);
    		if (serviceNt_Func == null)
                throw new ArgumentNullException("serviceNt_Func", PresentationResources.exception_WithoutService);
    		if (serviceNt_Grp == null)
                throw new ArgumentNullException("serviceNt_Grp", PresentationResources.exception_WithoutService);
    
            _serviceNutriente = service;
            _serviceNt_Cant = serviceNt_Cant;
            _serviceNt_Func = serviceNt_Func;
            _serviceNt_Grp = serviceNt_Grp;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
