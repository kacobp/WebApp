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
    
    public partial class AlimCrudViewModel
    {
    	#region Private Methods
    
    	private void BuildVm()
        {
    		try
            {
    			if (CacheProvider.Exist("UniMeds"))
    				UniMeds = (List<SelectListItem>) CacheProvider.Get("UniMeds");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				UniMeds = _serviceUniMed.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Descripcion), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("UniMeds", UniMeds);
    			}
    			if (CacheProvider.Exist("Alim_Grps"))
    				Alim_Grps = (List<SelectListItem>) CacheProvider.Get("Alim_Grps");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Alim_Grps = _serviceAlim_Grp.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Alim_Grps", Alim_Grps);
    			}
    			if (CacheProvider.Exist("Alim_Fuentes"))
    				Alim_Fuentes = (List<SelectListItem>) CacheProvider.Get("Alim_Fuentes");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Alim_Fuentes = _serviceAlim_Fuente.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Alim_Fuentes", Alim_Fuentes);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMAlim ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
