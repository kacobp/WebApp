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
    
    public partial class NutrienteFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteCodigo")]
        public Nullable<int> Codigo { get { return _codigo; } set { if (!Equals(value, _codigo)) { _codigo = value; } } }
    	private Nullable<int> _codigo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteSimbolo")]
    	[StringLength(10, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Simbolo { get { return _simbolo; } set { if (!Equals(value, _simbolo)) { _simbolo = value; } } }
    	private string _simbolo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteNombre")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteTag")]
    	[StringLength(20, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Tag { get { return _tag; } set { if (!Equals(value, _tag)) { _tag = value; } } }
    	private string _tag;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteDecimales")]
        public Nullable<decimal> Decimales { get { return _decimales; } set { if (!Equals(value, _decimales)) { _decimales = value; } } }
    	private Nullable<decimal> _decimales;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteIdUniMed")]
        public Nullable<int> IdUniMed { get { return _idUniMed; } set { if (!Equals(value, _idUniMed)) { _idUniMed = value; } } }
    	private Nullable<int> _idUniMed;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteIdFuncNT")]
        public Nullable<int> IdFuncNT { get { return _idFuncNT; } set { if (!Equals(value, _idFuncNT)) { _idFuncNT = value; } } }
    	private Nullable<int> _idFuncNT;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteIdGrpNT")]
        public Nullable<int> IdGrpNT { get { return _idGrpNT; } set { if (!Equals(value, _idGrpNT)) { _idGrpNT = value; } } }
    	private Nullable<int> _idGrpNT;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteesEsencial")]
        public Nullable<int> esEsencial { get { return _esEsencial; } set { if (!Equals(value, _esEsencial)) { _esEsencial = value; } } }
    	private Nullable<int> _esEsencial;
    
    
    
        public virtual IEnumerable<Nt_Cant> Nt_Cant { get { return _nt_Cant; } set { if (!Equals(value, _nt_Cant)) { _nt_Cant = value; } } }
    	private IEnumerable<Nt_Cant> _nt_Cant;
    
        public virtual Nt_Func Nt_Func { get { return _nt_Func; } set { if (!Equals(value, _nt_Func)) { _nt_Func = value; } } }
    	private Nt_Func _nt_Func;
    
        public virtual Nt_Grp Nt_Grp { get { return _nt_Grp; } set { if (!Equals(value, _nt_Grp)) { _nt_Grp = value; } } }
    	private Nt_Grp _nt_Grp;
    
    }
}
