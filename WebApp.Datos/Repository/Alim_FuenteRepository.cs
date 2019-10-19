#region

using WebApp.Datos.Core;
using WebApp.Dominio.Core.UnitOfWork;
using WebApp.Dominio.Entidades;
using WebApp.Dominio.IRepository;
using System.Data.Entity;

#endregion

namespace WebApp.Datos.Repository
{
    using System;
    using System.Collections.Generic;
    
    public partial class Alim_FuenteRepository : Repository<Alim_Fuente>, IAlim_FuenteRepository
    {
        #region Constructor
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Alim_FuenteRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext dependency</param>        
        public Alim_FuenteRepository(DbContext context) : base(context) { }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Alim_FuenteRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
    	public Alim_FuenteRepository(DbContext context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork) { }
    
        #endregion
    }
}
