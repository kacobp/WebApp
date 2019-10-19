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
    
    public partial class Nt_GrpFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpNombre")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpDescripcion")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Descripcion { get { return _descripcion; } set { if (!Equals(value, _descripcion)) { _descripcion = value; } } }
    	private string _descripcion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpIdGrpCantNT")]
        public Nullable<int> IdGrpCantNT { get { return _idGrpCantNT; } set { if (!Equals(value, _idGrpCantNT)) { _idGrpCantNT = value; } } }
    	private Nullable<int> _idGrpCantNT;
    
    
    
        public virtual Nt_Grp_Cant Nt_Grp_Cant { get { return _nt_Grp_Cant; } set { if (!Equals(value, _nt_Grp_Cant)) { _nt_Grp_Cant = value; } } }
    	private Nt_Grp_Cant _nt_Grp_Cant;
    
        public virtual IEnumerable<Nutriente> Nutriente { get { return _nutriente; } set { if (!Equals(value, _nutriente)) { _nutriente = value; } } }
    	private IEnumerable<Nutriente> _nutriente;
    
    }
}
