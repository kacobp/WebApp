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
    
    public sealed partial class UserPasswordsAppService : IUserPasswordsAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IUserPasswordsRepository _repositoryUserPasswords;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of UserPasswords application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public UserPasswordsAppService(IUserPasswordsRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUserPasswords = repository;
        }
    
    	/// <summary>
        /// Create a new instance of UserPasswords application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public UserPasswordsAppService(IUserPasswordsRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUserPasswords = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public UserPasswords Find(params object[] keyValues)
    	{
            Dominio.Entidades.UserPasswords data = null;
    
            try
            {
                //if (session != null)
                // _repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryUserPasswords.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<UserPasswords>(data);
    		return data;
    	}
    
    	public bool Insert(UserPasswords item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUserPasswords.Insert(Mapper.Map<Dominio.Entidades.UserPasswords>(item));
                    _repositoryUserPasswords.Insert(item);
                    //committed = _unitOfWorkAsync.SaveChanges();
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
    
    	public bool Update(UserPasswords item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUserPasswords.Update(Mapper.Map<Dominio.Entidades.UserPasswords>(item));
                    _repositoryUserPasswords.Update(item);
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
    		//_repositoryUserPasswords.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryUserPasswords.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryUserPasswords.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(UserPasswords item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryUserPasswords.Delete(Mapper.Map<Dominio.Entidades.UserPasswords>(item));
                _repositoryUserPasswords.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<UserPasswords> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryUserPasswords.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(UserPasswords entity) 
    	{ 
    	_repositoryUserPasswords.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<UserPasswords> entities) 
    	{ 
    	_repositoryUserPasswords.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(UserPasswords entity) { _repositoryUserPasswords.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<UserPasswords> entities) { _repositoryUserPasswords.InsertGraphRange(entities); }
    
    	public IQueryFluent<UserPasswords> Query() 
    	{ 
    	return _repositoryUserPasswords.Query(); 
    	}
    
    	public IQueryFluent<UserPasswords> Query(IQueryObject<UserPasswords> queryObject)
    	{ 
    	return _repositoryUserPasswords.Query(queryObject); 
    	}
    
    	public IQueryFluent<UserPasswords> Query(Expression<Func<UserPasswords, bool>> query) 
    	{ 
    	return _repositoryUserPasswords.Query(query); 
    	}
    
    	public async Task<UserPasswords> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryUserPasswords.FindAsync(keyValues); 
    	}
    
    	public async Task<UserPasswords> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUserPasswords.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUserPasswords.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<UserPasswords> Queryable() 
    	{ 
    	return _repositoryUserPasswords.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<UserPasswords> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUserPasswords Begin"));
    
    		List<Dominio.Entidades.UserPasswords> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryUserPasswords.Queryable().ToList();
    			data = _repositoryUserPasswords.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUserPasswords ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUserPasswords End"));
    	
    		//return Mapper.Map<List<UserPasswords>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<UserPasswords> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUserPasswords Begin"));		
    		List<Dominio.Entidades.UserPasswords> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.UserPasswords>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryUserPasswords.AllMatching(mapperExp, includes);
                var UserPasswordsDetails = _repositoryUserPasswords
    				.Query(new UserPasswordsQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = UserPasswordsDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUserPasswords ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUserPasswords End"));
            //return Mapper.Map<List<UserPasswords>>(data);
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
        public PagedCollection<UserPasswords> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUserPasswords Begin"));
    		PagedCollection<Dominio.Entidades.UserPasswords> data = null;
    		List<Dominio.Entidades.UserPasswords> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUserPasswords.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.UserPasswords>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryUserPasswords.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var UserPasswordsDetails = _repositoryUserPasswords
    				.Query(new UserPasswordsQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=UserPasswordsDetails.ToList();
                data = new PagedCollection<UserPasswords> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUserPasswords ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUserPasswords End"));
    
            //return Mapper.Map<PagedCollection<UserPasswords>>(data);
    		//return new PagedCollection<<UserPasswords>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
