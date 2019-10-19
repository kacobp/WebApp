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
    
    public partial class Alim_Fuente : Entity
    {
        public Alim_Fuente()
        {
            this.Alim = new HashSet<Alim>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Cod { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Alim> Alim { get; set; }
    }
}
