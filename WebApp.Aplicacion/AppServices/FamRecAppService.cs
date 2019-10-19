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
    
    public sealed partial class FamRecAppService : IFamRecAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IFamRecRepository _repositoryFamRec;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of FamRec application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public FamRecAppService(IFamRecRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryFamRec = repository;
        }
    
    	/// <summary>
        /// Create a new instance of FamRec application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public FamRecAppService(IFamRecRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryFamRec = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public FamRec Find(params object[] keyValues)
    	{
            Dominio.Entidades.FamRec data = null;
    
            try
            {
                //if (session != null)
                // _repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryFamRec.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<FamRec>(data);
    		return data;
    	}
    
    	public bool Insert(FamRec item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryFamRec.Insert(Mapper.Map<Dominio.Entidades.FamRec>(item));
                    _repositoryFamRec.Insert(item);
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
    
    	public bool Update(FamRec item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryFamRec.Update(Mapper.Map<Dominio.Entidades.FamRec>(item));
                    _repositoryFamRec.Update(item);
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
    		//_repositoryFamRec.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryFamRec.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryFamRec.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(FamRec item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryFamRec.Delete(Mapper.Map<Dominio.Entidades.FamRec>(item));
                _repositoryFamRec.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<FamRec> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryFamRec.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(FamRec entity) 
    	{ 
    	_repositoryFamRec.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<FamRec> entities) 
    	{ 
    	_repositoryFamRec.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(FamRec entity) { _repositoryFamRec.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<FamRec> entities) { _repositoryFamRec.InsertGraphRange(entities); }
    
    	public IQueryFluent<FamRec> Query() 
    	{ 
    	return _repositoryFamRec.Query(); 
    	}
    
    	public IQueryFluent<FamRec> Query(IQueryObject<FamRec> queryObject)
    	{ 
    	return _repositoryFamRec.Query(queryObject); 
    	}
    
    	public IQueryFluent<FamRec> Query(Expression<Func<FamRec, bool>> query) 
    	{ 
    	return _repositoryFamRec.Query(query); 
    	}
    
    	public async Task<FamRec> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryFamRec.FindAsync(keyValues); 
    	}
    
    	public async Task<FamRec> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryFamRec.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryFamRec.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<FamRec> Queryable() 
    	{ 
    	return _repositoryFamRec.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<FamRec> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllFamRec Begin"));
    
    		List<Dominio.Entidades.FamRec> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryFamRec.Queryable().ToList();
    			data = _repositoryFamRec.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllFamRec ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllFamRec End"));
    	
    		//return Mapper.Map<List<FamRec>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<FamRec> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterFamRec Begin"));		
    		List<Dominio.Entidades.FamRec> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.FamRec>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryFamRec.AllMatching(mapperExp, includes);
                var FamRecDetails = _repositoryFamRec
    				.Query(new FamRecQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = FamRecDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterFamRec ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterFamRec End"));
            //return Mapper.Map<List<FamRec>>(data);
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
        public PagedCollection<FamRec> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterFamRec Begin"));
    		PagedCollection<Dominio.Entidades.FamRec> data = null;
    		List<Dominio.Entidades.FamRec> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryFamRec.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.FamRec>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryFamRec.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var FamRecDetails = _repositoryFamRec
    				.Query(new FamRecQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=FamRecDetails.ToList();
                data = new PagedCollection<FamRec> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterFamRec ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterFamRec End"));
    
            //return Mapper.Map<PagedCollection<FamRec>>(data);
    		//return new PagedCollection<<FamRec>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
