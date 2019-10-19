using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp.Dominio.Core.DataContext
{
    [Obsolete("IDataContextAsync has been deprecated. Instead use UnitOfWork which uses DbContext.")]
    public interface IDataContextAsync : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}