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
    
    public partial class Log4net : Entity
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Host { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Thread { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
