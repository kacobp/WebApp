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
    
    public partial class RolUsuarioFindViewModel : ViewModelBase<RolUsuario>
    {
    	#region Fields
            
    	private readonly IRolUsuarioAppService _serviceRolUsuario;
    	private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
    
    	#endregion
    
    	#region Properties
    
    	public RolUsuarioFindModel RolUsuario { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public RolUsuarioFindViewModel()
        {
            RolUsuario = new RolUsuarioFindModel();
        }
    
        /// <summary>
        /// Create a new instance of RolUsuario viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="servicePermisosUsuario">Service dependency</param>
        public RolUsuarioFindViewModel(IRolUsuarioAppService service, IPermisosUsuarioAppService servicePermisosUsuario) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (servicePermisosUsuario == null)
                throw new ArgumentNullException("servicePermisosUsuario", PresentationResources.exception_WithoutService);
    
            _serviceRolUsuario = service;
            _servicePermisosUsuario = servicePermisosUsuario;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
