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
    
    public partial class AlimFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimNombre")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimIdEstado")]
        public Nullable<int> IdEstado { get { return _idEstado; } set { if (!Equals(value, _idEstado)) { _idEstado = value; } } }
    	private Nullable<int> _idEstado;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimFactorRendimiento")]
        public Nullable<decimal> FactorRendimiento { get { return _factorRendimiento; } set { if (!Equals(value, _factorRendimiento)) { _factorRendimiento = value; } } }
    	private Nullable<decimal> _factorRendimiento;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimFactorDescuento")]
        public Nullable<decimal> FactorDescuento { get { return _factorDescuento; } set { if (!Equals(value, _factorDescuento)) { _factorDescuento = value; } } }
    	private Nullable<decimal> _factorDescuento;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimFraccionado")]
        public Nullable<int> Fraccionado { get { return _fraccionado; } set { if (!Equals(value, _fraccionado)) { _fraccionado = value; } } }
    	private Nullable<int> _fraccionado;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimConversionInyectado")]
        public Nullable<int> ConversionInyectado { get { return _conversionInyectado; } set { if (!Equals(value, _conversionInyectado)) { _conversionInyectado = value; } } }
    	private Nullable<int> _conversionInyectado;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimFactorConversion")]
        public Nullable<decimal> FactorConversion { get { return _factorConversion; } set { if (!Equals(value, _factorConversion)) { _factorConversion = value; } } }
    	private Nullable<decimal> _factorConversion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimInactivo")]
        public Nullable<int> Inactivo { get { return _inactivo; } set { if (!Equals(value, _inactivo)) { _inactivo = value; } } }
    	private Nullable<int> _inactivo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimNomAbreviado")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string NomAbreviado { get { return _nomAbreviado; } set { if (!Equals(value, _nomAbreviado)) { _nomAbreviado = value; } } }
    	private string _nomAbreviado;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimNomCientifico")]
    	[StringLength(100, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string NomCientifico { get { return _nomCientifico; } set { if (!Equals(value, _nomCientifico)) { _nomCientifico = value; } } }
    	private string _nomCientifico;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimesAlimento")]
        public Nullable<int> esAlimento { get { return _esAlimento; } set { if (!Equals(value, _esAlimento)) { _esAlimento = value; } } }
    	private Nullable<int> _esAlimento;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimNT_MedidaBase")]
        public Nullable<decimal> NT_MedidaBase { get { return _nT_MedidaBase; } set { if (!Equals(value, _nT_MedidaBase)) { _nT_MedidaBase = value; } } }
    	private Nullable<decimal> _nT_MedidaBase;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimIdUniMed")]
        public Nullable<int> IdUniMed { get { return _idUniMed; } set { if (!Equals(value, _idUniMed)) { _idUniMed = value; } } }
    	private Nullable<int> _idUniMed;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimIdAlimGrp")]
        public Nullable<int> IdAlimGrp { get { return _idAlimGrp; } set { if (!Equals(value, _idAlimGrp)) { _idAlimGrp = value; } } }
    	private Nullable<int> _idAlimGrp;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimIdAlimFte")]
        public Nullable<int> IdAlimFte { get { return _idAlimFte; } set { if (!Equals(value, _idAlimFte)) { _idAlimFte = value; } } }
    	private Nullable<int> _idAlimFte;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "AlimFechaRegistro")]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    
        public virtual IEnumerable<FactConv> FactConv { get { return _factConv; } set { if (!Equals(value, _factConv)) { _factConv = value; } } }
    	private IEnumerable<FactConv> _factConv;
    
        public virtual IEnumerable<Nt_Cant> Nt_Cant { get { return _nt_Cant; } set { if (!Equals(value, _nt_Cant)) { _nt_Cant = value; } } }
    	private IEnumerable<Nt_Cant> _nt_Cant;
    
        public virtual Alim_Grp Alim_Grp { get { return _alim_Grp; } set { if (!Equals(value, _alim_Grp)) { _alim_Grp = value; } } }
    	private Alim_Grp _alim_Grp;
    
        public virtual Alim_Fuente Alim_Fuente { get { return _alim_Fuente; } set { if (!Equals(value, _alim_Fuente)) { _alim_Fuente = value; } } }
    	private Alim_Fuente _alim_Fuente;
    
        public virtual UniMed UniMed { get { return _uniMed; } set { if (!Equals(value, _uniMed)) { _uniMed = value; } } }
    	private UniMed _uniMed;
    
        public virtual IEnumerable<RecProd> RecProd { get { return _recProd; } set { if (!Equals(value, _recProd)) { _recProd = value; } } }
    	private IEnumerable<RecProd> _recProd;
    
        public virtual IEnumerable<DesCant> DesCant { get { return _desCant; } set { if (!Equals(value, _desCant)) { _desCant = value; } } }
    	private IEnumerable<DesCant> _desCant;
    
        public virtual RendCant RendCant { get { return _rendCant; } set { if (!Equals(value, _rendCant)) { _rendCant = value; } } }
    	private RendCant _rendCant;
    
    }
}
