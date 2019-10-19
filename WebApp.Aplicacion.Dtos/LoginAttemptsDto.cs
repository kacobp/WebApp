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
    [KnownType(typeof(Usuario))]
    public partial class LoginAttempts : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsIdUsuario")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private int _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsPassword")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Password { get { return _password; } set { if (!Equals(value, _password)) { _password = value; } } }
    	private string _password;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsIPNumber")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string IPNumber { get { return _iPNumber; } set { if (!Equals(value, _iPNumber)) { _iPNumber = value; } } }
    	private string _iPNumber;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsBrowserType")]
    	[StringLength(200, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string BrowserType { get { return _browserType; } set { if (!Equals(value, _browserType)) { _browserType = value; } } }
    	private string _browserType;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsSuccess")]
    	[DataMember]
        public Nullable<bool> Success { get { return _success; } set { if (!Equals(value, _success)) { _success = value; } } }
    	private Nullable<bool> _success;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "LoginAttemptsCreatedDate")]
    	[DataMember]
        public Nullable<System.DateTime> CreatedDate { get { return _createdDate; } set { if (!Equals(value, _createdDate)) { _createdDate = value; } } }
    	private Nullable<System.DateTime> _createdDate;
    
    
    	[DataMember]
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
