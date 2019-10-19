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
    
    public partial class Log4netFindModel : Entity
    {
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netId")]
        public Nullable<int> Id { get { return _id; } set { if (!Equals(value, _id)) { _id = value; } } }
    	private Nullable<int> _id;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netLevel")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Level { get { return _level; } set { if (!Equals(value, _level)) { _level = value; } } }
    	private string _level;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netLogger")]
    	[StringLength(255, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Logger { get { return _logger; } set { if (!Equals(value, _logger)) { _logger = value; } } }
    	private string _logger;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netHost")]
    	[StringLength(50, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Host { get { return _host; } set { if (!Equals(value, _host)) { _host = value; } } }
    	private string _host;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netDate")]
        public Nullable<System.DateTime> Date { get { return _date; } set { if (!Equals(value, _date)) { _date = value; } } }
    	private Nullable<System.DateTime> _date;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netThread")]
    	[StringLength(255, ErrorMessageResourceType = typeof(ApplicationResources), ErrorMessageResourceName = "validation_FieldMaxLenght")]
        public string Thread { get { return _thread; } set { if (!Equals(value, _thread)) { _thread = value; } } }
    	private string _thread;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netMessage")]
        public string Message { get { return _message; } set { if (!Equals(value, _message)) { _message = value; } } }
    	private string _message;
    
    	[Display(ResourceType = typeof(ApplicationResources), Name = "Log4netException")]
        public string Exception { get { return _exception; } set { if (!Equals(value, _exception)) { _exception = value; } } }
    	private string _exception;
    
    }
}
