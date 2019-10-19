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
    [KnownType(typeof(Nt_Grp_Cant))]
    [KnownType(typeof(Nutriente))]
    public partial class Nt_Grp : Entity
    {
        public Nt_Grp()
        {
    		Nutriente = new List<Nutriente>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpDescripcion")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Descripcion { get { return _descripcion; } set { if (!Equals(value, _descripcion)) { _descripcion = value; } } }
    	private string _descripcion;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_GrpIdGrpCantNT")]
    	[DataMember]
        public Nullable<int> IdGrpCantNT { get { return _idGrpCantNT; } set { if (!Equals(value, _idGrpCantNT)) { _idGrpCantNT = value; } } }
    	private Nullable<int> _idGrpCantNT;
    
    
    	[DataMember]
        public virtual Nt_Grp_Cant Nt_Grp_Cant { get { return _nt_Grp_Cant; } set { if (!Equals(value, _nt_Grp_Cant)) { _nt_Grp_Cant = value; } } }
    	private Nt_Grp_Cant _nt_Grp_Cant;
    
    	[DataMember]
        public virtual List<Nutriente> Nutriente { get { return _nutriente; } set { if (!Equals(value, _nutriente)) { _nutriente = value; } } }
    	private List<Nutriente> _nutriente;
    
    }
}
