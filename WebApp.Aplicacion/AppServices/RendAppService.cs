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
    
    public sealed partial class RendAppService : IRendAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IRendRepository _repositoryRend;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Rend application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public RendAppService(IRendRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryRend = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Rend application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public RendAppService(IRendRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryRend = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Rend Find(params object[] keyValues)
    	{
            Dominio.Entidades.Rend data = null;
    
            try
            {
                //if (session != null)
                // _repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryRend.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Rend>(data);
    		return data;
    	}
    
    	public bool Insert(Rend item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryRend.Insert(Mapper.Map<Dominio.Entidades.Rend>(item));
                    _repositoryRend.Insert(item);
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
    
    	public bool Update(Rend item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryRend.Update(Mapper.Map<Dominio.Entidades.Rend>(item));
                    _repositoryRend.Update(item);
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
    		//_repositoryRend.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryRend.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryRend.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Rend item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryRend.Delete(Mapper.Map<Dominio.Entidades.Rend>(item));
                _repositoryRend.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Rend> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryRend.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Rend entity) 
    	{ 
    	_repositoryRend.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Rend> entities) 
    	{ 
    	_repositoryRend.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Rend entity) { _repositoryRend.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Rend> entities) { _repositoryRend.InsertGraphRange(entities); }
    
    	public IQueryFluent<Rend> Query() 
    	{ 
    	return _repositoryRend.Query(); 
    	}
    
    	public IQueryFluent<Rend> Query(IQueryObject<Rend> queryObject)
    	{ 
    	return _repositoryRend.Query(queryObject); 
    	}
    
    	public IQueryFluent<Rend> Query(Expression<Func<Rend, bool>> query) 
    	{ 
    	return _repositoryRend.Query(query); 
    	}
    
    	public async Task<Rend> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryRend.FindAsync(keyValues); 
    	}
    
    	public async Task<Rend> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryRend.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryRend.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Rend> Queryable() 
    	{ 
    	return _repositoryRend.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Rend> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllRend Begin"));
    
    		List<Dominio.Entidades.Rend> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryRend.Queryable().ToList();
    			data = _repositoryRend.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllRend ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllRend End"));
    	
    		//return Mapper.Map<List<Rend>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Rend> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterRend Begin"));		
    		List<Dominio.Entidades.Rend> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Rend>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryRend.AllMatching(mapperExp, includes);
                var RendDetails = _repositoryRend
    				.Query(new RendQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = RendDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterRend ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterRend End"));
            //return Mapper.Map<List<Rend>>(data);
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
        public PagedCollection<Rend> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterRend Begin"));
    		PagedCollection<Dominio.Entidades.Rend> data = null;
    		List<Dominio.Entidades.Rend> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryRend.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Rend>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryRend.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var RendDetails = _repositoryRend
    				.Query(new RendQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=RendDetails.ToList();
                data = new PagedCollection<Rend> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterRend ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterRend End"));
    
            //return Mapper.Map<PagedCollection<Rend>>(data);
    		//return new PagedCollection<<Rend>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
