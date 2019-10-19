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
    [KnownType(typeof(Receta))]
    public partial class FamRec : Entity
    {
        public FamRec()
        {
    		Receta = new List<Receta>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FamRecId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FamRecNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FamRecDescripcion")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Descripcion { get { return _descripcion; } set { if (!Equals(value, _descripcion)) { _descripcion = value; } } }
    	private string _descripcion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FamRecBase")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Base { get { return _base; } set { if (!Equals(value, _base)) { _base = value; } } }
    	private int _base;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FamRecFechaRegistro")]
    	[DataMember]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    	[DataMember]
        public virtual List<Receta> Receta { get { return _receta; } set { if (!Equals(value, _receta)) { _receta = value; } } }
    	private List<Receta> _receta;
    
    }
}
