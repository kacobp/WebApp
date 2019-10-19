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
    
    public partial class RendCantFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantIdAlim")]
        public Nullable<int> IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private Nullable<int> _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantIdRend")]
        public Nullable<int> IdRend { get { return _idRend; } set { if (!Equals(value, _idRend)) { _idRend = value; } } }
    	private Nullable<int> _idRend;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantCantidad")]
        public Nullable<decimal> Cantidad { get { return _cantidad; } set { if (!Equals(value, _cantidad)) { _cantidad = value; } } }
    	private Nullable<decimal> _cantidad;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RendCantFechaRegistro")]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
        public virtual Rend Rend { get { return _rend; } set { if (!Equals(value, _rend)) { _rend = value; } } }
    	private Rend _rend;
    
    }
}
