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
    
    public sealed partial class LoginAttemptsAppService : ILoginAttemptsAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ILoginAttemptsRepository _repositoryLoginAttempts;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of LoginAttempts application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public LoginAttemptsAppService(ILoginAttemptsRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryLoginAttempts = repository;
        }
    
    	/// <summary>
        /// Create a new instance of LoginAttempts application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public LoginAttemptsAppService(ILoginAttemptsRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryLoginAttempts = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public LoginAttempts Find(params object[] keyValues)
    	{
            Dominio.Entidades.LoginAttempts data = null;
    
            try
            {
                //if (session != null)
                // _repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryLoginAttempts.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<LoginAttempts>(data);
    		return data;
    	}
    
    	public bool Insert(LoginAttempts item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryLoginAttempts.Insert(Mapper.Map<Dominio.Entidades.LoginAttempts>(item));
                    _repositoryLoginAttempts.Insert(item);
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
    
    	public bool Update(LoginAttempts item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryLoginAttempts.Update(Mapper.Map<Dominio.Entidades.LoginAttempts>(item));
                    _repositoryLoginAttempts.Update(item);
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
    		//_repositoryLoginAttempts.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryLoginAttempts.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryLoginAttempts.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(LoginAttempts item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryLoginAttempts.Delete(Mapper.Map<Dominio.Entidades.LoginAttempts>(item));
                _repositoryLoginAttempts.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<LoginAttempts> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryLoginAttempts.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(LoginAttempts entity) 
    	{ 
    	_repositoryLoginAttempts.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<LoginAttempts> entities) 
    	{ 
    	_repositoryLoginAttempts.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(LoginAttempts entity) { _repositoryLoginAttempts.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<LoginAttempts> entities) { _repositoryLoginAttempts.InsertGraphRange(entities); }
    
    	public IQueryFluent<LoginAttempts> Query() 
    	{ 
    	return _repositoryLoginAttempts.Query(); 
    	}
    
    	public IQueryFluent<LoginAttempts> Query(IQueryObject<LoginAttempts> queryObject)
    	{ 
    	return _repositoryLoginAttempts.Query(queryObject); 
    	}
    
    	public IQueryFluent<LoginAttempts> Query(Expression<Func<LoginAttempts, bool>> query) 
    	{ 
    	return _repositoryLoginAttempts.Query(query); 
    	}
    
    	public async Task<LoginAttempts> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryLoginAttempts.FindAsync(keyValues); 
    	}
    
    	public async Task<LoginAttempts> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryLoginAttempts.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryLoginAttempts.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<LoginAttempts> Queryable() 
    	{ 
    	return _repositoryLoginAttempts.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<LoginAttempts> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllLoginAttempts Begin"));
    
    		List<Dominio.Entidades.LoginAttempts> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryLoginAttempts.Queryable().ToList();
    			data = _repositoryLoginAttempts.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllLoginAttempts ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllLoginAttempts End"));
    	
    		//return Mapper.Map<List<LoginAttempts>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<LoginAttempts> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterLoginAttempts Begin"));		
    		List<Dominio.Entidades.LoginAttempts> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.LoginAttempts>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryLoginAttempts.AllMatching(mapperExp, includes);
                var LoginAttemptsDetails = _repositoryLoginAttempts
    				.Query(new LoginAttemptsQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = LoginAttemptsDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterLoginAttempts ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterLoginAttempts End"));
            //return Mapper.Map<List<LoginAttempts>>(data);
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
        public PagedCollection<LoginAttempts> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterLoginAttempts Begin"));
    		PagedCollection<Dominio.Entidades.LoginAttempts> data = null;
    		List<Dominio.Entidades.LoginAttempts> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryLoginAttempts.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.LoginAttempts>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryLoginAttempts.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var LoginAttemptsDetails = _repositoryLoginAttempts
    				.Query(new LoginAttemptsQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=LoginAttemptsDetails.ToList();
                data = new PagedCollection<LoginAttempts> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterLoginAttempts ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterLoginAttempts End"));
    
            //return Mapper.Map<PagedCollection<LoginAttempts>>(data);
    		//return new PagedCollection<<LoginAttempts>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
