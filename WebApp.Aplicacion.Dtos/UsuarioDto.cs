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
    [KnownType(typeof(LoginAttempts))]
    [KnownType(typeof(PermisosUsuario))]
    [KnownType(typeof(UserPasswords))]
    [KnownType(typeof(UserPhotos))]
    public partial class Usuario : Entity
    {
        public Usuario()
        {
    		LoginAttempts = new List<LoginAttempts>();
    		PermisosUsuario = new List<PermisosUsuario>();
    		UserPasswords = new List<UserPasswords>();
    		UserPhotos = new List<UserPhotos>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioSupervisorUserID")]
    	[DataMember]
        public Nullable<int> SupervisorUserID { get { return _supervisorUserID; } set { if (!Equals(value, _supervisorUserID)) { _supervisorUserID = value; } } }
    	private Nullable<int> _supervisorUserID;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioAccountName")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string AccountName { get { return _accountName; } set { if (!Equals(value, _accountName)) { _accountName = value; } } }
    	private string _accountName;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioPhoto")]
    	[DataMember]
        public byte[] Photo { get { return _photo; } set { if (!Equals(value, _photo)) { _photo = value; } } }
    	private byte[] _photo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioLanguageId")]
    	[DataMember]
        public Nullable<int> LanguageId { get { return _languageId; } set { if (!Equals(value, _languageId)) { _languageId = value; } } }
    	private Nullable<int> _languageId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioUserNote")]
    	[StringLength(500, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string UserNote { get { return _userNote; } set { if (!Equals(value, _userNote)) { _userNote = value; } } }
    	private string _userNote;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioActivo")]
    	[DataMember]
        public Nullable<bool> Activo { get { return _activo; } set { if (!Equals(value, _activo)) { _activo = value; } } }
    	private Nullable<bool> _activo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioCreatedBy")]
    	[DataMember]
        public Nullable<int> CreatedBy { get { return _createdBy; } set { if (!Equals(value, _createdBy)) { _createdBy = value; } } }
    	private Nullable<int> _createdBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioCreatedDate")]
    	[DataMember]
        public Nullable<System.DateTime> CreatedDate { get { return _createdDate; } set { if (!Equals(value, _createdDate)) { _createdDate = value; } } }
    	private Nullable<System.DateTime> _createdDate;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioModifiedBy")]
    	[DataMember]
        public Nullable<int> ModifiedBy { get { return _modifiedBy; } set { if (!Equals(value, _modifiedBy)) { _modifiedBy = value; } } }
    	private Nullable<int> _modifiedBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioModifiedDate")]
    	[DataMember]
        public Nullable<System.DateTime> ModifiedDate { get { return _modifiedDate; } set { if (!Equals(value, _modifiedDate)) { _modifiedDate = value; } } }
    	private Nullable<System.DateTime> _modifiedDate;
    
    
    	[DataMember]
        public virtual List<LoginAttempts> LoginAttempts { get { return _loginAttempts; } set { if (!Equals(value, _loginAttempts)) { _loginAttempts = value; } } }
    	private List<LoginAttempts> _loginAttempts;
    
    	[DataMember]
        public virtual List<PermisosUsuario> PermisosUsuario { get { return _permisosUsuario; } set { if (!Equals(value, _permisosUsuario)) { _permisosUsuario = value; } } }
    	private List<PermisosUsuario> _permisosUsuario;
    
    	[DataMember]
        public virtual List<UserPasswords> UserPasswords { get { return _userPasswords; } set { if (!Equals(value, _userPasswords)) { _userPasswords = value; } } }
    	private List<UserPasswords> _userPasswords;
    
    	[DataMember]
        public virtual List<UserPhotos> UserPhotos { get { return _userPhotos; } set { if (!Equals(value, _userPhotos)) { _userPhotos = value; } } }
    	private List<UserPhotos> _userPhotos;
    
    }
}
