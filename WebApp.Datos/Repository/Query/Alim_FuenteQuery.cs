#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alim_FuenteQuery : QueryObject<Alim_Fuente>
    {
        #region Metodos
    
        public Alim_FuenteQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public Alim_FuenteQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "Cod")
                    {
                        And(x => x.Cod == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "Nombre")
                    {
                        And(x => x.Nombre.Contains(rule.value));
                    }

                }
            }
            return this;
        }
    
        #endregion
    }
}
