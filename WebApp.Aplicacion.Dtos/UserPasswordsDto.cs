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
    [KnownType(typeof(Password))]
    [KnownType(typeof(Usuario))]
    public partial class UserPasswords : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsIdUsuario")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private int _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsIdPassword")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdPassword { get { return _idPassword; } set { if (!Equals(value, _idPassword)) { _idPassword = value; } } }
    	private int _idPassword;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsExternalUser")]
    	[DataMember]
        public Nullable<bool> ExternalUser { get { return _externalUser; } set { if (!Equals(value, _externalUser)) { _externalUser = value; } } }
    	private Nullable<bool> _externalUser;
    
    
    	[DataMember]
        public virtual Password Password { get { return _password; } set { if (!Equals(value, _password)) { _password = value; } } }
    	private Password _password;
    
    	[DataMember]
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
