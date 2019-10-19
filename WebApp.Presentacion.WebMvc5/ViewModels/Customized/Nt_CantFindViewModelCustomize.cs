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
    
    public partial class Nt_CantFindViewModel
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
    			if (CacheProvider.Exist("Nt_Fuentes"))
    				Nt_Fuentes = (List<SelectListItem>) CacheProvider.Get("Nt_Fuentes");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Nt_Fuentes = _serviceNt_Fuente.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				Nt_Fuentes.Insert(0, new SelectListItem { Text = string.Empty, Value = string.Empty });
    				CacheProvider.Set("Nt_Fuentes", Nt_Fuentes);
    			}
    			if (CacheProvider.Exist("Nutrientes"))
    				Nutrientes = (List<SelectListItem>) CacheProvider.Get("Nutrientes");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Nutrientes = _serviceNutriente.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				Nutrientes.Insert(0, new SelectListItem { Text = string.Empty, Value = string.Empty });
    				CacheProvider.Set("Nutrientes", Nutrientes);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMNt_Cant ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
