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
    
    public partial class Nt_Fuente : Entity
    {
        public Nt_Fuente()
        {
            this.Nt_Cant = new HashSet<Nt_Cant>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Cod { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Nt_Cant> Nt_Cant { get; set; }
    }
}
