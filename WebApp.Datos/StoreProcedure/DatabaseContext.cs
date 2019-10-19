#region

using WebApp.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

#endregion

namespace WebApp.Datos.DataModel
{
    public partial class DatabaseContext : IDatabaseStoredProcedures
{
        #region Methods


        public IEnumerable<InfoNutriFindByIdProducto> Usp_InfoNutri_FindBy_IdProducto(int? idProducto)
        {

            var idProductoParameter = idProducto != null ?
                      new SqlParameter("@idProducto", idProducto) :
                      new SqlParameter("@idProducto", typeof(int));

            return Database.SqlQuery<InfoNutriFindByIdProducto>("Usp_InfoNutri_FindBy_IdProducto @IdProducto", idProductoParameter);

        }


        #endregion
    }
}