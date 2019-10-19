#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nt_CantQuery : QueryObject<Nt_Cant>
    {
        #region Metodos
    
        public Nt_CantQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public Nt_CantQuery Withfilter(IEnumerable<filterRule> filters)
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
                    if (rule.field == "IdNtFte")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdNtFte == value);
                    }
                    if (rule.field == "IdNut")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdNut == value);
                    }
                    if (rule.field == "Valor")
                    {
                        And(x => x.Valor == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "ErrorEstandar")
                    {
                        And(x => x.ErrorEstandar == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "NumObs")
                    {
                        And(x => x.NumObs == Convert.ToInt32(rule.value));
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
