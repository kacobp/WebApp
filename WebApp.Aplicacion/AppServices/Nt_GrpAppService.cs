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
    
    public sealed partial class Nt_GrpAppService : INt_GrpAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly INt_GrpRepository _repositoryNt_Grp;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Grp application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public Nt_GrpAppService(INt_GrpRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryNt_Grp = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Nt_Grp application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public Nt_GrpAppService(INt_GrpRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryNt_Grp = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Nt_Grp Find(params object[] keyValues)
    	{
            Dominio.Entidades.Nt_Grp data = null;
    
            try
            {
                //if (session != null)
                // _repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryNt_Grp.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Nt_Grp>(data);
    		return data;
    	}
    
    	public bool Insert(Nt_Grp item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryNt_Grp.Insert(Mapper.Map<Dominio.Entidades.Nt_Grp>(item));
                    _repositoryNt_Grp.Insert(item);
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
    
    	public bool Update(Nt_Grp item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryNt_Grp.Update(Mapper.Map<Dominio.Entidades.Nt_Grp>(item));
                    _repositoryNt_Grp.Update(item);
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
    		//_repositoryNt_Grp.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryNt_Grp.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryNt_Grp.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Nt_Grp item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryNt_Grp.Delete(Mapper.Map<Dominio.Entidades.Nt_Grp>(item));
                _repositoryNt_Grp.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Nt_Grp> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryNt_Grp.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Nt_Grp entity) 
    	{ 
    	_repositoryNt_Grp.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Nt_Grp> entities) 
    	{ 
    	_repositoryNt_Grp.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Nt_Grp entity) { _repositoryNt_Grp.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Nt_Grp> entities) { _repositoryNt_Grp.InsertGraphRange(entities); }
    
    	public IQueryFluent<Nt_Grp> Query() 
    	{ 
    	return _repositoryNt_Grp.Query(); 
    	}
    
    	public IQueryFluent<Nt_Grp> Query(IQueryObject<Nt_Grp> queryObject)
    	{ 
    	return _repositoryNt_Grp.Query(queryObject); 
    	}
    
    	public IQueryFluent<Nt_Grp> Query(Expression<Func<Nt_Grp, bool>> query) 
    	{ 
    	return _repositoryNt_Grp.Query(query); 
    	}
    
    	public async Task<Nt_Grp> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryNt_Grp.FindAsync(keyValues); 
    	}
    
    	public async Task<Nt_Grp> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryNt_Grp.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryNt_Grp.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Nt_Grp> Queryable() 
    	{ 
    	return _repositoryNt_Grp.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Nt_Grp> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Grp Begin"));
    
    		List<Dominio.Entidades.Nt_Grp> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryNt_Grp.Queryable().ToList();
    			data = _repositoryNt_Grp.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Grp ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Grp End"));
    	
    		//return Mapper.Map<List<Nt_Grp>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Nt_Grp> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Grp Begin"));		
    		List<Dominio.Entidades.Nt_Grp> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Nt_Grp>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryNt_Grp.AllMatching(mapperExp, includes);
                var Nt_GrpDetails = _repositoryNt_Grp
    				.Query(new Nt_GrpQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = Nt_GrpDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Grp ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Grp End"));
            //return Mapper.Map<List<Nt_Grp>>(data);
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
        public PagedCollection<Nt_Grp> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Grp Begin"));
    		PagedCollection<Dominio.Entidades.Nt_Grp> data = null;
    		List<Dominio.Entidades.Nt_Grp> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Nt_Grp>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryNt_Grp.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var Nt_GrpDetails = _repositoryNt_Grp
    				.Query(new Nt_GrpQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=Nt_GrpDetails.ToList();
                data = new PagedCollection<Nt_Grp> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Grp ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Grp End"));
    
            //return Mapper.Map<PagedCollection<Nt_Grp>>(data);
    		//return new PagedCollection<<Nt_Grp>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
