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
    [KnownType(typeof(FamRec))]
    [KnownType(typeof(RecProd))]
    public partial class Receta : Entity
    {
        public Receta()
        {
    		RecProd = new List<RecProd>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaIdFamRec")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdFamRec { get { return _idFamRec; } set { if (!Equals(value, _idFamRec)) { _idFamRec = value; } } }
    	private int _idFamRec;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaIdRecetaBase")]
    	[DataMember]
        public Nullable<int> IdRecetaBase { get { return _idRecetaBase; } set { if (!Equals(value, _idRecetaBase)) { _idRecetaBase = value; } } }
    	private Nullable<int> _idRecetaBase;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(70, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaAlias")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Alias { get { return _alias; } set { if (!Equals(value, _alias)) { _alias = value; } } }
    	private string _alias;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaUbicacion")]
    	[DataMember]
        public Nullable<int> Ubicacion { get { return _ubicacion; } set { if (!Equals(value, _ubicacion)) { _ubicacion = value; } } }
    	private Nullable<int> _ubicacion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaDescripcion")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Descripcion { get { return _descripcion; } set { if (!Equals(value, _descripcion)) { _descripcion = value; } } }
    	private string _descripcion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaPreparacion")]
    	[DataMember]
        public string Preparacion { get { return _preparacion; } set { if (!Equals(value, _preparacion)) { _preparacion = value; } } }
    	private string _preparacion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaIdFoto")]
    	[DataMember]
        public Nullable<int> IdFoto { get { return _idFoto; } set { if (!Equals(value, _idFoto)) { _idFoto = value; } } }
    	private Nullable<int> _idFoto;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaIdEstado")]
    	[DataMember]
        public Nullable<int> IdEstado { get { return _idEstado; } set { if (!Equals(value, _idEstado)) { _idEstado = value; } } }
    	private Nullable<int> _idEstado;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecetaFechaRegistro")]
    	[DataMember]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    	[DataMember]
        public virtual FamRec FamRec { get { return _famRec; } set { if (!Equals(value, _famRec)) { _famRec = value; } } }
    	private FamRec _famRec;
    
    	[DataMember]
        public virtual List<RecProd> RecProd { get { return _recProd; } set { if (!Equals(value, _recProd)) { _recProd = value; } } }
    	private List<RecProd> _recProd;
    
    }
}
