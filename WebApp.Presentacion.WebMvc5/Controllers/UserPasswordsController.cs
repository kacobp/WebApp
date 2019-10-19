
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
    
    public partial class UserPasswordsController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IUserPasswordsAppService _serviceUserPasswords;
        private readonly IPasswordAppService _servicePassword;
        private readonly IUsuarioAppService _serviceUsuario;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of UserPasswords controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="servicePassword">Service dependency</param>
        /// <param name="serviceUsuario">Service dependency</param>
        public UserPasswordsController(IUserPasswordsAppService service, IPasswordAppService servicePassword, IUsuarioAppService serviceUsuario)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (servicePassword == null)
                throw new ArgumentNullException("servicePassword", PresentationResources.exception_WithoutService);
            if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceUserPasswords = service;
            _servicePassword = servicePassword;
            _serviceUsuario = serviceUsuario;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPasswords Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new UserPasswordsCrudViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPasswords Controller End"));              
                return View("UserPasswordsAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPasswords Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UserPasswordsCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPasswords Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUserPasswords.Insert(model.UserPasswords, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPasswords Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPasswords Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UserPasswordsAddView", new UserPasswordsCrudViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPasswords Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new UserPasswordsCrudViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario)
                    {
                        UserPasswords = _serviceUserPasswords.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPasswords Controller End"));
                return View("UserPasswordsModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPasswords Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(UserPasswordsCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPasswords Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUserPasswords.Update(model.UserPasswords, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPasswords Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPasswords Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UserPasswordsModifyView", new UserPasswordsCrudViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPasswords Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new UserPasswordsCrudViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario)
                    {
                        UserPasswords = _serviceUserPasswords.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPasswords Controller End"));
                return View("UserPasswordsRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPasswords Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(UserPasswordsCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPasswords Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceUserPasswords.Delete(model.UserPasswords, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPasswords Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPasswords Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UserPasswordsRemoveView", new UserPasswordsCrudViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPasswords Controller Begin"));        
                
            try
            {
                // Add find logic here
                UserPasswordsFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterUserPasswords"))
                {
                    model = (UserPasswordsFindViewModel)TempData.Peek("FilterUserPasswords");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceUserPasswords.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceUserPasswords.FindPagedByFilter(new CustomQuery<UserPasswords> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedUserPasswords Controller End"));              
                    return PartialView("_UserPasswordsFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterUserPasswords");
                    model = new UserPasswordsFindViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPasswords Controller End"));              
                    return View("UserPasswordsFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPasswords Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(UserPasswordsFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPasswords Controller Begin"));        
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
                    var pagedResult = _serviceUserPasswords.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var UserPasswordsDetails = _serviceAlim.Query(
                    //    new UserPasswordsQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = UserPasswordsDetails.ToList() };
    
                    //var pagedResult = _serviceUserPasswords.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterUserPasswords", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPasswords Controller End"));
                    return PartialView("_UserPasswordsFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPasswords Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("UserPasswordsFindView", new UserPasswordsFindViewModel(_serviceUserPasswords, _servicePassword, _serviceUsuario));
        }
    
        #region Private Methods
    
        //private static QueryObject<UserPasswords> GenerateExpression(UserPasswordsFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(UserPasswordsFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.UserPasswords.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.UserPasswords.Id.Value.ToString() });
                    //And(d => d.Id == model.UserPasswords.Id.Value);
                if (model.UserPasswords.IdUsuario.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdUsuario", value = model.UserPasswords.IdUsuario.Value.ToString() });
                    //And(d => d.IdUsuario == model.UserPasswords.IdUsuario.Value);
                if (model.UserPasswords.IdPassword.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdPassword", value = model.UserPasswords.IdPassword.Value.ToString() });
                    //And(d => d.IdPassword == model.UserPasswords.IdPassword.Value);
                if (model.UserPasswords.ExternalUser.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ExternalUser", value = model.UserPasswords.ExternalUser.Value.ToString() });
                    //And(d => d.ExternalUser == model.UserPasswords.ExternalUser.Value);
            }
    
    		return filtros;
            //return new QueryObject<UserPasswords>(expression ?? (d => true));
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
                //_serviceUserPasswords.Dispose();
                //_servicePassword.Dispose();
                //_serviceUsuario.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
