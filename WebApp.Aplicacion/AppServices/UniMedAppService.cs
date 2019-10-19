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
    
    public sealed partial class UniMedAppService : IUniMedAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IUniMedRepository _repositoryUniMed;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of UniMed application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public UniMedAppService(IUniMedRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUniMed = repository;
        }
    
    	/// <summary>
        /// Create a new instance of UniMed application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public UniMedAppService(IUniMedRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUniMed = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public UniMed Find(params object[] keyValues)
    	{
            Dominio.Entidades.UniMed data = null;
    
            try
            {
                //if (session != null)
                // _repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryUniMed.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<UniMed>(data);
    		return data;
    	}
    
    	public bool Insert(UniMed item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUniMed.Insert(Mapper.Map<Dominio.Entidades.UniMed>(item));
                    _repositoryUniMed.Insert(item);
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
    
    	public bool Update(UniMed item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUniMed.Update(Mapper.Map<Dominio.Entidades.UniMed>(item));
                    _repositoryUniMed.Update(item);
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
    		//_repositoryUniMed.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryUniMed.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryUniMed.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(UniMed item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryUniMed.Delete(Mapper.Map<Dominio.Entidades.UniMed>(item));
                _repositoryUniMed.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<UniMed> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryUniMed.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(UniMed entity) 
    	{ 
    	_repositoryUniMed.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<UniMed> entities) 
    	{ 
    	_repositoryUniMed.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(UniMed entity) { _repositoryUniMed.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<UniMed> entities) { _repositoryUniMed.InsertGraphRange(entities); }
    
    	public IQueryFluent<UniMed> Query() 
    	{ 
    	return _repositoryUniMed.Query(); 
    	}
    
    	public IQueryFluent<UniMed> Query(IQueryObject<UniMed> queryObject)
    	{ 
    	return _repositoryUniMed.Query(queryObject); 
    	}
    
    	public IQueryFluent<UniMed> Query(Expression<Func<UniMed, bool>> query) 
    	{ 
    	return _repositoryUniMed.Query(query); 
    	}
    
    	public async Task<UniMed> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryUniMed.FindAsync(keyValues); 
    	}
    
    	public async Task<UniMed> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUniMed.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUniMed.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<UniMed> Queryable() 
    	{ 
    	return _repositoryUniMed.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<UniMed> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUniMed Begin"));
    
    		List<Dominio.Entidades.UniMed> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryUniMed.Queryable().ToList();
    			data = _repositoryUniMed.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUniMed ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUniMed End"));
    	
    		//return Mapper.Map<List<UniMed>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<UniMed> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUniMed Begin"));		
    		List<Dominio.Entidades.UniMed> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.UniMed>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryUniMed.AllMatching(mapperExp, includes);
                var UniMedDetails = _repositoryUniMed
    				.Query(new UniMedQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = UniMedDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUniMed ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUniMed End"));
            //return Mapper.Map<List<UniMed>>(data);
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
        public PagedCollection<UniMed> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUniMed Begin"));
    		PagedCollection<Dominio.Entidades.UniMed> data = null;
    		List<Dominio.Entidades.UniMed> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUniMed.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.UniMed>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryUniMed.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var UniMedDetails = _repositoryUniMed
    				.Query(new UniMedQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=UniMedDetails.ToList();
                data = new PagedCollection<UniMed> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUniMed ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUniMed End"));
    
            //return Mapper.Map<PagedCollection<UniMed>>(data);
    		//return new PagedCollection<<UniMed>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
