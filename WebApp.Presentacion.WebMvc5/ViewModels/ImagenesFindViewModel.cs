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
    
    public partial class ImagenesFindViewModel : ViewModelBase<Imagenes>
    {
    	#region Fields
            
    	private readonly IImagenesAppService _serviceImagenes;
    	private readonly IUserPhotosAppService _serviceUserPhotos;
    
    	#endregion
    
    	#region Properties
    
    	public ImagenesFindModel Imagenes { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public ImagenesFindViewModel()
        {
            Imagenes = new ImagenesFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Imagenes viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceUserPhotos">Service dependency</param>
        public ImagenesFindViewModel(IImagenesAppService service, IUserPhotosAppService serviceUserPhotos) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceUserPhotos == null)
                throw new ArgumentNullException("serviceUserPhotos", PresentationResources.exception_WithoutService);
    
            _serviceImagenes = service;
            _serviceUserPhotos = serviceUserPhotos;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
