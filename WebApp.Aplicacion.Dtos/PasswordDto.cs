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
    [KnownType(typeof(UserPasswords))]
    public partial class Password : Entity
    {
        public Password()
        {
    		UserPasswords = new List<UserPasswords>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordPassword1")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Password1 { get { return _password1; } set { if (!Equals(value, _password1)) { _password1 = value; } } }
    	private string _password1;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordPasswordHash")]
    	[StringLength(128, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string PasswordHash { get { return _passwordHash; } set { if (!Equals(value, _passwordHash)) { _passwordHash = value; } } }
    	private string _passwordHash;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordPasswordSalt")]
    	[StringLength(10, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string PasswordSalt { get { return _passwordSalt; } set { if (!Equals(value, _passwordSalt)) { _passwordSalt = value; } } }
    	private string _passwordSalt;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordPasswordAnswer")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string PasswordAnswer { get { return _passwordAnswer; } set { if (!Equals(value, _passwordAnswer)) { _passwordAnswer = value; } } }
    	private string _passwordAnswer;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordPasswordQuestion")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string PasswordQuestion { get { return _passwordQuestion; } set { if (!Equals(value, _passwordQuestion)) { _passwordQuestion = value; } } }
    	private string _passwordQuestion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordActivo")]
    	[DataMember]
        public Nullable<bool> Activo { get { return _activo; } set { if (!Equals(value, _activo)) { _activo = value; } } }
    	private Nullable<bool> _activo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordCreatedByUserID")]
    	[StringLength(10, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string CreatedByUserID { get { return _createdByUserID; } set { if (!Equals(value, _createdByUserID)) { _createdByUserID = value; } } }
    	private string _createdByUserID;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PasswordFechaCreacion")]
    	[DataMember]
        public Nullable<System.DateTime> FechaCreacion { get { return _fechaCreacion; } set { if (!Equals(value, _fechaCreacion)) { _fechaCreacion = value; } } }
    	private Nullable<System.DateTime> _fechaCreacion;
    
    
    	[DataMember]
        public virtual List<UserPasswords> UserPasswords { get { return _userPasswords; } set { if (!Equals(value, _userPasswords)) { _userPasswords = value; } } }
    	private List<UserPasswords> _userPasswords;
    
    }
}
