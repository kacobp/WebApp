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
    
    public partial class LoginAttempts : Entity
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Password { get; set; }
        public string IPNumber { get; set; }
        public string BrowserType { get; set; }
        public Nullable<bool> Success { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
