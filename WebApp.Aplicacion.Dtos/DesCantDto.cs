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
    [KnownType(typeof(Desecho))]
    public partial class DesCant : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantIdAlim")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private int _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantIdDes")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdDes { get { return _idDes; } set { if (!Equals(value, _idDes)) { _idDes = value; } } }
    	private int _idDes;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantCantidad")]
    	[DataMember]
        public Nullable<decimal> Cantidad { get { return _cantidad; } set { if (!Equals(value, _cantidad)) { _cantidad = value; } } }
    	private Nullable<decimal> _cantidad;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantFechaRegistro")]
    	[DataMember]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    	[DataMember]
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
    	[DataMember]
        public virtual Desecho Desecho { get { return _desecho; } set { if (!Equals(value, _desecho)) { _desecho = value; } } }
    	private Desecho _desecho;
    
    }
}
