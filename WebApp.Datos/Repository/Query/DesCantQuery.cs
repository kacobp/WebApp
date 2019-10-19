#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class DesCantQuery : QueryObject<DesCant>
    {
        #region Metodos
    
        public DesCantQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public DesCantQuery Withfilter(IEnumerable<filterRule> filters)
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
                    if (rule.field == "IdDes")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdDes == value);
                    }
                    if (rule.field == "Cantidad")
                    {
                        And(x => x.Cantidad == Convert.ToInt32(rule.value));
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
