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
    
    public partial class UserPasswordsFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsIdUsuario")]
        public Nullable<int> IdUsuario { get { return _idUsuario; } set { if (!Equals(value, _idUsuario)) { _idUsuario = value; } } }
    	private Nullable<int> _idUsuario;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsIdPassword")]
        public Nullable<int> IdPassword { get { return _idPassword; } set { if (!Equals(value, _idPassword)) { _idPassword = value; } } }
    	private Nullable<int> _idPassword;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "UserPasswordsExternalUser")]
        public Nullable<bool> ExternalUser { get { return _externalUser; } set { if (!Equals(value, _externalUser)) { _externalUser = value; } } }
    	private Nullable<bool> _externalUser;
    
    
    
        public virtual Password Password { get { return _password; } set { if (!Equals(value, _password)) { _password = value; } } }
    	private Password _password;
    
        public virtual Usuario Usuario { get { return _usuario; } set { if (!Equals(value, _usuario)) { _usuario = value; } } }
    	private Usuario _usuario;
    
    }
}
