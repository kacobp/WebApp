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
    
    public partial class FamRec : Entity
    {
        public FamRec()
        {
            this.Receta = new HashSet<Receta>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Base { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
