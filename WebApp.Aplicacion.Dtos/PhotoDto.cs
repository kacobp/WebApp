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
    [KnownType(typeof(UserPhotos))]
    public partial class Photo : Entity
    {
        public Photo()
        {
    		UserPhotos = new List<UserPhotos>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PhotoId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PhotoPhoto1")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public byte[] Photo1 { get { return _photo1; } set { if (!Equals(value, _photo1)) { _photo1 = value; } } }
    	private byte[] _photo1;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "PhotoFileName")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string FileName { get { return _fileName; } set { if (!Equals(value, _fileName)) { _fileName = value; } } }
    	private string _fileName;
    
    
    	[DataMember]
        public virtual List<UserPhotos> UserPhotos { get { return _userPhotos; } set { if (!Equals(value, _userPhotos)) { _userPhotos = value; } } }
    	private List<UserPhotos> _userPhotos;
    
    }
}
