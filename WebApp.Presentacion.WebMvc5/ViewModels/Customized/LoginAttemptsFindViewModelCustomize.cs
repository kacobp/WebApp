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
    
    public partial class LoginAttemptsFindViewModel
    {
    	#region Private Methods
    
    	private void BuildVm()
        {
    		try
            {
    			if (CacheProvider.Exist("Usuarios"))
    				Usuarios = (List<SelectListItem>) CacheProvider.Get("Usuarios");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Usuarios = _serviceUsuario.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.AccountName), Value = Convert.ToString(x.Id) }).ToList();
    				Usuarios.Insert(0, new SelectListItem { Text = string.Empty, Value = string.Empty });
    				CacheProvider.Set("Usuarios", Usuarios);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMLoginAttempts ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
