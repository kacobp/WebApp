//===================================================================================
// © CBP - linkedin.com/in/
//===================================================================================

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Dominio.Core.Repositories;
using TrackableEntities;
using WebApp.Transversales;
using WebApp.Transversales.Collection;
using WebApp.Transversales.Extensions;
//using WebApp.Dominio.Entidades;
//using WebApp.Aplicacion.Dtos;

#endregion

namespace WebApp.Aplicacion.Core
{
    public interface IAppService<TEntity> where TEntity : ITrackable
    //public interface IAppService<TEntity> : IDisposable where TEntity : ITrackable
    {
        TEntity Find(params object[] keyValues);
        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        //void Insert(TEntity item);
        bool Insert(TEntity item, Session session);

        void InsertRange(IEnumerable<TEntity> entities);
        //bool InsertRange(IEnumerable<TEntity> items);
        void ApplyChanges(TEntity entity);


        //void Update(TEntity entity);
        bool Update(TEntity item, Session session);

        void Delete(object id);
        //void Delete(TEntity entity);
        bool Delete(TEntity item, Session session);


        IQueryFluent<TEntity> Query();
        IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject);
        IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query);
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        IQueryable<TEntity> Queryable();


        //bool Add(TEntity item, Session session);
        //bool Modify(TEntity item, Session session);
        //bool Remove(TEntity item, Session session);
        //TEntity Get(List<object> keyValues, Session session);
        //IList<TEntity> GetAll(List<string> includes, Session session);
        List<TEntity> GetAll(List<string> includes, Session session);
        List<TEntity> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null);
        PagedCollection<TEntity> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order = "asc", string filterRules = "", Session session = null);


        //Task<bool> ModifyAsync(TEntity item, Session session);
        //Task<bool> RemoveAsync(TEntity item, Session session);
        //Task<TEntity> GetAsync(List<object> keyValues, Session session);
        //Task<bool> AddAsync(TEntity item, Session session);

        //Task<List<TEntity>> GetAllAsync(List<string> includes, Session session);
        //Task<List<TEntity>> FindByFilterAsync(CustomQuery<TEntity> filter, List<string> includes, Session session);
        //PagedList<TEntity> FindPagedByFilter(int page = 1, int rows = 10, string sort = "Id", string order = "asc");

        //Task<PagedCollection<TEntity>> FindPagedByFilterAsync(CustomQuery<TEntity> filter, List<string> includes, int pageGo, int pageSize, List<string> orderBy, bool ascending, Session session);
        //int CountFind(CustomQuery<TEntity> filter, List<string> includes, Session session);
        //Task<int> CountFindAsync(CustomQuery<TEntity> filter, List<string> includes, Session session);
    }
}