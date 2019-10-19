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
    
    public partial class UsuarioFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioSupervisorUserID")]
        public Nullable<int> SupervisorUserID { get { return _supervisorUserID; } set { if (!Equals(value, _supervisorUserID)) { _supervisorUserID = value; } } }
    	private Nullable<int> _supervisorUserID;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioAccountName")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string AccountName { get { return _accountName; } set { if (!Equals(value, _accountName)) { _accountName = value; } } }
    	private string _accountName;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioPhoto")]
        public byte[] Photo { get { return _photo; } set { if (!Equals(value, _photo)) { _photo = value; } } }
    	private byte[] _photo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioLanguageId")]
        public Nullable<int> LanguageId { get { return _languageId; } set { if (!Equals(value, _languageId)) { _languageId = value; } } }
    	private Nullable<int> _languageId;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioUserNote")]
    	[StringLength(500, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string UserNote { get { return _userNote; } set { if (!Equals(value, _userNote)) { _userNote = value; } } }
    	private string _userNote;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioActivo")]
        public Nullable<bool> Activo { get { return _activo; } set { if (!Equals(value, _activo)) { _activo = value; } } }
    	private Nullable<bool> _activo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioCreatedBy")]
        public Nullable<int> CreatedBy { get { return _createdBy; } set { if (!Equals(value, _createdBy)) { _createdBy = value; } } }
    	private Nullable<int> _createdBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioCreatedDate")]
        public Nullable<System.DateTime> CreatedDate { get { return _createdDate; } set { if (!Equals(value, _createdDate)) { _createdDate = value; } } }
    	private Nullable<System.DateTime> _createdDate;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioModifiedBy")]
        public Nullable<int> ModifiedBy { get { return _modifiedBy; } set { if (!Equals(value, _modifiedBy)) { _modifiedBy = value; } } }
    	private Nullable<int> _modifiedBy;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UsuarioModifiedDate")]
        public Nullable<System.DateTime> ModifiedDate { get { return _modifiedDate; } set { if (!Equals(value, _modifiedDate)) { _modifiedDate = value; } } }
    	private Nullable<System.DateTime> _modifiedDate;
    
    
    
        public virtual IEnumerable<LoginAttempts> LoginAttempts { get { return _loginAttempts; } set { if (!Equals(value, _loginAttempts)) { _loginAttempts = value; } } }
    	private IEnumerable<LoginAttempts> _loginAttempts;
    
        public virtual IEnumerable<PermisosUsuario> PermisosUsuario { get { return _permisosUsuario; } set { if (!Equals(value, _permisosUsuario)) { _permisosUsuario = value; } } }
    	private IEnumerable<PermisosUsuario> _permisosUsuario;
    
        public virtual IEnumerable<UserPasswords> UserPasswords { get { return _userPasswords; } set { if (!Equals(value, _userPasswords)) { _userPasswords = value; } } }
    	private IEnumerable<UserPasswords> _userPasswords;
    
        public virtual IEnumerable<UserPhotos> UserPhotos { get { return _userPhotos; } set { if (!Equals(value, _userPhotos)) { _userPhotos = value; } } }
    	private IEnumerable<UserPhotos> _userPhotos;
    
    }
}
