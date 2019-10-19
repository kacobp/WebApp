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
    
    public partial class RolUsuario : Entity
    {
        public RolUsuario()
        {
            this.PermisosUsuario = new HashSet<PermisosUsuario>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nota { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual ICollection<PermisosUsuario> PermisosUsuario { get; set; }
    }
}
