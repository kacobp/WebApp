//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using WebApp.Aplicacion.Resx;
using WebApp.Datos.Core;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#endregion

namespace WebApp.Aplicacion.Dtos
{
    using System;
    using System.Collections.Generic;
    
    [DataContract(IsReference = true)]
    [KnownType(typeof(Photo))]
    [KnownType(typeof(Usuario))]
    public partial class UserPhotos : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPhotosId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPhotosIdUsuario")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private int _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPhotosIdPhoto")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdPhoto { get { return _idPhoto; } set { if (!Equals(value, _idPhoto)) { _idPhoto = value; } } }
    	private int _idPhoto;
    
    
    	[DataMember]
        public virtual Photo Photo { get { return _photo; } set { if (!Equals(value, _photo)) { _photo = value; } } }
    	private Photo _photo;
    
    	[DataMember]
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
