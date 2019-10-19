using System;
using TrackableEntities;

namespace WebApp.Dominio.Core.DataContext
{
    [Obsolete("IDataContext has been deprecated. Instead use UnitOfWork which uses DbContext.")]
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<TEntity>(TEntity entity) where TEntity : class, ITrackable;
        void SyncObjectsStatePostCommit();
    }
}