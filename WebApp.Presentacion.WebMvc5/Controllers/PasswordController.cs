
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
    
    public partial class PasswordController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IPasswordAppService _servicePassword;
        private readonly IUserPasswordsAppService _serviceUserPasswords;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Password controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceUserPasswords">Service dependency</param>
        public PasswordController(IPasswordAppService service, IUserPasswordsAppService serviceUserPasswords)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceUserPasswords == null)
                throw new ArgumentNullException("serviceUserPasswords", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _servicePassword = service;
            _serviceUserPasswords = serviceUserPasswords;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPassword Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new PasswordCrudViewModel(_servicePassword, _serviceUserPasswords);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPassword Controller End"));              
                return View("PasswordAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPassword Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PasswordCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPassword Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _servicePassword.Insert(model.Password, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPassword Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPassword Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("PasswordAddView", new PasswordCrudViewModel(_servicePassword, _serviceUserPasswords));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPassword Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new PasswordCrudViewModel(_servicePassword, _serviceUserPasswords)
                    {
                        Password = _servicePassword.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPassword Controller End"));
                return View("PasswordModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPassword Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(PasswordCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPassword Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _servicePassword.Update(model.Password, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPassword Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPassword Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("PasswordModifyView", new PasswordCrudViewModel(_servicePassword, _serviceUserPasswords));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePassword Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new PasswordCrudViewModel(_servicePassword, _serviceUserPasswords)
                    {
                        Password = _servicePassword.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePassword Controller End"));
                return View("PasswordRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePassword Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(PasswordCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePassword Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _servicePassword.Delete(model.Password, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePassword Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePassword Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("PasswordRemoveView", new PasswordCrudViewModel(_servicePassword, _serviceUserPasswords));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPassword Controller Begin"));        
                
            try
            {
                // Add find logic here
                PasswordFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterPassword"))
                {
                    model = (PasswordFindViewModel)TempData.Peek("FilterPassword");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _servicePassword.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _servicePassword.FindPagedByFilter(new CustomQuery<Password> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedPassword Controller End"));              
                    return PartialView("_PasswordFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterPassword");
                    model = new PasswordFindViewModel(_servicePassword, _serviceUserPasswords);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPassword Controller End"));              
                    return View("PasswordFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPassword Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(PasswordFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPassword Controller Begin"));        
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
                    var pagedResult = _servicePassword.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var PasswordDetails = _serviceAlim.Query(
                    //    new PasswordQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = PasswordDetails.ToList() };
    
                    //var pagedResult = _servicePassword.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterPassword", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPassword Controller End"));
                    return PartialView("_PasswordFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPassword Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("PasswordFindView", new PasswordFindViewModel(_servicePassword, _serviceUserPasswords));
        }
    
        #region Private Methods
    
        //private static QueryObject<Password> GenerateExpression(PasswordFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(PasswordFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Password.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Password.Id.Value.ToString() });
                    //And(d => d.Id == model.Password.Id.Value);
                if (!string.IsNullOrEmpty(model.Password.Password1))
    				filtros.Add(new filterRule() { op = "equal", field = "Password1", value = model.Password.Password1 });				
                    //And(d => d.Password1.Contains(model.Password.Password1));
                if (!string.IsNullOrEmpty(model.Password.PasswordHash))
    				filtros.Add(new filterRule() { op = "equal", field = "PasswordHash", value = model.Password.PasswordHash });				
                    //And(d => d.PasswordHash.Contains(model.Password.PasswordHash));
                if (!string.IsNullOrEmpty(model.Password.PasswordSalt))
    				filtros.Add(new filterRule() { op = "equal", field = "PasswordSalt", value = model.Password.PasswordSalt });				
                    //And(d => d.PasswordSalt.Contains(model.Password.PasswordSalt));
                if (!string.IsNullOrEmpty(model.Password.PasswordAnswer))
    				filtros.Add(new filterRule() { op = "equal", field = "PasswordAnswer", value = model.Password.PasswordAnswer });				
                    //And(d => d.PasswordAnswer.Contains(model.Password.PasswordAnswer));
                if (!string.IsNullOrEmpty(model.Password.PasswordQuestion))
    				filtros.Add(new filterRule() { op = "equal", field = "PasswordQuestion", value = model.Password.PasswordQuestion });				
                    //And(d => d.PasswordQuestion.Contains(model.Password.PasswordQuestion));
                if (model.Password.Activo.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Activo", value = model.Password.Activo.Value.ToString() });
                    //And(d => d.Activo == model.Password.Activo.Value);
                if (!string.IsNullOrEmpty(model.Password.CreatedByUserID))
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedByUserID", value = model.Password.CreatedByUserID });				
                    //And(d => d.CreatedByUserID.Contains(model.Password.CreatedByUserID));
                if (model.Password.FechaCreacion.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaCreacion", value = model.Password.FechaCreacion.Value.ToString() });
                    //And(d => d.FechaCreacion == model.Password.FechaCreacion.Value);
            }
    
    		return filtros;
            //return new QueryObject<Password>(expression ?? (d => true));
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
                //_servicePassword.Dispose();
                //_serviceUserPasswords.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
