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
    
    public partial class PermisosUsuarioFindViewModel : ViewModelBase<PermisosUsuario>
    {
    	#region Fields
            
    	private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
    	private readonly IRolUsuarioAppService _serviceRolUsuario;
    	private readonly IUsuarioAppService _serviceUsuario;
    
    	#endregion
    
    	#region Properties
    
    	public PermisosUsuarioFindModel PermisosUsuario { get; set; }
    	public List<SelectListItem> Usuarios { get; set; }
    	public List<SelectListItem> RolUsuarios { get; set; }
    
        #endregion
    
    	#region Constructor
    
    	public PermisosUsuarioFindViewModel()
        {
            PermisosUsuario = new PermisosUsuarioFindModel();
        }
    
        /// <summary>
        /// Create a new instance of PermisosUsuario viewmodel
        /// </summary>
        /// <param name="service">Service dependency</param>
    	/// <param name="serviceRolUsuario">Service dependency</param>
    	/// <param name="serviceUsuario">Service dependency</param>
        public PermisosUsuarioFindViewModel(IPermisosUsuarioAppService service, IRolUsuarioAppService serviceRolUsuario, IUsuarioAppService serviceUsuario) : this()
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    		if (serviceRolUsuario == null)
                throw new ArgumentNullException("serviceRolUsuario", PresentationResources.exception_WithoutService);
    		if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
            _servicePermisosUsuario = service;
            _serviceRolUsuario = serviceRolUsuario;
            _serviceUsuario = serviceUsuario;
    
    		BuildVm();
        }
    
    	#endregion
    }
}
