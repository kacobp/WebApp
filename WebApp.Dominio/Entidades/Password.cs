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
    
    public partial class Password : Entity
    {
        public Password()
        {
            this.UserPasswords = new HashSet<UserPasswords>();
        }
    
        public int Id { get; set; }
        public string Password1 { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordAnswer { get; set; }
        public string PasswordQuestion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public string CreatedByUserID { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        public virtual ICollection<UserPasswords> UserPasswords { get; set; }
    }
}
