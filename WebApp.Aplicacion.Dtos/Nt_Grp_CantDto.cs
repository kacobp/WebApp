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
    [KnownType(typeof(Nt_Grp))]
    public partial class Nt_Grp_Cant : Entity
    {
        public Nt_Grp_Cant()
        {
    		Nt_Grp = new List<Nt_Grp>();
        }
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_Grp_CantId")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[DataMember]
        public int Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private int _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_Grp_CantNombre")]
    	[Required(ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldRequired")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Nombre { get { return _nombre; } set { if (!Equals(value, _nombre)) { _nombre = value; } } }
    	private string _nombre;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Nt_Grp_CantDescripcion")]
    	[StringLength(250, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
    	[DataMember]
        public string Descripcion { get { return _descripcion; } set { if (!Equals(value, _descripcion)) { _descripcion = value; } } }
    	private string _descripcion;
    
    
    	[DataMember]
        public virtual List<Nt_Grp> Nt_Grp { get { return _nt_Grp; } set { if (!Equals(value, _nt_Grp)) { _nt_Grp = value; } } }
    	private List<Nt_Grp> _nt_Grp;
    
    }
}
