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
    [KnownType(typeof(Nt_Cant))]
    public partial class Nt_Fuente : Entity
    {
        public Nt_Fuente()
        {
    		Nt_Cant = new List<Nt_Cant>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_FuenteId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_FuenteCod")]
    	[DataMember]
        public Nullable<int> Cod { get { return _cod; } set { if (!Equals(value, _cod)) { _cod = value; } } }
    	private Nullable<int> _cod;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_FuenteNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    
    	[DataMember]
        public virtual List<Nt_Cant> Nt_Cant { get { return _nt_Cant; } set { if (!Equals(value, _nt_Cant)) { _nt_Cant = value; } } }
    	private List<Nt_Cant> _nt_Cant;
    
    }
}
