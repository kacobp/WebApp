
#region

using WebApp.Aplicacion.AppServices;


//using WebApp.Aplicacion.Dtos;
using WebApp.Datos.Core;
using WebApp.Datos.Repository;
using WebApp.Dominio.Entidades;
using WebApp.Dominio.Core.UnitOfWork;
using WebApp.Transversales.Caching;
//using WebApp.Transversales.Log;
//using WebApp.Transversales.Log4net;
using WebApp.Transversales.Extensions;

using AutoMapper;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Newtonsoft.Json;
using System.ServiceModel;
using System.Web.Mvc;

using WebApp.Presentacion.WebMvc5.Resources;
using WebApp.Presentacion.WebMvc5.ViewModels;

#endregion

namespace WebApp.Presentacion.WebMvc5.Controllers
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IUsuarioAppService _serviceUsuario;
        private readonly ILoginAttemptsAppService _serviceLoginAttempts;
        private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
        private readonly IUserPasswordsAppService _serviceUserPasswords;
        private readonly IUserPhotosAppService _serviceUserPhotos;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Usuario controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceLoginAttempts">Service dependency</param>
        /// <param name="servicePermisosUsuario">Service dependency</param>
        /// <param name="serviceUserPasswords">Service dependency</param>
        /// <param name="serviceUserPhotos">Service dependency</param>
        public UsuarioController(IUsuarioAppService service, ILoginAttemptsAppService serviceLoginAttempts, IPermisosUsuarioAppService servicePermisosUsuario, IUserPasswordsAppService serviceUserPasswords, IUserPhotosAppService serviceUserPhotos)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceLoginAttempts == null)
                throw new ArgumentNullException("serviceLoginAttempts", PresentationResources.exception_WithoutService);
            if (servicePermisosUsuario == null)
                throw new ArgumentNullException("servicePermisosUsuario", PresentationResources.exception_WithoutService);
            if (serviceUserPasswords == null)
                throw new ArgumentNullException("serviceUserPasswords", PresentationResources.exception_WithoutService);
            if (serviceUserPhotos == null)
                throw new ArgumentNullException("serviceUserPhotos", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceUsuario = service;
            _serviceLoginAttempts = serviceLoginAttempts;
            _servicePermisosUsuario = servicePermisosUsuario;
            _serviceUserPasswords = serviceUserPasswords;
            _serviceUserPhotos = serviceUserPhotos;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUsuario Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new UsuarioCrudViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUsuario Controller End"));              
                return View("UsuarioAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUsuario Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUsuario Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUsuario.Insert(model.Usuario, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUsuario Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUsuario Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UsuarioAddView", new UsuarioCrudViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUsuario Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new UsuarioCrudViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos)
                    {
                        Usuario = _serviceUsuario.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUsuario Controller End"));
                return View("UsuarioModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUsuario Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(UsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUsuario Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUsuario.Update(model.Usuario, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUsuario Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUsuario Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UsuarioModifyView", new UsuarioCrudViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUsuario Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new UsuarioCrudViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos)
                    {
                        Usuario = _serviceUsuario.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUsuario Controller End"));
                return View("UsuarioRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUsuario Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(UsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUsuario Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceUsuario.Delete(model.Usuario, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUsuario Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUsuario Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UsuarioRemoveView", new UsuarioCrudViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUsuario Controller Begin"));        
                
            try
            {
                // Add find logic here
                UsuarioFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterUsuario"))
                {
                    model = (UsuarioFindViewModel)TempData.Peek("FilterUsuario");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceUsuario.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceUsuario.FindPagedByFilter(new CustomQuery<Usuario> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedUsuario Controller End"));              
                    return PartialView("_UsuarioFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterUsuario");
                    model = new UsuarioFindViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUsuario Controller End"));              
                    return View("UsuarioFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUsuario Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(UsuarioFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUsuario Controller Begin"));        
            //int totalCount = 0;
                
            try
            {
                // Add find logic here
                if (ModelState.IsValid)
                {
    				if (model.OrderBy == null)
    	            {
    					model.OrderBy = "Id";
    		        }
    
    				string sort = "Id";
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceUsuario.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var UsuarioDetails = _serviceAlim.Query(
                    //    new UsuarioQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = UsuarioDetails.ToList() };
    
                    //var pagedResult = _serviceUsuario.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterUsuario", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUsuario Controller End"));
                    return PartialView("_UsuarioFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUsuario Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("UsuarioFindView", new UsuarioFindViewModel(_serviceUsuario, _serviceLoginAttempts, _servicePermisosUsuario, _serviceUserPasswords, _serviceUserPhotos));
        }
    
        #region Private Methods
    
        //private static QueryObject<Usuario> GenerateExpression(UsuarioFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(UsuarioFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Usuario.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Usuario.Id.Value.ToString() });
                    //And(d => d.Id == model.Usuario.Id.Value);
                if (model.Usuario.SupervisorUserID.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "SupervisorUserID", value = model.Usuario.SupervisorUserID.Value.ToString() });
                    //And(d => d.SupervisorUserID == model.Usuario.SupervisorUserID.Value);
                if (!string.IsNullOrEmpty(model.Usuario.AccountName))
    				filtros.Add(new filterRule() { op = "equal", field = "AccountName", value = model.Usuario.AccountName });				
                    //And(d => d.AccountName.Contains(model.Usuario.AccountName));
                if (model.Usuario.LanguageId.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "LanguageId", value = model.Usuario.LanguageId.Value.ToString() });
                    //And(d => d.LanguageId == model.Usuario.LanguageId.Value);
                if (!string.IsNullOrEmpty(model.Usuario.UserNote))
    				filtros.Add(new filterRule() { op = "equal", field = "UserNote", value = model.Usuario.UserNote });				
                    //And(d => d.UserNote.Contains(model.Usuario.UserNote));
                if (model.Usuario.Activo.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Activo", value = model.Usuario.Activo.Value.ToString() });
                    //And(d => d.Activo == model.Usuario.Activo.Value);
                if (model.Usuario.CreatedBy.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedBy", value = model.Usuario.CreatedBy.Value.ToString() });
                    //And(d => d.CreatedBy == model.Usuario.CreatedBy.Value);
                if (model.Usuario.CreatedDate.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedDate", value = model.Usuario.CreatedDate.Value.ToString() });
                    //And(d => d.CreatedDate == model.Usuario.CreatedDate.Value);
                if (model.Usuario.ModifiedBy.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ModifiedBy", value = model.Usuario.ModifiedBy.Value.ToString() });
                    //And(d => d.ModifiedBy == model.Usuario.ModifiedBy.Value);
                if (model.Usuario.ModifiedDate.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ModifiedDate", value = model.Usuario.ModifiedDate.Value.ToString() });
                    //And(d => d.ModifiedDate == model.Usuario.ModifiedDate.Value);
            }
    
    		return filtros;
            //return new QueryObject<Usuario>(expression ?? (d => true));
        }
    
        #endregion
    
        #region IDisposable Members
    
        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_serviceUsuario.Dispose();
                //_serviceLoginAttempts.Dispose();
                //_servicePermisosUsuario.Dispose();
                //_serviceUserPasswords.Dispose();
                //_serviceUserPhotos.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
