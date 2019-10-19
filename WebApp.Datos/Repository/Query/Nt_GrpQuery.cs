#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nt_GrpQuery : QueryObject<Nt_Grp>
    {
        #region Metodos
    
        public Nt_GrpQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public Nt_GrpQuery Withfilter(IEnumerable<filterRule> filters)
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
                    if (rule.field == "IdGrpCantNT")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdGrpCantNT == value);
                    }
                }
            }
            return this;
        }
    
        #endregion
    }
}
