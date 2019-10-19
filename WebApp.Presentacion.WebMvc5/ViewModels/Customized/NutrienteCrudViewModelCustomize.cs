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
    
    public partial class NutrienteCrudViewModel
    {
    	#region Private Methods
    
    	private void BuildVm()
        {
    		try
            {
    			if (CacheProvider.Exist("Nt_Funcs"))
    				Nt_Funcs = (List<SelectListItem>) CacheProvider.Get("Nt_Funcs");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Nt_Funcs = _serviceNt_Func.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Nt_Funcs", Nt_Funcs);
    			}
    			if (CacheProvider.Exist("Nt_Grps"))
    				Nt_Grps = (List<SelectListItem>) CacheProvider.Get("Nt_Grps");
    			else
    			{
    				// TODO: Modify TEXT (SelectList)
    				Nt_Grps = _serviceNt_Grp.GetAll(null, null).Select(x => new SelectListItem { Text = Convert.ToString(x.Nombre), Value = Convert.ToString(x.Id) }).ToList();
    				CacheProvider.Set("Nt_Grps", Nt_Grps);
    			}
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMNutriente ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
