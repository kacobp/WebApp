#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class UniMedQuery : QueryObject<UniMed>
    {
        #region Metodos
    
        public UniMedQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public UniMedQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "Nombre")
                    {
                        And(x => x.Nombre == rule.value);
                    }
                    if (rule.field == "Descripcion")
                    {
                        And(x => x.Descripcion == rule.value);
                    }
                    if (rule.field == "CodUMed")
                    {
                        And(x => x.CodUMed == rule.value);
                    }
                }
            }
            return this;
        }
    
        #endregion
    }
}
