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
    
    public partial class RecetaFindViewModel : ViewModelBase<Receta>
    {
    	#region Fields
            
    	private readonly IRecetaAppService _serviceReceta;
    	private readonly IFamRecAppService _serviceFamRec;
    	private readonly IRecProdAppService _serviceRecProd;
    
    	#endregion
    
    	#region Properties
    
    	public RecetaFindModel Receta { get; set; }
    	public List<SelectListItem> FamRecs { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RecetaFindViewModel()
        {
            Receta = new RecetaFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Receta viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceFamRec">Service dependency</param>
    	/// <param name="serviceRecProd">Service dependency</param>
        public RecetaFindViewModel(IRecetaAppService service, IFamRecAppService serviceFamRec, IRecProdAppService serviceRecProd) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceFamRec == null)
                throw new ArgumentNullException("serviceFamRec", PresentationResources.exception_WithoutService);
    		if (serviceRecProd == null)
                throw new ArgumentNullException("serviceRecProd", PresentationResources.exception_WithoutService);
    
            _serviceReceta = service;
            _serviceFamRec = serviceFamRec;
            _serviceRecProd = serviceRecProd;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
