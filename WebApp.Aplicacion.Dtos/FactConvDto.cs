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
    [KnownType(typeof(Medida))]
    public partial class FactConv : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvIdAlim")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private int _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvIdMed")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int IdMed { get { return _idMed; } set { if (!Equals(value, _idMed)) { _idMed = value; } } }
    	private int _idMed;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvFactor")]
    	[DataMember]
        public Nullable<decimal> Factor { get { return _factor; } set { if (!Equals(value, _factor)) { _factor = value; } } }
    	private Nullable<decimal> _factor;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvFechaRegistro")]
    	[DataMember]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    	[DataMember]
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
    	[DataMember]
        public virtual Medida Medida { get { return _medida; } set { if (!Equals(value, _medida)) { _medida = value; } } }
    	private Medida _medida;
    
    }
}
