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
    [KnownType(typeof(Rend))]
    public partial class RendCant : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantIdAlim")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private int _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantIdRend")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdRend { get { return _idRend; } set { if (!Equals(value, _idRend)) { _idRend = value; } } }
    	private int _idRend;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantCantidad")]
    	[DataMember]
        public Nullable<decimal> Cantidad { get { return _cantidad; } set { if (!Equals(value, _cantidad)) { _cantidad = value; } } }
    	private Nullable<decimal> _cantidad;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantFechaRegistro")]
    	[DataMember]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    	[DataMember]
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
    	[DataMember]
        public virtual Rend Rend { get { return _rend; } set { if (!Equals(value, _rend)) { _rend = value; } } }
    	private Rend _rend;
    
    }
}
