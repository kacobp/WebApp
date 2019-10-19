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
    
    public partial class PasswordCrudViewModel
    {
    	#region Fields
        
    	private readonly IPasswordAppService _servicePassword;
    	private readonly IUserPasswordsAppService _serviceUserPasswords;
    
    	#endregion
    
    	#region Properties
    
    	public Password Password { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public PasswordCrudViewModel()
        {
            Password = new Password();
        }
    
        /// <summary>
        /// Create a new instance of Password viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceUserPasswords">Service dependency</param>
        public PasswordCrudViewModel(IPasswordAppService service, IUserPasswordsAppService serviceUserPasswords) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceUserPasswords == null)
                throw new ArgumentNullException("serviceUserPasswords", PresentationResources.exception_WithoutService);
    
            _servicePassword = service;
            _serviceUserPasswords = serviceUserPasswords;
    	
    		BuildVm();
        }
    
    	#endregion
    }
}
