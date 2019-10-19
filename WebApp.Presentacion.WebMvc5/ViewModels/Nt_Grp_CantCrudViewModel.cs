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
    
    public partial class Nt_Grp_CantCrudViewModel
    {
    	#region Fields
        
    	private readonly INt_Grp_CantAppService _serviceNt_Grp_Cant;
    	private readonly INt_GrpAppService _serviceNt_Grp;
    
    	#endregion
    
    	#region Properties
    
    	public Nt_Grp_Cant Nt_Grp_Cant { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Nt_Grp_CantCrudViewModel()
        {
            Nt_Grp_Cant = new Nt_Grp_Cant();
        }
    
        /// <summary>
        /// Create a new instance of Nt_Grp_Cant viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceNt_Grp">Service dependency</param>
        public Nt_Grp_CantCrudViewModel(INt_Grp_CantAppService service, INt_GrpAppService serviceNt_Grp) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceNt_Grp == null)
                throw new ArgumentNullException("serviceNt_Grp", PresentationResources.exception_WithoutService);
    
            _serviceNt_Grp_Cant = service;
            _serviceNt_Grp = serviceNt_Grp;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
