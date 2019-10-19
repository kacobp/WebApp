#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlimQuery : QueryObject<Alim>
    {
        #region Metodos
    
        public AlimQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}

        public AlimQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "IdUniMed")
                    {
                        int value=Convert.ToInt32(rule.value);
                        And(x => x.IdUniMed == value);
                    }
                    if (rule.field == "IdAlimGrp")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdAlimGrp == value);
                    }
                    if (rule.field == "IdAlimFte")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdAlimFte == value);
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
