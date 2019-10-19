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
    
    public partial class PermisosUsuarioFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioIdUsuario")]
        public Nullable<int> IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private Nullable<int> _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioIdRol")]
        public Nullable<int> IdRol { get { return _idRol; } set { if (!Equals(value, _idRol)) { _idRol = value; } } }
    	private Nullable<int> _idRol;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioFechaInicio")]
        public Nullable<System.DateTime> FechaInicio { get { return _fechaInicio; } set { if (!Equals(value, _fechaInicio)) { _fechaInicio = value; } } }
    	private Nullable<System.DateTime> _fechaInicio;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioFechaTermino")]
        public Nullable<System.DateTime> FechaTermino { get { return _fechaTermino; } set { if (!Equals(value, _fechaTermino)) { _fechaTermino = value; } } }
    	private Nullable<System.DateTime> _fechaTermino;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioCreatedBy")]
        public Nullable<int> CreatedBy { get { return _createdBy; } set { if (!Equals(value, _createdBy)) { _createdBy = value; } } }
    	private Nullable<int> _createdBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PermisosUsuarioCreatedDate")]
        public Nullable<System.DateTime> CreatedDate { get { return _createdDate; } set { if (!Equals(value, _createdDate)) { _createdDate = value; } } }
    	private Nullable<System.DateTime> _createdDate;
    
    
    
        public virtual RolUsuario RolUsuario { get { return _rolUsuario; } set { if (!Equals(value, _rolUsuario)) { _rolUsuario = value; } } }
    	private RolUsuario _rolUsuario;
    
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
