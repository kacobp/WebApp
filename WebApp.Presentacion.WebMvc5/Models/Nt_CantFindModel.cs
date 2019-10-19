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
    
    public partial class Nt_CantFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantIdAlim")]
        public Nullable<int> IdAlim { get { return _idAlim; } set { if (!Equals(value, _idAlim)) { _idAlim = value; } } }
    	private Nullable<int> _idAlim;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantIdNtFte")]
        public Nullable<int> IdNtFte { get { return _idNtFte; } set { if (!Equals(value, _idNtFte)) { _idNtFte = value; } } }
    	private Nullable<int> _idNtFte;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantIdNut")]
        public Nullable<int> IdNut { get { return _idNut; } set { if (!Equals(value, _idNut)) { _idNut = value; } } }
    	private Nullable<int> _idNut;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantValor")]
        public Nullable<decimal> Valor { get { return _valor; } set { if (!Equals(value, _valor)) { _valor = value; } } }
    	private Nullable<decimal> _valor;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantErrorEstandar")]
        public Nullable<int> ErrorEstandar { get { return _errorEstandar; } set { if (!Equals(value, _errorEstandar)) { _errorEstandar = value; } } }
    	private Nullable<int> _errorEstandar;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantNumObs")]
        public Nullable<int> NumObs { get { return _numObs; } set { if (!Equals(value, _numObs)) { _numObs = value; } } }
    	private Nullable<int> _numObs;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_CantFechaRegistro")]
        public Nullable<System.DateTime> FechaRegistro { get { return _fechaRegistro; } set { if (!Equals(value, _fechaRegistro)) { _fechaRegistro = value; } } }
    	private Nullable<System.DateTime> _fechaRegistro;
    
    
    
        public virtual Alim Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private Alim _alim;
    
        public virtual Nutriente Nutriente { get { return _nutriente; } set { if (!Equals(value, _nutriente)) { _nutriente = value; } } }
    	private Nutriente _nutriente;
    
        public virtual Nt_Fuente Nt_Fuente { get { return _nt_Fuente; } set { if (!Equals(value, _nt_Fuente)) { _nt_Fuente = value; } } }
    	private Nt_Fuente _nt_Fuente;
    
    }
}
