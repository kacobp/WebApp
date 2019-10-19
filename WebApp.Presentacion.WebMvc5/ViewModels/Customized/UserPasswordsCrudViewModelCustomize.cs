//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using WebApp.Aplicacion.AppServices;
//using WebApp.Aplicacion.Dtos;
using WebApp.Dominio.Entidades;
using WebApp.Presentacion.WebMvc5.Resources;
using WebApp.Transversales.Caching;
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
    
    public partial class UserPasswordsCrudViewModel
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
    				CacheProvider.Set("Usuarios", Usuarios);
    			}
    			if (CacheProvider.Exist("Passwords"))
    				Passwords = (List<SelectListItem>) CacheProvider.Get("Passwords");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Passwords = _servicePassword.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Password1), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Passwords", Passwords);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMUserPasswords ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
