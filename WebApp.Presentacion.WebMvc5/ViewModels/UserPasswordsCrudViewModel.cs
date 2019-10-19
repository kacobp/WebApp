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
    
    public partial class UserPasswordsCrudViewModel
    {
    	#region Fields
        
    	private readonly IUserPasswordsAppService _serviceUserPasswords;
    	private readonly IPasswordAppService _servicePassword;
    	private readonly IUsuarioAppService _serviceUsuario;
    
    	#endregion
    
    	#region Properties
    
    	public UserPasswords UserPasswords { get; set; }
    	public List<SelectListItem> Usuarios { get; set; }
    	public List<SelectListItem> Passwords { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public UserPasswordsCrudViewModel()
        {
            UserPasswords = new UserPasswords();
        }
    
        /// <summary>
        /// Create a new instance of UserPasswords viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="servicePassword">Service dependency</param>
    	/// <param name="serviceUsuario">Service dependency</param>
        public UserPasswordsCrudViewModel(IUserPasswordsAppService service, IPasswordAppService servicePassword, IUsuarioAppService serviceUsuario) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (servicePassword == null)
                throw new ArgumentNullException("servicePassword", PresentationResources.exception_WithoutService);
    		if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
            _serviceUserPasswords = service;
            _servicePassword = servicePassword;
            _serviceUsuario = serviceUsuario;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
