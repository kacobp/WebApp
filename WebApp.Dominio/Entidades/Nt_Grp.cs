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
    
    public partial class Nt_Grp : Entity
    {
        public Nt_Grp()
        {
            this.Nutriente = new HashSet<Nutriente>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> IdGrpCantNT { get; set; }
    
        public virtual Nt_Grp_Cant Nt_Grp_Cant { get; set; }
        public virtual ICollection<Nutriente> Nutriente { get; set; }
    }
}
