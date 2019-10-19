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
    
    public partial class UsuarioCrudViewModel
    {
    	#region Fields
        
    	private readonly IUsuarioAppService _serviceUsuario;
    	private readonly ILoginAttemptsAppService _serviceLoginAttempts;
    	private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
    	private readonly IUserPasswordsAppService _serviceUserPasswords;
    	private readonly IUserPhotosAppService _serviceUserPhotos;
    
    	#endregion
    
    	#region Properties
    
    	public Usuario Usuario { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public UsuarioCrudViewModel()
        {
            Usuario = new Usuario();
        }
    
        /// <summary>
        /// Create a new instance of Usuario viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceLoginAttempts">Service dependency</param>
    	/// <param name="servicePermisosUsuario">Service dependency</param>
    	/// <param name="serviceUserPasswords">Service dependency</param>
    	/// <param name="serviceUserPhotos">Service dependency</param>
        public UsuarioCrudViewModel(IUsuarioAppService service, ILoginAttemptsAppService serviceLoginAttempts, IPermisosUsuarioAppService servicePermisosUsuario, IUserPasswordsAppService serviceUserPasswords, IUserPhotosAppService serviceUserPhotos) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceLoginAttempts == null)
                throw new ArgumentNullException("serviceLoginAttempts", PresentationResources.exception_WithoutService);
    		if (servicePermisosUsuario == null)
                throw new ArgumentNullException("servicePermisosUsuario", PresentationResources.exception_WithoutService);
    		if (serviceUserPasswords == null)
                throw new ArgumentNullException("serviceUserPasswords", PresentationResources.exception_WithoutService);
    		if (serviceUserPhotos == null)
                throw new ArgumentNullException("serviceUserPhotos", PresentationResources.exception_WithoutService);
    
            _serviceUsuario = service;
            _serviceLoginAttempts = serviceLoginAttempts;
            _servicePermisosUsuario = servicePermisosUsuario;
            _serviceUserPasswords = serviceUserPasswords;
            _serviceUserPhotos = serviceUserPhotos;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
