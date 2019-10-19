
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
    
    public partial class LoginAttemptsController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly ILoginAttemptsAppService _serviceLoginAttempts;
        private readonly IUsuarioAppService _serviceUsuario;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of LoginAttempts controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceUsuario">Service dependency</param>
        public LoginAttemptsController(ILoginAttemptsAppService service, IUsuarioAppService serviceUsuario)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceLoginAttempts = service;
            _serviceUsuario = serviceUsuario;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLoginAttempts Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new LoginAttemptsCrudViewModel(_serviceLoginAttempts, _serviceUsuario);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLoginAttempts Controller End"));              
                return View("LoginAttemptsAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLoginAttempts Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LoginAttemptsCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLoginAttempts Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceLoginAttempts.Insert(model.LoginAttempts, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLoginAttempts Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLoginAttempts Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("LoginAttemptsAddView", new LoginAttemptsCrudViewModel(_serviceLoginAttempts, _serviceUsuario));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLoginAttempts Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new LoginAttemptsCrudViewModel(_serviceLoginAttempts, _serviceUsuario)
                    {
                        LoginAttempts = _serviceLoginAttempts.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLoginAttempts Controller End"));
                return View("LoginAttemptsModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLoginAttempts Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(LoginAttemptsCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLoginAttempts Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceLoginAttempts.Update(model.LoginAttempts, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLoginAttempts Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLoginAttempts Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("LoginAttemptsModifyView", new LoginAttemptsCrudViewModel(_serviceLoginAttempts, _serviceUsuario));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLoginAttempts Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new LoginAttemptsCrudViewModel(_serviceLoginAttempts, _serviceUsuario)
                    {
                        LoginAttempts = _serviceLoginAttempts.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLoginAttempts Controller End"));
                return View("LoginAttemptsRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLoginAttempts Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(LoginAttemptsCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLoginAttempts Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceLoginAttempts.Delete(model.LoginAttempts, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLoginAttempts Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLoginAttempts Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("LoginAttemptsRemoveView", new LoginAttemptsCrudViewModel(_serviceLoginAttempts, _serviceUsuario));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLoginAttempts Controller Begin"));        
                
            try
            {
                // Add find logic here
                LoginAttemptsFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterLoginAttempts"))
                {
                    model = (LoginAttemptsFindViewModel)TempData.Peek("FilterLoginAttempts");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceLoginAttempts.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceLoginAttempts.FindPagedByFilter(new CustomQuery<LoginAttempts> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedLoginAttempts Controller End"));              
                    return PartialView("_LoginAttemptsFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterLoginAttempts");
                    model = new LoginAttemptsFindViewModel(_serviceLoginAttempts, _serviceUsuario);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLoginAttempts Controller End"));              
                    return View("LoginAttemptsFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLoginAttempts Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(LoginAttemptsFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLoginAttempts Controller Begin"));        
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
                    var pagedResult = _serviceLoginAttempts.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var LoginAttemptsDetails = _serviceAlim.Query(
                    //    new LoginAttemptsQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = LoginAttemptsDetails.ToList() };
    
                    //var pagedResult = _serviceLoginAttempts.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterLoginAttempts", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLoginAttempts Controller End"));
                    return PartialView("_LoginAttemptsFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLoginAttempts Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("LoginAttemptsFindView", new LoginAttemptsFindViewModel(_serviceLoginAttempts, _serviceUsuario));
        }
    
        #region Private Methods
    
        //private static QueryObject<LoginAttempts> GenerateExpression(LoginAttemptsFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(LoginAttemptsFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.LoginAttempts.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.LoginAttempts.Id.Value.ToString() });
                    //And(d => d.Id == model.LoginAttempts.Id.Value);
                if (model.LoginAttempts.IdUsuario.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdUsuario", value = model.LoginAttempts.IdUsuario.Value.ToString() });
                    //And(d => d.IdUsuario == model.LoginAttempts.IdUsuario.Value);
                if (!string.IsNullOrEmpty(model.LoginAttempts.Password))
    				filtros.Add(new filterRule() { op = "equal", field = "Password", value = model.LoginAttempts.Password });				
                    //And(d => d.Password.Contains(model.LoginAttempts.Password));
                if (!string.IsNullOrEmpty(model.LoginAttempts.IPNumber))
    				filtros.Add(new filterRule() { op = "equal", field = "IPNumber", value = model.LoginAttempts.IPNumber });				
                    //And(d => d.IPNumber.Contains(model.LoginAttempts.IPNumber));
                if (!string.IsNullOrEmpty(model.LoginAttempts.BrowserType))
    				filtros.Add(new filterRule() { op = "equal", field = "BrowserType", value = model.LoginAttempts.BrowserType });				
                    //And(d => d.BrowserType.Contains(model.LoginAttempts.BrowserType));
                if (model.LoginAttempts.Success.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Success", value = model.LoginAttempts.Success.Value.ToString() });
                    //And(d => d.Success == model.LoginAttempts.Success.Value);
                if (model.LoginAttempts.CreatedDate.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedDate", value = model.LoginAttempts.CreatedDate.Value.ToString() });
                    //And(d => d.CreatedDate == model.LoginAttempts.CreatedDate.Value);
            }
    
    		return filtros;
            //return new QueryObject<LoginAttempts>(expression ?? (d => true));
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
                //_serviceLoginAttempts.Dispose();
                //_serviceUsuario.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
