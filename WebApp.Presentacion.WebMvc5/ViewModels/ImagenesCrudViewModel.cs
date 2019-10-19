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
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public partial class ImagenesCrudViewModel
    {
        #region Fields

        private readonly IImagenesAppService _serviceImagenes;
    	private readonly IUserPhotosAppService _serviceUserPhotos;
    
    	#endregion
    
    	#region Properties
    
    	public Imagenes Imagenes { get; set; }

        /// <summary>  
        /// Gets or sets Image file.  
        /// </summary>  
        [Required]
        [Display(Name = "Upload File")]
        public HttpPostedFileBase FileAttach { get; set; }
        #endregion

        #region Constructor

        public ImagenesCrudViewModel()
        {
            Imagenes = new Imagenes();
        }
    
        /// <summary>
        /// Create a new instance of Imagenes viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceUserPhotos">Service dependency</param>
        public ImagenesCrudViewModel(IImagenesAppService service, IUserPhotosAppService serviceUserPhotos) : this()
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
