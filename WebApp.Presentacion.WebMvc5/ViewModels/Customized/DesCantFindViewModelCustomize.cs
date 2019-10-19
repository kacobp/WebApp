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
    
    public partial class DesCantFindViewModel
    {
    	#region Private Methods
    
    	private void BuildVm()
        {
    		try
            {
    			if (CacheProvider.Exist("Alims"))
    				Alims = (List<SelectListItem>) CacheProvider.Get("Alims");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Alims = _serviceAlim.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				Alims.Insert(0, new SelectListItem { Text = string.Empty, Value = string.Empty });
    				CacheProvider.Set("Alims", Alims);
    			}
    			if (CacheProvider.Exist("Desechos"))
    				Desechos = (List<SelectListItem>) CacheProvider.Get("Desechos");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Desechos = _serviceDesecho.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				Desechos.Insert(0, new SelectListItem { Text = string.Empty, Value = string.Empty });
    				CacheProvider.Set("Desechos", Desechos);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMDesCant ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
