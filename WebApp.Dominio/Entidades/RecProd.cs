//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using WebApp.Datos.Core;
using System.ComponentModel.DataAnnotations;

#endregion

namespace WebApp.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class RecProd : Entity
    {
        public int Id { get; set; }
        public int IdReceta { get; set; }
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public decimal Gramos { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual Alim Alim { get; set; }
        public virtual Receta Receta { get; set; }
    }
}
