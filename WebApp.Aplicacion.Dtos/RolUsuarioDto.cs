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
    [KnownType(typeof(PermisosUsuario))]
    public partial class RolUsuario : Entity
    {
        public RolUsuario()
        {
    		PermisosUsuario = new List<PermisosUsuario>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioNota")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nota { get { return _nota; } set { if (!Equals(value, _nota)) { _nota = value; } } }
    	private string _nota;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioActivo")]
    	[DataMember]
        public Nullable<bool> Activo { get { return _activo; } set { if (!Equals(value, _activo)) { _activo = value; } } }
    	private Nullable<bool> _activo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioCreatedBy")]
    	[DataMember]
        public Nullable<int> CreatedBy { get { return _createdBy; } set { if (!Equals(value, _createdBy)) { _createdBy = value; } } }
    	private Nullable<int> _createdBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioCreatedDate")]
    	[DataMember]
        public Nullable<System.DateTime> CreatedDate { get { return _createdDate; } set { if (!Equals(value, _createdDate)) { _createdDate = value; } } }
    	private Nullable<System.DateTime> _createdDate;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioModifiedBy")]
    	[DataMember]
        public Nullable<int> ModifiedBy { get { return _modifiedBy; } set { if (!Equals(value, _modifiedBy)) { _modifiedBy = value; } } }
    	private Nullable<int> _modifiedBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RolUsuarioModifiedDate")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataType(DataType.DateTime), DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    	[DataMember]
        public System.DateTime ModifiedDate { get { return _modifiedDate; } set { if (!Equals(value, _modifiedDate)) { _modifiedDate = value; } } }
    	private System.DateTime _modifiedDate;
    
    
    	[DataMember]
        public virtual List<PermisosUsuario> PermisosUsuario { get { return _permisosUsuario; } set { if (!Equals(value, _permisosUsuario)) { _permisosUsuario = value; } } }
    	private List<PermisosUsuario> _permisosUsuario;
    
    }
}
