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
    
    public partial class Nt_Grp_CantCrudViewModel
    {
    	#region Private Methods
    
    	private void BuildVm()
        {
    		try
            {
    		}
            catch (Exception ex)
            {
    			//LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - InitializeVMNt_Grp_Cant ERROR"), ex);          
            }
        }
    
    	#endregion
    }
}
