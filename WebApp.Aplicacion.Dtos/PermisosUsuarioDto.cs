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
    [KnownType(typeof(RolUsuario))]
    [KnownType(typeof(Usuario))]
    public partial class PermisosUsuario : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioIdUsuario")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private int _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioIdRol")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdRol { get { return _idRol; } set { if (!Equals(value, _idRol)) { _idRol = value; } } }
    	private int _idRol;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioFechaInicio")]
    	[DataMember]
        public Nullable<System.DateTime> FechaInicio { get { return _fechaInicio; } set { if (!Equals(value, _fechaInicio)) { _fechaInicio = value; } } }
    	private Nullable<System.DateTime> _fechaInicio;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioFechaTermino")]
    	[DataMember]
        public Nullable<System.DateTime> FechaTermino { get { return _fechaTermino; } set { if (!Equals(value, _fechaTermino)) { _fechaTermino = value; } } }
    	private Nullable<System.DateTime> _fechaTermino;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioCreatedBy")]
    	[DataMember]
        public Nullable<int> CreatedBy { get { return _createdBy; } set { if (!Equals(value, _createdBy)) { _createdBy = value; } } }
    	private Nullable<int> _createdBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioCreatedDate")]
    	[DataMember]
        public Nullable<System.DateTime> CreatedDate { get { return _createdDate; } set { if (!Equals(value, _createdDate)) { _createdDate = value; } } }
    	private Nullable<System.DateTime> _createdDate;
    
    
    	[DataMember]
        public virtual RolUsuario RolUsuario { get { return _rolUsuario; } set { if (!Equals(value, _rolUsuario)) { _rolUsuario = value; } } }
    	private RolUsuario _rolUsuario;
    
    	[DataMember]
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
