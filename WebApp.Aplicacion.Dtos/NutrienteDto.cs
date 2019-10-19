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
    [KnownType(typeof(Nt_Cant))]
    [KnownType(typeof(Nt_Func))]
    [KnownType(typeof(Nt_Grp))]
    public partial class Nutriente : Entity
    {
        public Nutriente()
        {
    		Nt_Cant = new List<Nt_Cant>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteCodigo")]
    	[DataMember]
        public Nullable<int> Codigo { get { return _codigo; } set { if (!Equals(value, _codigo)) { _codigo = value; } } }
    	private Nullable<int> _codigo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteSimbolo")]
    	[StringLength(10, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Simbolo { get { return _simbolo; } set { if (!Equals(value, _simbolo)) { _simbolo = value; } } }
    	private string _simbolo;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteTag")]
    	[StringLength(20, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Tag { get { return _tag; } set { if (!Equals(value, _tag)) { _tag = value; } } }
    	private string _tag;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteDecimales")]
    	[DataMember]
        public Nullable<decimal> Decimales { get { return _decimales; } set { if (!Equals(value, _decimales)) { _decimales = value; } } }
    	private Nullable<decimal> _decimales;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteIdUniMed")]
    	[DataMember]
        public Nullable<int> IdUniMed { get { return _idUniMed; } set { if (!Equals(value, _idUniMed)) { _idUniMed = value; } } }
    	private Nullable<int> _idUniMed;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteIdFuncNT")]
    	[DataMember]
        public Nullable<int> IdFuncNT { get { return _idFuncNT; } set { if (!Equals(value, _idFuncNT)) { _idFuncNT = value; } } }
    	private Nullable<int> _idFuncNT;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteIdGrpNT")]
    	[DataMember]
        public Nullable<int> IdGrpNT { get { return _idGrpNT; } set { if (!Equals(value, _idGrpNT)) { _idGrpNT = value; } } }
    	private Nullable<int> _idGrpNT;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "NutrienteesEsencial")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int esEsencial { get { return _esEsencial; } set { if (!Equals(value, _esEsencial)) { _esEsencial = value; } } }
    	private int _esEsencial;
    
    
    	[DataMember]
        public virtual List<Nt_Cant> Nt_Cant { get { return _nt_Cant; } set { if (!Equals(value, _nt_Cant)) { _nt_Cant = value; } } }
    	private List<Nt_Cant> _nt_Cant;
    
    	[DataMember]
        public virtual Nt_Func Nt_Func { get { return _nt_Func; } set { if (!Equals(value, _nt_Func)) { _nt_Func = value; } } }
    	private Nt_Func _nt_Func;
    
    	[DataMember]
        public virtual Nt_Grp Nt_Grp { get { return _nt_Grp; } set { if (!Equals(value, _nt_Grp)) { _nt_Grp = value; } } }
    	private Nt_Grp _nt_Grp;
    
    }
}
