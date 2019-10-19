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
    
    public partial class DesCantFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantIdAlim")]
        public Nullable<int> IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private Nullable<int> _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantIdDes")]
        public Nullable<int> IdDes { get { return _idDes; } set { if (!Equals(value, _idDes)) { _idDes = value; } } }
    	private Nullable<int> _idDes;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantCantidad")]
        public Nullable<decimal> Cantidad { get { return _cantidad; } set { if (!Equals(value, _cantidad)) { _cantidad = value; } } }
    	private Nullable<decimal> _cantidad;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "DesCantFechaRegistro")]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
        public virtual Desecho Desecho { get { return _desecho; } set { if (!Equals(value, _desecho)) { _desecho = value; } } }
    	private Desecho _desecho;
    
    }
}
