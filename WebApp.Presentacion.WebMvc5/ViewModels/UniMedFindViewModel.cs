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
    
    public partial class UniMedFindViewModel : ViewModelBase<UniMed>
    {
    	#region Fields
            
    	private readonly IUniMedAppService _serviceUniMed;
    	private readonly IAlimAppService _serviceAlim;
    
    	#endregion
    
    	#region Properties
    
    	public UniMedFindModel UniMed { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public UniMedFindViewModel()
        {
            UniMed = new UniMedFindModel();
        }
    
        /// <summary>
        /// Create a new instance of UniMed viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceAlim">Service dependency</param>
        public UniMedFindViewModel(IUniMedAppService service, IAlimAppService serviceAlim) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
            _serviceUniMed = service;
            _serviceAlim = serviceAlim;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
