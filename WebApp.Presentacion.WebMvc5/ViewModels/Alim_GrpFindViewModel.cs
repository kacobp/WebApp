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
    
    public partial class Alim_GrpFindViewModel : ViewModelBase<Alim_Grp>
    {
    	#region Fields
            
    	private readonly IAlim_GrpAppService _serviceAlim_Grp;
    	private readonly IAlimAppService _serviceAlim;
    
    	#endregion
    
    	#region Properties
    
    	public Alim_GrpFindModel Alim_Grp { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public Alim_GrpFindViewModel()
        {
            Alim_Grp = new Alim_GrpFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Alim_Grp viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
        public Alim_GrpFindViewModel(IAlim_GrpAppService service, IAlimAppService serviceAlim) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
            _serviceAlim_Grp = service;
            _serviceAlim = serviceAlim;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
