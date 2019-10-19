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
    
    public sealed partial class UserPhotosAppService : IUserPhotosAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IUserPhotosRepository _repositoryUserPhotos;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of UserPhotos application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public UserPhotosAppService(IUserPhotosRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUserPhotos = repository;
        }
    
    	/// <summary>
        /// Create a new instance of UserPhotos application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public UserPhotosAppService(IUserPhotosRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUserPhotos = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public UserPhotos Find(params object[] keyValues)
    	{
            Dominio.Entidades.UserPhotos data = null;
    
            try
            {
                //if (session != null)
                // _repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryUserPhotos.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<UserPhotos>(data);
    		return data;
    	}
    
    	public bool Insert(UserPhotos item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUserPhotos.Insert(Mapper.Map<Dominio.Entidades.UserPhotos>(item));
                    _repositoryUserPhotos.Insert(item);
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
    
    	public bool Update(UserPhotos item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUserPhotos.Update(Mapper.Map<Dominio.Entidades.UserPhotos>(item));
                    _repositoryUserPhotos.Update(item);
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
    		//_repositoryUserPhotos.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryUserPhotos.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryUserPhotos.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(UserPhotos item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryUserPhotos.Delete(Mapper.Map<Dominio.Entidades.UserPhotos>(item));
                _repositoryUserPhotos.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<UserPhotos> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryUserPhotos.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(UserPhotos entity) 
    	{ 
    	_repositoryUserPhotos.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<UserPhotos> entities) 
    	{ 
    	_repositoryUserPhotos.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(UserPhotos entity) { _repositoryUserPhotos.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<UserPhotos> entities) { _repositoryUserPhotos.InsertGraphRange(entities); }
    
    	public IQueryFluent<UserPhotos> Query() 
    	{ 
    	return _repositoryUserPhotos.Query(); 
    	}
    
    	public IQueryFluent<UserPhotos> Query(IQueryObject<UserPhotos> queryObject)
    	{ 
    	return _repositoryUserPhotos.Query(queryObject); 
    	}
    
    	public IQueryFluent<UserPhotos> Query(Expression<Func<UserPhotos, bool>> query) 
    	{ 
    	return _repositoryUserPhotos.Query(query); 
    	}
    
    	public async Task<UserPhotos> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryUserPhotos.FindAsync(keyValues); 
    	}
    
    	public async Task<UserPhotos> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUserPhotos.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUserPhotos.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<UserPhotos> Queryable() 
    	{ 
    	return _repositoryUserPhotos.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<UserPhotos> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUserPhotos Begin"));
    
    		List<Dominio.Entidades.UserPhotos> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryUserPhotos.Queryable().ToList();
    			data = _repositoryUserPhotos.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUserPhotos ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUserPhotos End"));
    	
    		//return Mapper.Map<List<UserPhotos>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<UserPhotos> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUserPhotos Begin"));		
    		List<Dominio.Entidades.UserPhotos> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.UserPhotos>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryUserPhotos.AllMatching(mapperExp, includes);
                var UserPhotosDetails = _repositoryUserPhotos
    				.Query(new UserPhotosQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = UserPhotosDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUserPhotos ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUserPhotos End"));
            //return Mapper.Map<List<UserPhotos>>(data);
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
        public PagedCollection<UserPhotos> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUserPhotos Begin"));
    		PagedCollection<Dominio.Entidades.UserPhotos> data = null;
    		List<Dominio.Entidades.UserPhotos> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUserPhotos.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.UserPhotos>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryUserPhotos.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var UserPhotosDetails = _repositoryUserPhotos
    				.Query(new UserPhotosQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=UserPhotosDetails.ToList();
                data = new PagedCollection<UserPhotos> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUserPhotos ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUserPhotos End"));
    
            //return Mapper.Map<PagedCollection<UserPhotos>>(data);
    		//return new PagedCollection<<UserPhotos>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
