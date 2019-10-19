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
    
    public partial class RecProdFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdIdReceta")]
        public Nullable<int> IdReceta { get { return _idReceta; } set { if (!Equals(value, _idReceta)) { _idReceta = value; } } }
    	private Nullable<int> _idReceta;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdIdProducto")]
        public Nullable<int> IdProducto { get { return _idProducto; } set { if (!Equals(value, _idProducto)) { _idProducto = value; } } }
    	private Nullable<int> _idProducto;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdIdProveedor")]
        public Nullable<int> IdProveedor { get { return _idProveedor; } set { if (!Equals(value, _idProveedor)) { _idProveedor = value; } } }
    	private Nullable<int> _idProveedor;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdGramos")]
        public Nullable<decimal> Gramos { get { return _gramos; } set { if (!Equals(value, _gramos)) { _gramos = value; } } }
    	private Nullable<decimal> _gramos;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "RecProdFechaRegistro")]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
        public virtual Receta Receta { get { return _receta; } set { if (!Equals(value, _receta)) { _receta = value; } } }
    	private Receta _receta;
    
    }
}
