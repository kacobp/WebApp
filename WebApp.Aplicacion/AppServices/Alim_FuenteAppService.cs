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
    
    public sealed partial class Alim_FuenteAppService : IAlim_FuenteAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IAlim_FuenteRepository _repositoryAlim_Fuente;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Alim_Fuente application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public Alim_FuenteAppService(IAlim_FuenteRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryAlim_Fuente = repository;
        }
    
    	/// <summary>
        /// Create a new instance of Alim_Fuente application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public Alim_FuenteAppService(IAlim_FuenteRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryAlim_Fuente = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public Alim_Fuente Find(params object[] keyValues)
    	{
            Dominio.Entidades.Alim_Fuente data = null;
    
            try
            {
                //if (session != null)
                // _repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryAlim_Fuente.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Alim_Fuente>(data);
    		return data;
    	}
    
    	public bool Insert(Alim_Fuente item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryAlim_Fuente.Insert(Mapper.Map<Dominio.Entidades.Alim_Fuente>(item));
                    _repositoryAlim_Fuente.Insert(item);
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
    
    	public bool Update(Alim_Fuente item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryAlim_Fuente.Update(Mapper.Map<Dominio.Entidades.Alim_Fuente>(item));
                    _repositoryAlim_Fuente.Update(item);
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
    		//_repositoryAlim_Fuente.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryAlim_Fuente.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryAlim_Fuente.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Alim_Fuente item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryAlim_Fuente.Delete(Mapper.Map<Dominio.Entidades.Alim_Fuente>(item));
                _repositoryAlim_Fuente.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Alim_Fuente> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryAlim_Fuente.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Alim_Fuente entity) 
    	{ 
    	_repositoryAlim_Fuente.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Alim_Fuente> entities) 
    	{ 
    	_repositoryAlim_Fuente.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Alim_Fuente entity) { _repositoryAlim_Fuente.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Alim_Fuente> entities) { _repositoryAlim_Fuente.InsertGraphRange(entities); }
    
    	public IQueryFluent<Alim_Fuente> Query() 
    	{ 
    	return _repositoryAlim_Fuente.Query(); 
    	}
    
    	public IQueryFluent<Alim_Fuente> Query(IQueryObject<Alim_Fuente> queryObject)
    	{ 
    	return _repositoryAlim_Fuente.Query(queryObject); 
    	}
    
    	public IQueryFluent<Alim_Fuente> Query(Expression<Func<Alim_Fuente, bool>> query) 
    	{ 
    	return _repositoryAlim_Fuente.Query(query); 
    	}
    
    	public async Task<Alim_Fuente> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryAlim_Fuente.FindAsync(keyValues); 
    	}
    
    	public async Task<Alim_Fuente> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryAlim_Fuente.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryAlim_Fuente.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Alim_Fuente> Queryable() 
    	{ 
    	return _repositoryAlim_Fuente.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Alim_Fuente> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAlim_Fuente Begin"));
    
    		List<Dominio.Entidades.Alim_Fuente> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryAlim_Fuente.Queryable().ToList();
    			data = _repositoryAlim_Fuente.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAlim_Fuente ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllAlim_Fuente End"));
    	
    		//return Mapper.Map<List<Alim_Fuente>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Alim_Fuente> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAlim_Fuente Begin"));		
    		List<Dominio.Entidades.Alim_Fuente> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Alim_Fuente>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryAlim_Fuente.AllMatching(mapperExp, includes);
                var Alim_FuenteDetails = _repositoryAlim_Fuente
    				.Query(new Alim_FuenteQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = Alim_FuenteDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAlim_Fuente ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterAlim_Fuente End"));
            //return Mapper.Map<List<Alim_Fuente>>(data);
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
        public PagedCollection<Alim_Fuente> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAlim_Fuente Begin"));
    		PagedCollection<Dominio.Entidades.Alim_Fuente> data = null;
    		List<Dominio.Entidades.Alim_Fuente> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryAlim_Fuente.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Alim_Fuente>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryAlim_Fuente.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var Alim_FuenteDetails = _repositoryAlim_Fuente
    				.Query(new Alim_FuenteQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=Alim_FuenteDetails.ToList();
                data = new PagedCollection<Alim_Fuente> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAlim_Fuente ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterAlim_Fuente End"));
    
            //return Mapper.Map<PagedCollection<Alim_Fuente>>(data);
    		//return new PagedCollection<<Alim_Fuente>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
