#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApp.Datos.Core;
using WebApp.Dominio.Core.Repositories;
using WebApp.Dominio.Core.UnitOfWork;
using WebApp.Dominio.Entidades;
using WebApp.Dominio.IRepository;

#endregion

namespace WebApp.Datos.Repository
{
    public partial class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        #region Constructor
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioRepository"/> class.
        /// </summary>
        /// <param name="context">DbContext dependency</param>        
        public UsuarioRepository(DbContext context) : base(context) { }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UsuarioRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
    	public UsuarioRepository(DbContext context, IUnitOfWorkAsync unitOfWork) : base(context, unitOfWork) { }

        public bool Register(Usuario item, string nomUsuario, string password)
        {
            Usuario oUser = new Usuario();
            UserPasswords oUserPass = new UserPasswords();
            Password oPass = new Password();

            return true;
        }

        //public static Usuario LogIn(this IRepository<Usuario> repository, string nomUsuario, string password)
        //{

        //    var lstPass = repository.GetRepository<UserPasswords>();
        //    var oUser = repository.Queryable().Where(u => u.AccountName == nomUsuario).FirstOrDefault();
        //    var oPass = repository.GetRepository<Password>().Queryable().Where(p=> p.Password1 == password).FirstOrDefault();

        //    var lstx = lstPass
        //        .Queryable()
        //        .Where(p => p.IdUsuario == oUser.Id)
        //        .Where(p => p.IdPassword == oPass.Id)
        //        .FirstOrDefault();


        //    var lst = repository
        //        .Queryable()
        //        .Where(u => u.AccountName == nomUsuario)
        //        //.SelectMany(u => u.UserPasswords.Where(p => p.Password.Password1 == password))
        //        .Select(u => u.UserPasswords.Where(p => p.Password.Password1 == password));
        //        //.FirstOrDefault();

        //    return oUser;
        //}


        #endregion
    }
}
