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
    
    public partial class Nutriente : Entity
    {
        public Nutriente()
        {
            this.Nt_Cant = new HashSet<Nt_Cant>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Codigo { get; set; }
        public string Simbolo { get; set; }
        public string Nombre { get; set; }
        public string Tag { get; set; }
        public Nullable<decimal> Decimales { get; set; }
        public Nullable<int> IdUniMed { get; set; }
        public Nullable<int> IdFuncNT { get; set; }
        public Nullable<int> IdGrpNT { get; set; }
        public int esEsencial { get; set; }
    
        public virtual ICollection<Nt_Cant> Nt_Cant { get; set; }
        public virtual Nt_Func Nt_Func { get; set; }
        public virtual Nt_Grp Nt_Grp { get; set; }
    }
}
