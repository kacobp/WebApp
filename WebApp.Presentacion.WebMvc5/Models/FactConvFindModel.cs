//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

//using WebApp.Aplicacion.Dtos;
using WebApp.Aplicacion.Resx;
using WebApp.Datos.Core;
using WebApp.Dominio.Entidades;
//using WebApp.Transversales.Framework;

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#endregion

namespace WebApp.Presentacion.WebMvc5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FactConvFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvIdAlim")]
        public Nullable<int> IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private Nullable<int> _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvIdMed")]
        public Nullable<int> IdMed { get { return _idMed; } set { if (!Equals(value, _idMed)) { _idMed = value; } } }
    	private Nullable<int> _idMed;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvFactor")]
        public Nullable<decimal> Factor { get { return _factor; } set { if (!Equals(value, _factor)) { _factor = value; } } }
    	private Nullable<decimal> _factor;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "FactConvFechaRegistro")]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
        public virtual Medida Medida { get { return _medida; } set { if (!Equals(value, _medida)) { _medida = value; } } }
    	private Medida _medida;
    
    }
}
