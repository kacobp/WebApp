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
    
    public sealed partial class PermisosUsuarioAppService : IPermisosUsuarioAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IPermisosUsuarioRepository _repositoryPermisosUsuario;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of PermisosUsuario application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public PermisosUsuarioAppService(IPermisosUsuarioRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryPermisosUsuario = repository;
        }
    
    	/// <summary>
        /// Create a new instance of PermisosUsuario application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public PermisosUsuarioAppService(IPermisosUsuarioRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryPermisosUsuario = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public PermisosUsuario Find(params object[] keyValues)
    	{
            Dominio.Entidades.PermisosUsuario data = null;
    
            try
            {
                //if (session != null)
                // _repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryPermisosUsuario.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<PermisosUsuario>(data);
    		return data;
    	}
    
    	public bool Insert(PermisosUsuario item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryPermisosUsuario.Insert(Mapper.Map<Dominio.Entidades.PermisosUsuario>(item));
                    _repositoryPermisosUsuario.Insert(item);
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
    
    	public bool Update(PermisosUsuario item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryPermisosUsuario.Update(Mapper.Map<Dominio.Entidades.PermisosUsuario>(item));
                    _repositoryPermisosUsuario.Update(item);
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
    		//_repositoryPermisosUsuario.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryPermisosUsuario.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryPermisosUsuario.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(PermisosUsuario item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryPermisosUsuario.Delete(Mapper.Map<Dominio.Entidades.PermisosUsuario>(item));
                _repositoryPermisosUsuario.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<PermisosUsuario> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryPermisosUsuario.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(PermisosUsuario entity) 
    	{ 
    	_repositoryPermisosUsuario.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<PermisosUsuario> entities) 
    	{ 
    	_repositoryPermisosUsuario.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(PermisosUsuario entity) { _repositoryPermisosUsuario.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<PermisosUsuario> entities) { _repositoryPermisosUsuario.InsertGraphRange(entities); }
    
    	public IQueryFluent<PermisosUsuario> Query() 
    	{ 
    	return _repositoryPermisosUsuario.Query(); 
    	}
    
    	public IQueryFluent<PermisosUsuario> Query(IQueryObject<PermisosUsuario> queryObject)
    	{ 
    	return _repositoryPermisosUsuario.Query(queryObject); 
    	}
    
    	public IQueryFluent<PermisosUsuario> Query(Expression<Func<PermisosUsuario, bool>> query) 
    	{ 
    	return _repositoryPermisosUsuario.Query(query); 
    	}
    
    	public async Task<PermisosUsuario> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryPermisosUsuario.FindAsync(keyValues); 
    	}
    
    	public async Task<PermisosUsuario> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryPermisosUsuario.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryPermisosUsuario.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<PermisosUsuario> Queryable() 
    	{ 
    	return _repositoryPermisosUsuario.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<PermisosUsuario> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPermisosUsuario Begin"));
    
    		List<Dominio.Entidades.PermisosUsuario> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryPermisosUsuario.Queryable().ToList();
    			data = _repositoryPermisosUsuario.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPermisosUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllPermisosUsuario End"));
    	
    		//return Mapper.Map<List<PermisosUsuario>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<PermisosUsuario> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPermisosUsuario Begin"));		
    		List<Dominio.Entidades.PermisosUsuario> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.PermisosUsuario>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryPermisosUsuario.AllMatching(mapperExp, includes);
                var PermisosUsuarioDetails = _repositoryPermisosUsuario
    				.Query(new PermisosUsuarioQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = PermisosUsuarioDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPermisosUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterPermisosUsuario End"));
            //return Mapper.Map<List<PermisosUsuario>>(data);
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
        public PagedCollection<PermisosUsuario> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPermisosUsuario Begin"));
    		PagedCollection<Dominio.Entidades.PermisosUsuario> data = null;
    		List<Dominio.Entidades.PermisosUsuario> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryPermisosUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.PermisosUsuario>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryPermisosUsuario.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var PermisosUsuarioDetails = _repositoryPermisosUsuario
    				.Query(new PermisosUsuarioQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=PermisosUsuarioDetails.ToList();
                data = new PagedCollection<PermisosUsuario> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPermisosUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterPermisosUsuario End"));
    
            //return Mapper.Map<PagedCollection<PermisosUsuario>>(data);
    		//return new PagedCollection<<PermisosUsuario>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
