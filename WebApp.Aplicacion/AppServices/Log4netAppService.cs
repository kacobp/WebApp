#region Using Directives

using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Aplicacion.Core;
//using WebApp.Aplicacion.Dtos;
using WebApp.Aplicacion.Resx;
using WebApp.Datos.Repository;
using WebApp.Dominio.Core.Repositories;
using WebApp.Dominio.Core.UnitOfWork;
using WebApp.Dominio.Entidades;
using WebApp.Dominio.IRepository;
using WebApp.Transversales;
using WebApp.Transversales.Extensions;
using WebApp.Transversales.Validator;

#endregion

namespace WebApp.Aplicacion.AppServices
{
    using System;
    
    public sealed partial class Log4netAppService : ILog4netAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ILog4netRepository _repositoryLog4net;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Log4net application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public Log4netAppService(ILog4netRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryLog4net = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Log4net application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public Log4netAppService(ILog4netRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryLog4net = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Log4net Find(params object[] keyValues)
    	{
            Dominio.Entidades.Log4net data = null;
    
            try
            {
                //if (session != null)
                // _repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryLog4net.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Log4net>(data);
    		return data;
    	}
    
    	public bool Insert(Log4net item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryLog4net.Insert(Mapper.Map<Dominio.Entidades.Log4net>(item));
                    _repositoryLog4net.Insert(item);
                    committed = _unitOfWorkAsync.SaveChanges();
                }
                else
                    throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;		
    	}
    
    	public bool Update(Log4net item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryLog4net.Update(Mapper.Map<Dominio.Entidades.Log4net>(item));
                    _repositoryLog4net.Update(item);
                    committed = _unitOfWorkAsync.SaveChanges();
                }
                else
                    throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryLog4net.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryLog4net.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryLog4net.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Log4net item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryLog4net.Delete(Mapper.Map<Dominio.Entidades.Log4net>(item));
                _repositoryLog4net.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Log4net> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryLog4net.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Log4net entity) 
    	{ 
    	_repositoryLog4net.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Log4net> entities) 
    	{ 
    	_repositoryLog4net.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Log4net entity) { _repositoryLog4net.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Log4net> entities) { _repositoryLog4net.InsertGraphRange(entities); }
    
    	public IQueryFluent<Log4net> Query() 
    	{ 
    	return _repositoryLog4net.Query(); 
    	}
    
    	public IQueryFluent<Log4net> Query(IQueryObject<Log4net> queryObject)
    	{ 
    	return _repositoryLog4net.Query(queryObject); 
    	}
    
    	public IQueryFluent<Log4net> Query(Expression<Func<Log4net, bool>> query) 
    	{ 
    	return _repositoryLog4net.Query(query); 
    	}
    
    	public async Task<Log4net> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryLog4net.FindAsync(keyValues); 
    	}
    
    	public async Task<Log4net> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryLog4net.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryLog4net.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Log4net> Queryable() 
    	{ 
    	return _repositoryLog4net.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Log4net> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllLog4net Begin"));
    
    		List<Dominio.Entidades.Log4net> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryLog4net.Queryable().ToList();
    			data = _repositoryLog4net.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllLog4net ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllLog4net End"));
    	
    		//return Mapper.Map<List<Log4net>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Log4net> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterLog4net Begin"));		
    		List<Dominio.Entidades.Log4net> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Log4net>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryLog4net.AllMatching(mapperExp, includes);
                var Log4netDetails = _repositoryLog4net
    				.Query(new Log4netQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = Log4netDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterLog4net ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterLog4net End"));
            //return Mapper.Map<List<Log4net>>(data);
            return data;
        }
    
        /// <summary>
        /// Find by filter paged
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="pageGo">Go to page</param>
        /// <param name="pageSize">Items request</param>
        /// <param name="orderBy">Fields order</param>
        /// <param name="ascending">Order ascendent</param>
        /// <param name="session">Session</param>
    	/// <returns>Paged results</returns>
        public PagedCollection<Log4net> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterLog4net Begin"));
    		PagedCollection<Dominio.Entidades.Log4net> data = null;
    		List<Dominio.Entidades.Log4net> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryLog4net.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Log4net>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryLog4net.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var Log4netDetails = _repositoryLog4net
    				.Query(new Log4netQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=Log4netDetails.ToList();
                data = new PagedCollection<Log4net> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterLog4net ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterLog4net End"));
    
            //return Mapper.Map<PagedCollection<Log4net>>(data);
    		//return new PagedCollection<<Log4net>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
