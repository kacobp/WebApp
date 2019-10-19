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
    
    public partial class UserPasswords : Entity
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPassword { get; set; }
        public Nullable<bool> ExternalUser { get; set; }
    
        public virtual Password Password { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
