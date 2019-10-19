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

#endregion

namespace WebApp.Presentacion.WebMvc5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserPhotosFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPhotosId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPhotosIdUsuario")]
        public Nullable<int> IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private Nullable<int> _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPhotosIdImagen")]
        public Nullable<int> IdImagen { get { return _idImagen; } set { if (!Equals(value, _idImagen)) { _idImagen = value; } } }
    	private Nullable<int> _idImagen;
    
    
    
        public virtual Imagenes Imagenes { get { return _imagenes; } set { if (!Equals(value, _imagenes)) { _imagenes = value; } } }
    	private Imagenes _imagenes;
    
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
