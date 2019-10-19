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
    
    public sealed partial class Alim_GrpAppService : IAlim_GrpAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IAlim_GrpRepository _repositoryAlim_Grp;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Alim_Grp application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public Alim_GrpAppService(IAlim_GrpRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryAlim_Grp = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Alim_Grp application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public Alim_GrpAppService(IAlim_GrpRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryAlim_Grp = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Alim_Grp Find(params object[] keyValues)
    	{
            Dominio.Entidades.Alim_Grp data = null;
    
            try
            {
                //if (session != null)
                // _repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryAlim_Grp.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Alim_Grp>(data);
    		return data;
    	}
    
    	public bool Insert(Alim_Grp item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryAlim_Grp.Insert(Mapper.Map<Dominio.Entidades.Alim_Grp>(item));
                    _repositoryAlim_Grp.Insert(item);
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
    
    	public bool Update(Alim_Grp item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryAlim_Grp.Update(Mapper.Map<Dominio.Entidades.Alim_Grp>(item));
                    _repositoryAlim_Grp.Update(item);
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
    		//_repositoryAlim_Grp.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryAlim_Grp.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryAlim_Grp.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Alim_Grp item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryAlim_Grp.Delete(Mapper.Map<Dominio.Entidades.Alim_Grp>(item));
                _repositoryAlim_Grp.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Alim_Grp> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryAlim_Grp.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Alim_Grp entity) 
    	{ 
    	_repositoryAlim_Grp.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Alim_Grp> entities) 
    	{ 
    	_repositoryAlim_Grp.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Alim_Grp entity) { _repositoryAlim_Grp.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Alim_Grp> entities) { _repositoryAlim_Grp.InsertGraphRange(entities); }
    
    	public IQueryFluent<Alim_Grp> Query() 
    	{ 
    	return _repositoryAlim_Grp.Query(); 
    	}
    
    	public IQueryFluent<Alim_Grp> Query(IQueryObject<Alim_Grp> queryObject)
    	{ 
    	return _repositoryAlim_Grp.Query(queryObject); 
    	}
    
    	public IQueryFluent<Alim_Grp> Query(Expression<Func<Alim_Grp, bool>> query) 
    	{ 
    	return _repositoryAlim_Grp.Query(query); 
    	}
    
    	public async Task<Alim_Grp> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryAlim_Grp.FindAsync(keyValues); 
    	}
    
    	public async Task<Alim_Grp> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryAlim_Grp.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryAlim_Grp.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Alim_Grp> Queryable() 
    	{ 
    	return _repositoryAlim_Grp.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Alim_Grp> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAlim_Grp Begin"));
    
    		List<Dominio.Entidades.Alim_Grp> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryAlim_Grp.Queryable().ToList();
    			data = _repositoryAlim_Grp.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAlim_Grp ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAlim_Grp End"));
    	
    		//return Mapper.Map<List<Alim_Grp>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Alim_Grp> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAlim_Grp Begin"));		
    		List<Dominio.Entidades.Alim_Grp> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Alim_Grp>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryAlim_Grp.AllMatching(mapperExp, includes);
                var Alim_GrpDetails = _repositoryAlim_Grp
    				.Query(new Alim_GrpQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = Alim_GrpDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAlim_Grp ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAlim_Grp End"));
            //return Mapper.Map<List<Alim_Grp>>(data);
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
        public PagedCollection<Alim_Grp> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAlim_Grp Begin"));
    		PagedCollection<Dominio.Entidades.Alim_Grp> data = null;
    		List<Dominio.Entidades.Alim_Grp> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryAlim_Grp.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Alim_Grp>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryAlim_Grp.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var Alim_GrpDetails = _repositoryAlim_Grp
    				.Query(new Alim_GrpQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=Alim_GrpDetails.ToList();
                data = new PagedCollection<Alim_Grp> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAlim_Grp ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAlim_Grp End"));
    
            //return Mapper.Map<PagedCollection<Alim_Grp>>(data);
    		//return new PagedCollection<<Alim_Grp>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
