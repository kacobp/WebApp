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
    
    public partial class Receta : Entity
    {
        public Receta()
        {
            this.RecProd = new HashSet<RecProd>();
        }
    
        public int Id { get; set; }
        public int IdFamRec { get; set; }
        public Nullable<int> IdRecetaBase { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public Nullable<int> Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public string Preparacion { get; set; }
        public Nullable<int> IdFoto { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual FamRec FamRec { get; set; }
        public virtual ICollection<RecProd> RecProd { get; set; }
    }
}
