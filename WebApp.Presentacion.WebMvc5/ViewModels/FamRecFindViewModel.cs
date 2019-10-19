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
    
    public partial class FamRecFindViewModel : ViewModelBase<FamRec>
    {
    	#region Fields
            
    	private readonly IFamRecAppService _serviceFamRec;
    	private readonly IRecetaAppService _serviceReceta;
    
    	#endregion
    
    	#region Properties
    
    	public FamRecFindModel FamRec { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public FamRecFindViewModel()
        {
            FamRec = new FamRecFindModel();
        }
    
        /// <summary>
        /// Create a new instance of FamRec viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceReceta">Service dependency</param>
        public FamRecFindViewModel(IFamRecAppService service, IRecetaAppService serviceReceta) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceReceta == null)
                throw new ArgumentNullException("serviceReceta", PresentationResources.exception_WithoutService);
    
            _serviceFamRec = service;
            _serviceReceta = serviceReceta;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
