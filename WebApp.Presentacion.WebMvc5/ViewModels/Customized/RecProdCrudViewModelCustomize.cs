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
    
    public partial class RecProdCrudViewModel
    {
    	#region Private Methods
    
    	private void BuildVm()
        {
    		try
            {
    			if (CacheProvider.Exist("Recetas"))
    				Recetas = (List<SelectListItem>) CacheProvider.Get("Recetas");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Recetas = _serviceReceta.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Recetas", Recetas);
    			}
    			if (CacheProvider.Exist("Alims"))
    				Alims = (List<SelectListItem>) CacheProvider.Get("Alims");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Alims = _serviceAlim.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Alims", Alims);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMRecProd ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
