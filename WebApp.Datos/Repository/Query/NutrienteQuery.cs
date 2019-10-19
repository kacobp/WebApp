#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class NutrienteQuery : QueryObject<Nutriente>
    {
        #region Metodos
    
        public NutrienteQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public NutrienteQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "Codigo")
                    {
                        And(x => x.Codigo == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "Simbolo")
                    {
                        And(x => x.Simbolo == rule.value);
                    }
                    if (rule.field == "Nombre")
                    {
                        And(x => x.Nombre == rule.value);
                    }
                    if (rule.field == "Tag")
                    {
                        And(x => x.Tag == rule.value);
                    }
                    if (rule.field == "Decimales")
                    {
                        And(x => x.Decimales == Convert.ToDecimal(rule.value));
                    }
                    if (rule.field == "IdUniMed")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdUniMed == value);
                    }
                    if (rule.field == "IdFuncNT")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdFuncNT == value);
                    }
                    if (rule.field == "IdGrpNT")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdGrpNT == value);
                    }
                    if (rule.field == "esEsencial")
                    {
                        And(x => x.esEsencial == Convert.ToInt32(rule.value));
                    }
                }
            }
            return this;
        }
    
        #endregion
    }
}
