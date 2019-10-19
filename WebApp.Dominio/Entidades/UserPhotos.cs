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
    
    public partial class UserPhotos : Entity
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdImagen { get; set; }
    
        public virtual Imagenes Imagenes { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
