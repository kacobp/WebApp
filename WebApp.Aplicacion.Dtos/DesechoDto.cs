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
    [KnownType(typeof(DesCant))]
    public partial class Desecho : Entity
    {
        public Desecho()
        {
    		DesCant = new List<DesCant>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesechoId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesechoNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    
    	[DataMember]
        public virtual List<DesCant> DesCant { get { return _desCant; } set { if (!Equals(value, _desCant)) { _desCant = value; } } }
    	private List<DesCant> _desCant;
    
    }
}
