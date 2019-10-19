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
    
    public partial class RendCant : Entity
    {
        public int Id { get; set; }
        public int IdAlim { get; set; }
        public int IdRend { get; set; }
        public Nullable<decimal> Cantidad { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual Alim Alim { get; set; }
        public virtual Rend Rend { get; set; }
    }
}
