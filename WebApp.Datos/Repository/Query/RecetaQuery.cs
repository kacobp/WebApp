#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecetaQuery : QueryObject<Receta>
    {
        #region Metodos
    
        public RecetaQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public RecetaQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "IdFamRec")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdFamRec == value);
                    }
                    if (rule.field == "IdRecetaBase")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdRecetaBase == value);
                    }
                    if (rule.field == "Nombre")
                    {
                        And(x => x.Nombre == rule.value);
                    }
                    if (rule.field == "Alias")
                    {
                        And(x => x.Alias == rule.value);
                    }
                    if (rule.field == "Ubicacion")
                    {
                        And(x => x.Ubicacion == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "Descripcion")
                    {
                        And(x => x.Descripcion == rule.value);
                    }
                    if (rule.field == "Preparacion")
                    {
                        And(x => x.Preparacion == rule.value);
                    }
                    if (rule.field == "IdFoto")
                    {
                        And(x => x.IdFoto == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "IdEstado")
                    {
                        And(x => x.IdEstado == Convert.ToInt32(rule.value));
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
