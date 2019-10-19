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
    [KnownType(typeof(Alim))]
    public partial class Alim_Fuente : Entity
    {
        public Alim_Fuente()
        {
    		Alim = new List<Alim>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Alim_FuenteId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Alim_FuenteCod")]
    	[DataMember]
        public Nullable<int> Cod { get { return _cod; } set { if (!Equals(value, _cod)) { _cod = value; } } }
    	private Nullable<int> _cod;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Alim_FuenteNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    
    	[DataMember]
        public virtual List<Alim> Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private List<Alim> _alim;
    
    }
}
