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
    
    public partial class Nt_GrpCrudViewModel
    {
    	#region Fields
        
    	private readonly INt_GrpAppService _serviceNt_Grp;
    	private readonly INt_Grp_CantAppService _serviceNt_Grp_Cant;
    	private readonly INutrienteAppService _serviceNutriente;
    
    	#endregion
    
    	#region Properties
    
    	public Nt_Grp Nt_Grp { get; set; }
    	public List<SelectListItem> Nt_Grp_Cants { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Nt_GrpCrudViewModel()
        {
            Nt_Grp = new Nt_Grp();
        }
    
        /// <summary>
        /// Create a new instance of Nt_Grp viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceNt_Grp_Cant">Service dependency</param>
    	/// <param name="serviceNutriente">Service dependency</param>
        public Nt_GrpCrudViewModel(INt_GrpAppService service, INt_Grp_CantAppService serviceNt_Grp_Cant, INutrienteAppService serviceNutriente) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceNt_Grp_Cant == null)
                throw new ArgumentNullException("serviceNt_Grp_Cant", PresentationResources.exception_WithoutService);
    		if (serviceNutriente == null)
                throw new ArgumentNullException("serviceNutriente", PresentationResources.exception_WithoutService);
    
            _serviceNt_Grp = service;
            _serviceNt_Grp_Cant = serviceNt_Grp_Cant;
            _serviceNutriente = serviceNutriente;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
