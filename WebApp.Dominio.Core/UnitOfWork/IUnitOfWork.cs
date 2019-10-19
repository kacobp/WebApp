using System;
using System.Data;
using WebApp.Dominio.Core.Repositories;
using TrackableEntities;

namespace WebApp.Dominio.Core.UnitOfWork
{
    public interface IUnitOfWork
    {

        /// <summary>
        ///     Sets the connection database.
        /// </summary>
        /// <param name="connectionstring">The connectionstring.</param>
        void SetConnectionDb(string connectionstring);

        int SaveChanges();
        int ExecuteSqlCommand(string sql, params object[] parameters);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class, ITrackable;
        int? CommandTimeout { get; set; }
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}