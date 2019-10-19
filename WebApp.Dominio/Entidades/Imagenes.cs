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
    
    public partial class Imagenes : Entity
    {
        public Imagenes()
        {
            this.UserPhotos = new HashSet<UserPhotos>();
        }
    
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string NomArchivo { get; set; }
    
        public virtual ICollection<UserPhotos> UserPhotos { get; set; }
    }
}
