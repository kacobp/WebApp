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
    
    public partial class Alim : Entity
    {
        public Alim()
        {
            this.FactConv = new HashSet<FactConv>();
            this.Nt_Cant = new HashSet<Nt_Cant>();
            this.RecProd = new HashSet<RecProd>();
            this.DesCant = new HashSet<DesCant>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<decimal> FactorRendimiento { get; set; }
        public Nullable<decimal> FactorDescuento { get; set; }
        public Nullable<int> Fraccionado { get; set; }
        public Nullable<int> ConversionInyectado { get; set; }
        public Nullable<decimal> FactorConversion { get; set; }
        public Nullable<int> Inactivo { get; set; }
        public string NomAbreviado { get; set; }
        public string NomCientifico { get; set; }
        public int esAlimento { get; set; }
        public Nullable<decimal> NT_MedidaBase { get; set; }
        public int IdUniMed { get; set; }
        public Nullable<int> IdAlimGrp { get; set; }
        public Nullable<int> IdAlimFte { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual ICollection<FactConv> FactConv { get; set; }
        public virtual ICollection<Nt_Cant> Nt_Cant { get; set; }
        public virtual Alim_Grp Alim_Grp { get; set; }
        public virtual Alim_Fuente Alim_Fuente { get; set; }
        public virtual UniMed UniMed { get; set; }
        public virtual ICollection<RecProd> RecProd { get; set; }
        public virtual ICollection<DesCant> DesCant { get; set; }
        public virtual RendCant RendCant { get; set; }
    }
}
