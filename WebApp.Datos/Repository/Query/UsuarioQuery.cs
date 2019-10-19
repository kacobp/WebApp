#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioQuery : QueryObject<Usuario>
    {
        #region Metodos


        public UsuarioQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public UsuarioQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "SupervisorUserID")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.SupervisorUserID == value);
                    }
                    if (rule.field == "AccountName")
                    {
                        And(x => x.AccountName == rule.value);
                    }
                    if (rule.field == "Photo")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "LanguageId")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.LanguageId == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "UserNote")
                    {
                        And(x => x.UserNote == rule.value);
                    }
                    if (rule.field == "Activo")
                    {
                        And(x => x.Activo == Convert.ToBoolean(rule.value));
                    }
                    if (rule.field == "CreatedBy")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.CreatedBy == value);
                    }
                    if (rule.field == "CreatedDate")
                    {
                        And(x => x.CreatedDate == Convert.ToDateTime(rule.value));
                    }
                    if (rule.field == "ModifiedBy")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.ModifiedBy == value);
                    }
                    if (rule.field == "ModifiedDate")
                    {
                        And(x => x.ModifiedDate == Convert.ToDateTime(rule.value));
                    }
                }
            }
            return this;
        }
    
        #endregion
    }
}
