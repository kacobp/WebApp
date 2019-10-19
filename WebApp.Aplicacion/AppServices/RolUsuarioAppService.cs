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
    
    public sealed partial class RolUsuarioAppService : IRolUsuarioAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IRolUsuarioRepository _repositoryRolUsuario;
        //public static IMapper Mapper {get; private set;}
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of RolUsuario application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public RolUsuarioAppService(IRolUsuarioRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryRolUsuario = repository;
        }
    
    	/// <summary>
        /// Create a new instance of RolUsuario application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public RolUsuarioAppService(IRolUsuarioRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryRolUsuario = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
        }
    
        #endregion
    
    	#region URF Public Methods
    
    	public RolUsuario Find(params object[] keyValues)
    	{
            Dominio.Entidades.RolUsuario data = null;
    
            try
            {
                //if (session != null)
                // _repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryRolUsuario.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<RolUsuario>(data);
    		return data;
    	}
    
    	public bool Insert(RolUsuario item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryRolUsuario.Insert(Mapper.Map<Dominio.Entidades.RolUsuario>(item));
                    _repositoryRolUsuario.Insert(item);
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
    
    	public bool Update(RolUsuario item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryRolUsuario.Update(Mapper.Map<Dominio.Entidades.RolUsuario>(item));
                    _repositoryRolUsuario.Update(item);
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
    		//_repositoryRolUsuario.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryRolUsuario.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryRolUsuario.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(RolUsuario item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryRolUsuario.Delete(Mapper.Map<Dominio.Entidades.RolUsuario>(item));
                _repositoryRolUsuario.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<RolUsuario> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryRolUsuario.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(RolUsuario entity) 
    	{ 
    	_repositoryRolUsuario.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<RolUsuario> entities) 
    	{ 
    	_repositoryRolUsuario.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(RolUsuario entity) { _repositoryRolUsuario.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<RolUsuario> entities) { _repositoryRolUsuario.InsertGraphRange(entities); }
    
    	public IQueryFluent<RolUsuario> Query() 
    	{ 
    	return _repositoryRolUsuario.Query(); 
    	}
    
    	public IQueryFluent<RolUsuario> Query(IQueryObject<RolUsuario> queryObject)
    	{ 
    	return _repositoryRolUsuario.Query(queryObject); 
    	}
    
    	public IQueryFluent<RolUsuario> Query(Expression<Func<RolUsuario, bool>> query) 
    	{ 
    	return _repositoryRolUsuario.Query(query); 
    	}
    
    	public async Task<RolUsuario> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryRolUsuario.FindAsync(keyValues); 
    	}
    
    	public async Task<RolUsuario> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryRolUsuario.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryRolUsuario.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<RolUsuario> Queryable() 
    	{ 
    	return _repositoryRolUsuario.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<RolUsuario> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllRolUsuario Begin"));
    
    		List<Dominio.Entidades.RolUsuario> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryRolUsuario.Queryable().ToList();
    			data = _repositoryRolUsuario.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllRolUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllRolUsuario End"));
    	
    		//return Mapper.Map<List<RolUsuario>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<RolUsuario> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterRolUsuario Begin"));		
    		List<Dominio.Entidades.RolUsuario> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.RolUsuario>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryRolUsuario.AllMatching(mapperExp, includes);
                var RolUsuarioDetails = _repositoryRolUsuario
    				.Query(new RolUsuarioQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = RolUsuarioDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterRolUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterRolUsuario End"));
            //return Mapper.Map<List<RolUsuario>>(data);
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
        public PagedCollection<RolUsuario> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterRolUsuario Begin"));
    		PagedCollection<Dominio.Entidades.RolUsuario> data = null;
    		List<Dominio.Entidades.RolUsuario> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryRolUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.RolUsuario>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryRolUsuario.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var RolUsuarioDetails = _repositoryRolUsuario
    				.Query(new RolUsuarioQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=RolUsuarioDetails.ToList();
                data = new PagedCollection<RolUsuario> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterRolUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterRolUsuario End"));
    
            //return Mapper.Map<PagedCollection<RolUsuario>>(data);
    		//return new PagedCollection<<RolUsuario>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }
    
    
         #endregion Methods
    
    }
}
