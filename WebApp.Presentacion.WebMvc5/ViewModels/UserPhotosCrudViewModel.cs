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
    
    public partial class UserPhotosCrudViewModel
    {
    	#region Fields
        
    	private readonly IUserPhotosAppService _serviceUserPhotos;
    	private readonly IImagenesAppService _serviceImagenes;
    	private readonly IUsuarioAppService _serviceUsuario;
    
    	#endregion
    
    	#region Properties
    
    	public UserPhotos UserPhotos { get; set; }
    	public List<SelectListItem> Usuarios { get; set; }
    	public List<SelectListItem> Imageness { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public UserPhotosCrudViewModel()
        {
            UserPhotos = new UserPhotos();
        }
    
        /// <summary>
        /// Create a new instance of UserPhotos viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceImagenes">Service dependency</param>
    	/// <param name="serviceUsuario">Service dependency</param>
        public UserPhotosCrudViewModel(IUserPhotosAppService service, IImagenesAppService serviceImagenes, IUsuarioAppService serviceUsuario) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceImagenes == null)
                throw new ArgumentNullException("serviceImagenes", PresentationResources.exception_WithoutService);
    		if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
            _serviceUserPhotos = service;
            _serviceImagenes = serviceImagenes;
            _serviceUsuario = serviceUsuario;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
