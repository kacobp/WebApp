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
    
    public partial class Nt_Cant : Entity
    {
        public int Id { get; set; }
        public int IdAlim { get; set; }
        public Nullable<int> IdNtFte { get; set; }
        public int IdNut { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public Nullable<int> ErrorEstandar { get; set; }
        public Nullable<int> NumObs { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual Alim Alim { get; set; }
        public virtual Nutriente Nutriente { get; set; }
        public virtual Nt_Fuente Nt_Fuente { get; set; }
    }
}
