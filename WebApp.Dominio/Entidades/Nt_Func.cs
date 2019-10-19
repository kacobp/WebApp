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
    
    public partial class Nt_Func : Entity
    {
        public Nt_Func()
        {
            this.Nutriente = new HashSet<Nutriente>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Nutriente> Nutriente { get; set; }
    }
}
