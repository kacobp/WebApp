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
    
    public partial class Nt_Grp_Cant : Entity
    {
        public Nt_Grp_Cant()
        {
            this.Nt_Grp = new HashSet<Nt_Grp>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Nt_Grp> Nt_Grp { get; set; }
    }
}
