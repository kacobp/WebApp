#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class FactConvQuery : QueryObject<FactConv>
    {
        #region Metodos
    
        public FactConvQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public FactConvQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "IdAlim")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdAlim == value);
                    }
                    if (rule.field == "IdMed")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdMed == value);
                    }
                    if (rule.field == "Factor")
                    {
                        And(x => x.Factor == Convert.ToDecimal(rule.value));
                    }
                    if (rule.field == "FechaRegistro")
                    {
                        And(x => x.FechaRegistro == Convert.ToDateTime(rule.value));
                    }
                }
            }
            return this;
        }
    
        #endregion
    }
}
