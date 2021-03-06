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
    
    public sealed partial class Nt_CantAppService : INt_CantAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly INt_CantRepository _repositoryNt_Cant;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Cant application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public Nt_CantAppService(INt_CantRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryNt_Cant = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Nt_Cant application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public Nt_CantAppService(INt_CantRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryNt_Cant = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Nt_Cant Find(params object[] keyValues)
    	{
            Dominio.Entidades.Nt_Cant data = null;
    
            try
            {
                //if (session != null)
                // _repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryNt_Cant.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Nt_Cant>(data);
    		return data;
    	}
    
    	public bool Insert(Nt_Cant item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryNt_Cant.Insert(Mapper.Map<Dominio.Entidades.Nt_Cant>(item));
                    _repositoryNt_Cant.Insert(item);
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
    
    	public bool Update(Nt_Cant item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryNt_Cant.Update(Mapper.Map<Dominio.Entidades.Nt_Cant>(item));
                    _repositoryNt_Cant.Update(item);
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
    		//_repositoryNt_Cant.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryNt_Cant.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryNt_Cant.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Nt_Cant item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryNt_Cant.Delete(Mapper.Map<Dominio.Entidades.Nt_Cant>(item));
                _repositoryNt_Cant.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Nt_Cant> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryNt_Cant.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Nt_Cant entity) 
    	{ 
    	_repositoryNt_Cant.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Nt_Cant> entities) 
    	{ 
    	_repositoryNt_Cant.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Nt_Cant entity) { _repositoryNt_Cant.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Nt_Cant> entities) { _repositoryNt_Cant.InsertGraphRange(entities); }
    
    	public IQueryFluent<Nt_Cant> Query() 
    	{ 
    	return _repositoryNt_Cant.Query(); 
    	}
    
    	public IQueryFluent<Nt_Cant> Query(IQueryObject<Nt_Cant> queryObject)
    	{ 
    	return _repositoryNt_Cant.Query(queryObject); 
    	}
    
    	public IQueryFluent<Nt_Cant> Query(Expression<Func<Nt_Cant, bool>> query) 
    	{ 
    	return _repositoryNt_Cant.Query(query); 
    	}
    
    	public async Task<Nt_Cant> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryNt_Cant.FindAsync(keyValues); 
    	}
    
    	public async Task<Nt_Cant> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryNt_Cant.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryNt_Cant.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Nt_Cant> Queryable() 
    	{ 
    	return _repositoryNt_Cant.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Nt_Cant> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Cant Begin"));
    
    		List<Dominio.Entidades.Nt_Cant> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryNt_Cant.Queryable().ToList();
    			data = _repositoryNt_Cant.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Cant ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Cant End"));
    	
    		//return Mapper.Map<List<Nt_Cant>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Nt_Cant> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Cant Begin"));		
    		List<Dominio.Entidades.Nt_Cant> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Nt_Cant>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryNt_Cant.AllMatching(mapperExp, includes);
                var Nt_CantDetails = _repositoryNt_Cant
    				.Query(new Nt_CantQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = Nt_CantDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Cant ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Cant End"));
            //return Mapper.Map<List<Nt_Cant>>(data);
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
        public PagedCollection<Nt_Cant> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Cant Begin"));
    		PagedCollection<Dominio.Entidades.Nt_Cant> data = null;
    		List<Dominio.Entidades.Nt_Cant> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Cant.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Nt_Cant>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryNt_Cant.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var Nt_CantDetails = _repositoryNt_Cant
    				.Query(new Nt_CantQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=Nt_CantDetails.ToList();
                data = new PagedCollection<Nt_Cant> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Cant ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Cant End"));
    
            //return Mapper.Map<PagedCollection<Nt_Cant>>(data);
    		//return new PagedCollection<<Nt_Cant>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
