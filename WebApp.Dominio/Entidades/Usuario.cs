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
    
    public partial class Usuario : Entity
    {
        public Usuario()
        {
            this.LoginAttempts = new HashSet<LoginAttempts>();
            this.PermisosUsuario = new HashSet<PermisosUsuario>();
            this.UserPasswords = new HashSet<UserPasswords>();
            this.UserPhotos = new HashSet<UserPhotos>();
        }
    
        public int Id { get; set; }
        public Nullable<int> SupervisorUserID { get; set; }
        public string AccountName { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<int> LanguageId { get; set; }
        public string UserNote { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual ICollection<LoginAttempts> LoginAttempts { get; set; }
        public virtual ICollection<PermisosUsuario> PermisosUsuario { get; set; }
        public virtual ICollection<UserPasswords> UserPasswords { get; set; }
        public virtual ICollection<UserPhotos> UserPhotos { get; set; }
    }
}
