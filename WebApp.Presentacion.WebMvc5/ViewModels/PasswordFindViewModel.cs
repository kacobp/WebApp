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
    
    public partial class PasswordFindViewModel : ViewModelBase<Password>
    {
    	#region Fields
            
    	private readonly IPasswordAppService _servicePassword;
    	private readonly IUserPasswordsAppService _serviceUserPasswords;
    
    	#endregion
    
    	#region Properties
    
    	public PasswordFindModel Password { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public PasswordFindViewModel()
        {
            Password = new PasswordFindModel();
        }
    
        /// <summary>
        /// Create a new instance of Password viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceUserPasswords">Service dependency</param>
        public PasswordFindViewModel(IPasswordAppService service, IUserPasswordsAppService serviceUserPasswords) : this()
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
