//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

//using WebApp.Aplicacion.Dtos;
using WebApp.Aplicacion.Resx;
using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
//using WebApp.Transversales.Framework;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.IO;

#endregion

namespace WebApp.Presentacion.WebMvc5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImagenesFindModel : Entity
    {
        byte[] bytes;

        [Display(ResourceType = typeof(ApplicationResources), Name = "ImagenesId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "ImagenesImagen")]
        [Column(TypeName = "image")]
        public byte[] Imagen
        { get
            { return _imagen; }
            set
                { if (!Equals(value, _imagen))
                    { _imagen = value; }
                }
        }
    	private byte[] _imagen;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "ImagenesNomArchivo")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string NomArchivo { get { return _nomArchivo; } set { if (!Equals(value, _nomArchivo)) { _nomArchivo = value; } } }
    	private string _nomArchivo;
    
    
    
        public virtual IEnumerable<UserPhotos> UserPhotos { get { return _userPhotos; } set { if (!Equals(value, _userPhotos)) { _userPhotos = value; } } }
    	private IEnumerable<UserPhotos> _userPhotos;
    
    }
}
