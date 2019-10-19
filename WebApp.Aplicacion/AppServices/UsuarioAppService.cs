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
    using System.Security.Cryptography;
    using TrackableEntities;
    using WebApp.Transversales.Utilities.Encryptor;

    public sealed partial class UsuarioAppService : IUsuarioAppService
    {
        #region Fields
        
        private IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IUsuarioRepository _repositoryUsuario;
        //public static IMapper Mapper {get; private set;}
        private DESEncryptor desHelper = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of Usuario application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        public UsuarioAppService(IUsuarioRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUsuario = repository;
            DES _newDes = DESEncryptor.CreateDES("WebApp.AppServices");
            _newDes.IV = new byte[8] { 0x01, 0x02, 0x03, 0x4, 0x05, 0x06, 0x07, 0x08 };
            desHelper = new DESEncryptor(_newDes.Key, _newDes.IV);
        }

        /// <summary>
        /// Create a new instance of Usuario application service
        /// </summary>
        /// <param name="repository">Repository dependency</param>
        /// <param name="uow">IUnitOfWorkAsync dependency</param>
        public UsuarioAppService(IUsuarioRepository repository, IUnitOfWorkAsync uow)
        {
            if (repository == null)
                throw new ArgumentNullException("repository", ApplicationResources.exception_WithoutRepository);
            _repositoryUsuario = repository;
    
            if (uow == null)
                throw new ArgumentNullException("uow", ApplicationResources.exception_WithoutRepository);
            _unitOfWorkAsync = uow;
            DES _newDes = DESEncryptor.CreateDES("WebApp.AppServices");
            _newDes.IV = new byte[8] { 0x01, 0x02, 0x03, 0x4, 0x05, 0x06, 0x07, 0x08 };
            desHelper = new DESEncryptor(_newDes.Key, _newDes.IV);
        }

        #endregion

        #region URF Public Methods

        public Usuario Find(params object[] keyValues)
    	{
            Dominio.Entidades.Usuario data = null;
    
            try
            {
                //if (session != null)
                // _repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                // Domain Services?
                data = _repositoryUsuario.Find(keyValues);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();
        
            //return Mapper.Map<Usuario>(data);
    		return data;
    	}
    
    	public bool Insert(Usuario item, Session session = null)
    	{
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
            bool result = false;
            UserPasswords oUserPass = new UserPasswords();
            Password oPass = new Password();

            try
            {
                //if (session != null)
                //    _repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    var _repoPass = _repositoryUsuario.GetRepository<Password>();
                    var _repoUserPass = _repositoryUsuario.GetRepository<UserPasswords>();

                    _unitOfWorkAsync.BeginTransaction();

                    oUserPass = item.UserPasswords.FirstOrDefault();
                    oPass = oUserPass.Password;
                    //oUserPass = item.UserPasswords.FirstOrDefault();
                    //Password
                    string _srtEncrypt = desHelper.EncryptString(oPass.Password1);
                    //string _strDecrypt = desHelper.DecryptString("39S4D8vXqfk=");
                    //oPass.Password1 = item..Password;
                    oPass.PasswordHash = _srtEncrypt;
                    oPass.TrackingState = TrackingState.Added;
                    ////////_repoPass.Insert(oPass);
                    //committed = _unitOfWorkAsync.SaveChanges();
                    //var oPassTemp = _repoPass.Queryable().Where(x => x.PasswordHash == _srtEncrypt).FirstOrDefault();

                    item.TrackingState = TrackingState.Added;
                    _repositoryUsuario.Insert(item,false);
                    //var oUser = _repositoryUsuario.Queryable().Where(x => x.AccountName == item.AccountName).FirstOrDefault();
                    //committed = _unitOfWorkAsync.SaveChanges();

                    oUserPass.IdUsuario = item.Id;
                    oUserPass.IdPassword = oPass.Id;
                    oUserPass.TrackingState = TrackingState.Added;
                    //_repoUserPass.Insert(oUserPass);

                    committed = _unitOfWorkAsync.SaveChanges();
                    result=_unitOfWorkAsync.Commit();

                    // Domain Services?
                    //_repositoryUsuario.Insert(Mapper.Map<Dominio.Entidades.Usuario>(item));
                    //_repositoryUsuario.Insert(item);
                }
                else
                    throw new ApplicationValidationErrorsException(validator.GetInvalidMessages(item));
            }
            catch (Exception ex)
            {
                _unitOfWorkAsync.Rollback();
                //LoggerFactory.CreateLog().Error(ex);
            }

            //LoggerFactory.CreateLog().Stop();    
            //return committed > 0;
            return result;
        }

        public bool Update(Usuario item, Session session = null)
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
            
                if (item == null)
                    throw new ArgumentNullException("item");
    
                var validator = EntityValidatorFactory.CreateValidator();
                if (validator.IsValid(item))
                {
                    // Domain Services?
                    //_repositoryUsuario.Update(Mapper.Map<Dominio.Entidades.Usuario>(item));
                    _repositoryUsuario.Update(item);
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
    		//_repositoryUsuario.Update(entity); 
            return committed > 0;
    	}
    
    	public void Delete(object id) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (id == null)
                    throw new ArgumentNullException("id");
    
                // Domain Services?
                _repositoryUsuario.Delete(id);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
    		//_repositoryUsuario.Delete(id);
            //return committed > 0;
            return;
    	}
    
    	public bool Delete(Usuario item, Session session = null) 
    	{ 
            //LoggerFactory.CreateLog().Start();
            var committed = 0;
    
            try
            {
                //if (session != null)
                //    _repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
                if (item == null)
                    throw new ArgumentNullException("item");
    
                // Domain Services?
                //_repositoryUsuario.Delete(Mapper.Map<Dominio.Entidades.Usuario>(item));
                _repositoryUsuario.Delete(item);
    			committed = _unitOfWorkAsync.SaveChanges();
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(ex);
            }  
    
            //LoggerFactory.CreateLog().Stop();    
            return committed > 0;
    	}
    
    	public IQueryable<Usuario> SelectQuery(string query, params object[] parameters) 
    	{ 
    	return _repositoryUsuario.SelectQuery(query, parameters).AsQueryable();
    	}
    
    	public void ApplyChanges(Usuario entity) 
    	{ 
    	_repositoryUsuario.ApplyChanges(entity);
    	}
    
    	public void InsertRange(IEnumerable<Usuario> entities) 
    	{ 
    	_repositoryUsuario.InsertRange(entities);
    	}
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertOrUpdateGraph(Usuario entity) { _repositoryUsuario.InsertOrUpdateGraph(entity); }
    
    	////[Obsolete("InsertOrUpdateGraph has been deprecated.  Instead set TrackingState to Added or Modified and call ApplyChanges.")]
    	//////public void InsertGraphRange(IEnumerable<Usuario> entities) { _repositoryUsuario.InsertGraphRange(entities); }
    
    	public IQueryFluent<Usuario> Query() 
    	{ 
    	return _repositoryUsuario.Query(); 
    	}
    
    	public IQueryFluent<Usuario> Query(IQueryObject<Usuario> queryObject)
    	{ 
    	return _repositoryUsuario.Query(queryObject); 
    	}
    
    	public IQueryFluent<Usuario> Query(Expression<Func<Usuario, bool>> query) 
    	{ 
    	return _repositoryUsuario.Query(query); 
    	}
    
    	public async Task<Usuario> FindAsync(params object[] keyValues)
    	{ 
    	return await _repositoryUsuario.FindAsync(keyValues); 
    	}
    
    	public async Task<Usuario> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUsuario.FindAsync(cancellationToken, keyValues);
    	}
    
    	public async Task<bool> DeleteAsync(params object[] keyValues) 
    	{ 
    	return await DeleteAsync(CancellationToken.None, keyValues); 
    	}
    
    	//IF 04/08/2014 - Before: return await DeleteAsync(cancellationToken, keyValues);
    	public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
    	{ 
    	return await _repositoryUsuario.DeleteAsync(cancellationToken, keyValues);
    	}
    
    	public IQueryable<Usuario> Queryable() 
    	{ 
    	return _repositoryUsuario.Queryable();
    	}
    
        #endregion URF
    
        #region Methods
    
        /// <summary>
        /// Select all
        /// </summary>
        /// <param name="includes">Inners</param> 
    	/// <param name="session">Session</param>
    	/// <returns>List of results</returns>
        public List<Usuario> GetAll(List<string> includes, Session session = null)
    	{
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUsuario Begin"));
    
    		List<Dominio.Entidades.Usuario> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			// Domain Services?
                //var datax = _repositoryUsuario.Queryable().ToList();
    			data = _repositoryUsuario.Queryable().ToList();
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - GetAllUsuario End"));
    	
    		//return Mapper.Map<List<Usuario>>(data);
    		return data;
    	}
    
        /// <summary>
        /// Find by filter
        /// </summary>
        /// <param name="filter">Expression filter</param>
        /// <param name="includes">Inners</param>
        /// <param name="session">Session</param>
        /// <returns>List of results</returns>
        public List<Usuario> FindByFilter(IEnumerable<filterRule> filter, List<string> includes, string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUsuario Begin"));		
    		List<Dominio.Entidades.Usuario> data = null;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Usuario>>(filter).ToDomainExpression();
    
    			// Domain Services?			
    			//data = _repositoryUsuario.AllMatching(mapperExp, includes);
                var UsuarioDetails = _repositoryUsuario
    				.Query(new UsuarioQuery().Withfilter(filter))
                    .Select().ToList()
                    ;
                //.OrderBy(n => n.OrderBy("Id", "Asc"))
                //.SelectPage(1, model.PageSize, out totalCount);
    
                data = UsuarioDetails;
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindByFilterUsuario End"));
            //return Mapper.Map<List<Usuario>>(data);
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
        public PagedCollection<Usuario> FindPagedByFilter(IEnumerable<filterRule> filter, List<string> includes, int pageGo, int pageSize, string sort, string order ="asc", string filterRules = "", Session session = null)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUsuario Begin"));
    		PagedCollection<Dominio.Entidades.Usuario> data = null;
    		List<Dominio.Entidades.Usuario> items = null;
            var totalItems = 0;
    
    		try
            {
    			//if (session != null)
    			//	_repositoryUsuario.UnitOfWork.SetConnectionDb(session.ConnectionString);
    
    			//var mapperExp = Mapper.Map<CustomQuery<Domain.BoundedContext.Entities.Usuario>>(filter).ToDomainExpression();
    		
    			// Domain Services?            
    			//data = _repositoryUsuario.AllMatchingPaged(mapperExp, includes, pageGo, pageSize, orderBy, ascending);
                var UsuarioDetails = _repositoryUsuario
    				.Query(new UsuarioQuery().Withfilter(filter))
    	            .OrderBy(n => n.OrderBy(sort, order))
                    //.Select().ToList()
    				.SelectPage(pageGo, pageSize, out totalItems);
    
    			items=UsuarioDetails.ToList();
                data = new PagedCollection<Usuario> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalItems };
    			
    		}
    		catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUsuario ERROR"), ex);
            }  
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Application Layer - FindPagedByFilterUsuario End"));
    
            //return Mapper.Map<PagedCollection<Usuario>>(data);
    		//return new PagedCollection<<Usuario>> { PageIndex = pageGo, PageSize = pageSize, Items = items, TotalItems = totalCount };
    		return data;
        }

        public Usuario LogIn(string nomUsuario, string password)
        {

            var lstPass = _repositoryUsuario.GetRepository<UserPasswords>();
            var oUser = _repositoryUsuario.Queryable().Where(u => u.AccountName == nomUsuario).FirstOrDefault();
            var oPass = _repositoryUsuario.GetRepository<Password>().Queryable().Where(p => p.Password1 == password).FirstOrDefault();

            var lstx = lstPass
                .Queryable()
                .Where(p => p.IdUsuario == oUser.Id)
                .Where(p => p.IdPassword == oPass.Id)
                .FirstOrDefault();


            var lst = _repositoryUsuario
                .Queryable()
                .Where(u => u.AccountName == nomUsuario)
                //.SelectMany(u => u.UserPasswords.Where(p => p.Password.Password1 == password))
                .Select(u => u.UserPasswords.Where(p => p.Password.Password1 == password));
            //.FirstOrDefault();

            return oUser;
        }

        #endregion Methods

    }
}
