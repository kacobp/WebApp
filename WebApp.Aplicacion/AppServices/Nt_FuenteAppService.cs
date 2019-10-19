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
    
    public sealed partial class Nt_FuenteAppService : INt_FuenteAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly INt_FuenteRepository _repositoryNt_Fuente;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Fuente application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public Nt_FuenteAppService(INt_FuenteRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryNt_Fuente = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Nt_Fuente application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public Nt_FuenteAppService(INt_FuenteRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryNt_Fuente = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Nt_Fuente Find(params object[] keyValues)
    	{
            Dominio.Entidades.Nt_Fuente data = null;
    
            try
            {
                //if (session != null)
                // _repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryNt_Fuente.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Nt_Fuente>(data);
    		return data;
    	}
    
    	public bool Insert(Nt_Fuente item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryNt_Fuente.Insert(Mapper.Map<Dominio.Entidades.Nt_Fuente>(item));
                    _repositoryNt_Fuente.Insert(item);
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
    
    	public bool Update(Nt_Fuente item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryNt_Fuente.Update(Mapper.Map<Dominio.Entidades.Nt_Fuente>(item));
                    _repositoryNt_Fuente.Update(item);
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
    		//_repositoryNt_Fuente.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryNt_Fuente.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryNt_Fuente.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Nt_Fuente item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryNt_Fuente.Delete(Mapper.Map<Dominio.Entidades.Nt_Fuente>(item));
                _repositoryNt_Fuente.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Nt_Fuente> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryNt_Fuente.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Nt_Fuente entity) 
    	{ 
    	_repositoryNt_Fuente.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Nt_Fuente> entities) 
    	{ 
    	_repositoryNt_Fuente.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Nt_Fuente entity) { _repositoryNt_Fuente.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Nt_Fuente> entities) { _repositoryNt_Fuente.InsertGraphRange(entities); }
    
    	public IQueryFluent<Nt_Fuente> Query() 
    	{ 
    	return _repositoryNt_Fuente.Query(); 
    	}
    
    	public IQueryFluent<Nt_Fuente> Query(IQueryObject<Nt_Fuente> queryObject)
    	{ 
    	return _repositoryNt_Fuente.Query(queryObject); 
    	}
    
    	public IQueryFluent<Nt_Fuente> Query(Expression<Func<Nt_Fuente, bool>> query) 
    	{ 
    	return _repositoryNt_Fuente.Query(query); 
    	}
    
    	public async Task<Nt_Fuente> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryNt_Fuente.FindAsync(keyValues); 
    	}
    
    	public async Task<Nt_Fuente> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryNt_Fuente.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryNt_Fuente.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Nt_Fuente> Queryable() 
    	{ 
    	return _repositoryNt_Fuente.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Nt_Fuente> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Fuente Begin"));
    
    		List<Dominio.Entidades.Nt_Fuente> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryNt_Fuente.Queryable().ToList();
    			data = _repositoryNt_Fuente.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Fuente ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllNt_Fuente End"));
    	
    		//return Mapper.Map<List<Nt_Fuente>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Nt_Fuente> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Fuente Begin"));		
    		List<Dominio.Entidades.Nt_Fuente> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Nt_Fuente>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryNt_Fuente.AllMatching(mapperExp, includes);
                var Nt_FuenteDetails = _repositoryNt_Fuente
    				.Query(new Nt_FuenteQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = Nt_FuenteDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Fuente ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterNt_Fuente End"));
            //return Mapper.Map<List<Nt_Fuente>>(data);
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
        public PagedCollection<Nt_Fuente> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Fuente Begin"));
    		PagedCollection<Dominio.Entidades.Nt_Fuente> data = null;
    		List<Dominio.Entidades.Nt_Fuente> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryNt_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Nt_Fuente>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryNt_Fuente.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var Nt_FuenteDetails = _repositoryNt_Fuente
    				.Query(new Nt_FuenteQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=Nt_FuenteDetails.ToList();
                data = new PagedCollection<Nt_Fuente> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Fuente ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterNt_Fuente End"));
    
            //return Mapper.Map<PagedCollection<Nt_Fuente>>(data);
    		//return new PagedCollection<<Nt_Fuente>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
