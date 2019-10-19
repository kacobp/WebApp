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
    
    public partial class LoginAttemptsCrudViewModel
    {
    	#region Fields
        
    	private readonly ILoginAttemptsAppService _serviceLoginAttempts;
    	private readonly IUsuarioAppService _serviceUsuario;
    
    	#endregion
    
    	#region Properties
    
    	public LoginAttempts LoginAttempts { get; set; }
    	public List<SelectListItem> Usuarios { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public LoginAttemptsCrudViewModel()
        {
            LoginAttempts = new LoginAttempts();
        }
    
        /// <summary>
        /// Create a new instance of LoginAttempts viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceUsuario">Service dependency</param>
        public LoginAttemptsCrudViewModel(ILoginAttemptsAppService service, IUsuarioAppService serviceUsuario) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
            _serviceLoginAttempts = service;
            _serviceUsuario = serviceUsuario;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
