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
    
    public partial class RecetaCrudViewModel
    {
    	#region Fields
        
    	private readonly IRecetaAppService _serviceReceta;
    	private readonly IFamRecAppService _serviceFamRec;
    	private readonly IRecProdAppService _serviceRecProd;
    
    	#endregion
    
    	#region Properties
    
    	public Receta Receta { get; set; }
    	public List<SelectListItem> FamRecs { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RecetaCrudViewModel()
        {
            Receta = new Receta();
        }
    
        /// <summary>
        /// Create a new instance of Receta viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceFamRec">Service dependency</param>
    	/// <param name="serviceRecProd">Service dependency</param>
        public RecetaCrudViewModel(IRecetaAppService service, IFamRecAppService serviceFamRec, IRecProdAppService serviceRecProd) : this()
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
    	
    		//BuildVm();
        }
    
    	#endregion
    }
}
