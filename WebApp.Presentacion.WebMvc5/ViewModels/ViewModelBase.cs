using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApp.Datos.Core;
using WebApp.Transversales;

namespace WebApp.Presentacion.WebMvc5.ViewModels
{
    //public class ViewModelBase<T> : PagedCollection<T>
    //{

    //}

    /// <summary>
    /// Base class for MVC view model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewModelBase<T> : PagedCollection<T>
        where T : Entity
    {
        /// <summary>
        /// Gets or sets the current item.
        /// </summary>
        /// <value>
        /// The current item.
        /// </value>
        public virtual T ModelInstance { get; set; }
    }

}
