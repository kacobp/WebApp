#region

using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
using WebApp.Transversales.Extensions;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecProdQuery : QueryObject<RecProd>
    {
        #region Metodos
    
        public RecProdQuery WithAnySearch(string search)
    	{
                if (!string.IsNullOrEmpty(search))
                    And (x => x.Id.ToString().Contains(search));
                return this;	
    	}
    
        public RecProdQuery Withfilter(IEnumerable<filterRule> filters)
        {
            if (filters != null)
            {
                foreach (var rule in filters)
                {
                    if (rule.field == "Id")
                    {
                        And(x => x.Id == Convert.ToInt32(rule.value));
                    }
                    if (rule.field == "IdReceta")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdReceta == value);
                    }
                    if (rule.field == "IdProducto")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdProducto == value);
                    }
                    if (rule.field == "IdProveedor")
                    {
                        int value = Convert.ToInt32(rule.value);
                        And(x => x.IdProveedor == value);
                    }
                    if (rule.field == "Gramos")
                    {
                        And(x => x.Gramos == Convert.ToDecimal(rule.value));
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
