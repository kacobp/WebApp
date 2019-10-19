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
    [KnownType(typeof(Receta))]
    public partial class RecProd : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdIdReceta")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdReceta { get { return _idReceta; } set { if (!Equals(value, _idReceta)) { _idReceta = value; } } }
    	private int _idReceta;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdIdProducto")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdProducto { get { return _idProducto; } set { if (!Equals(value, _idProducto)) { _idProducto = value; } } }
    	private int _idProducto;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdIdProveedor")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdProveedor { get { return _idProveedor; } set { if (!Equals(value, _idProveedor)) { _idProveedor = value; } } }
    	private int _idProveedor;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdGramos")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public decimal Gramos { get { return _gramos; } set { if (!Equals(value, _gramos)) { _gramos = value; } } }
    	private decimal _gramos;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdFechaRegistro")]
    	[DataMember]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    	[DataMember]
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
    	[DataMember]
        public virtual Receta Receta { get { return _receta; } set { if (!Equals(value, _receta)) { _receta = value; } } }
    	private Receta _receta;
    
    }
}
