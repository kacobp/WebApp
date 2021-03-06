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
    
    public partial class UserPhotosRepository : Repository<UserPhotos>, IUserPhotosRepository
    {
        #region Constructor
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPhotosRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext dependency</param>        
        public UserPhotosRepository(DbContext context) : base(context) { }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPhotosRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
    	public UserPhotosRepository(DbContext context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork) { }
    
        #endregion
    }
}
