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
    
    public partial class Alim_GrpFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Alim_GrpId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Alim_GrpCod")]
        public Nullable<int> Cod { get { return _cod; } set { if (!Equals(value, _cod)) { _cod = value; } } }
    	private Nullable<int> _cod;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Alim_GrpNombre")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    
    
        public virtual IEnumerable<Alim> Alim { get { return _alim; } set { if (!Equals(value, _alim)) { _alim = value; } } }
    	private IEnumerable<Alim> _alim;
    
    }
}
