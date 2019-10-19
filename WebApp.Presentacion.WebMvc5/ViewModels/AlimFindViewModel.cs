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
    
    public partial class AlimFindViewModel : ViewModelBase<Alim>
    {
    	#region Fields
            
    	private readonly IAlimAppService _serviceAlim;
    	private readonly IFactConvAppService _serviceFactConv;
    	private readonly INt_CantAppService _serviceNt_Cant;
    	private readonly IAlim_GrpAppService _serviceAlim_Grp;
    	private readonly IAlim_FuenteAppService _serviceAlim_Fuente;
    	private readonly IUniMedAppService _serviceUniMed;
    	private readonly IRecProdAppService _serviceRecProd;
    	private readonly IDesCantAppService _serviceDesCant;
    	private readonly IRendCantAppService _serviceRendCant;
    
    	#endregion
    
    	#region Properties
    
    	public AlimFindModel Alim { get; set; }
    	public List<SelectListItem> UniMeds { get; set; }
    	public List<SelectListItem> Alim_Grps { get; set; }
    	public List<SelectListItem> Alim_Fuentes { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public AlimFindViewModel()
        {
            Alim = new AlimFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Alim viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceFactConv">Service dependency</param>
    	/// <param name="serviceNt_Cant">Service dependency</param>
    	/// <param name="serviceAlim_Grp">Service dependency</param>
    	/// <param name="serviceAlim_Fuente">Service dependency</param>
    	/// <param name="serviceUniMed">Service dependency</param>
    	/// <param name="serviceRecProd">Service dependency</param>
    	/// <param name="serviceDesCant">Service dependency</param>
    	/// <param name="serviceRendCant">Service dependency</param>
        public AlimFindViewModel(IAlimAppService service, IFactConvAppService serviceFactConv, INt_CantAppService serviceNt_Cant, IAlim_GrpAppService serviceAlim_Grp, IAlim_FuenteAppService serviceAlim_Fuente, IUniMedAppService serviceUniMed, IRecProdAppService serviceRecProd, IDesCantAppService serviceDesCant, IRendCantAppService serviceRendCant) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceFactConv == null)
                throw new ArgumentNullException("serviceFactConv", PresentationResources.exception_WithoutService);
    		if (serviceNt_Cant == null)
                throw new ArgumentNullException("serviceNt_Cant", PresentationResources.exception_WithoutService);
    		if (serviceAlim_Grp == null)
                throw new ArgumentNullException("serviceAlim_Grp", PresentationResources.exception_WithoutService);
    		if (serviceAlim_Fuente == null)
                throw new ArgumentNullException("serviceAlim_Fuente", PresentationResources.exception_WithoutService);
    		if (serviceUniMed == null)
                throw new ArgumentNullException("serviceUniMed", PresentationResources.exception_WithoutService);
    		if (serviceRecProd == null)
                throw new ArgumentNullException("serviceRecProd", PresentationResources.exception_WithoutService);
    		if (serviceDesCant == null)
                throw new ArgumentNullException("serviceDesCant", PresentationResources.exception_WithoutService);
    		if (serviceRendCant == null)
                throw new ArgumentNullException("serviceRendCant", PresentationResources.exception_WithoutService);
    
            _serviceAlim = service;
            _serviceFactConv = serviceFactConv;
            _serviceNt_Cant = serviceNt_Cant;
            _serviceAlim_Grp = serviceAlim_Grp;
            _serviceAlim_Fuente = serviceAlim_Fuente;
            _serviceUniMed = serviceUniMed;
            _serviceRecProd = serviceRecProd;
            _serviceDesCant = serviceDesCant;
            _serviceRendCant = serviceRendCant;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
