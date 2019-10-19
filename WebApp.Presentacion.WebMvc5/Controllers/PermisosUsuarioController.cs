
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
    
    public partial class PermisosUsuarioController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
        private readonly IRolUsuarioAppService _serviceRolUsuario;
        private readonly IUsuarioAppService _serviceUsuario;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of PermisosUsuario controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceRolUsuario">Service dependency</param>
        /// <param name="serviceUsuario">Service dependency</param>
        public PermisosUsuarioController(IPermisosUsuarioAppService service, IRolUsuarioAppService serviceRolUsuario, IUsuarioAppService serviceUsuario)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceRolUsuario == null)
                throw new ArgumentNullException("serviceRolUsuario", PresentationResources.exception_WithoutService);
            if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _servicePermisosUsuario = service;
            _serviceRolUsuario = serviceRolUsuario;
            _serviceUsuario = serviceUsuario;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPermisosUsuario Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new PermisosUsuarioCrudViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPermisosUsuario Controller End"));              
                return View("PermisosUsuarioAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPermisosUsuario Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(PermisosUsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPermisosUsuario Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _servicePermisosUsuario.Insert(model.PermisosUsuario, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPermisosUsuario Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddPermisosUsuario Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("PermisosUsuarioAddView", new PermisosUsuarioCrudViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPermisosUsuario Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new PermisosUsuarioCrudViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario)
                    {
                        PermisosUsuario = _servicePermisosUsuario.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPermisosUsuario Controller End"));
                return View("PermisosUsuarioModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPermisosUsuario Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(PermisosUsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPermisosUsuario Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _servicePermisosUsuario.Update(model.PermisosUsuario, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPermisosUsuario Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyPermisosUsuario Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("PermisosUsuarioModifyView", new PermisosUsuarioCrudViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePermisosUsuario Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new PermisosUsuarioCrudViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario)
                    {
                        PermisosUsuario = _servicePermisosUsuario.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePermisosUsuario Controller End"));
                return View("PermisosUsuarioRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePermisosUsuario Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(PermisosUsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePermisosUsuario Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _servicePermisosUsuario.Delete(model.PermisosUsuario, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePermisosUsuario Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemovePermisosUsuario Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("PermisosUsuarioRemoveView", new PermisosUsuarioCrudViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPermisosUsuario Controller Begin"));        
                
            try
            {
                // Add find logic here
                PermisosUsuarioFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterPermisosUsuario"))
                {
                    model = (PermisosUsuarioFindViewModel)TempData.Peek("FilterPermisosUsuario");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _servicePermisosUsuario.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _servicePermisosUsuario.FindPagedByFilter(new CustomQuery<PermisosUsuario> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedPermisosUsuario Controller End"));              
                    return PartialView("_PermisosUsuarioFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterPermisosUsuario");
                    model = new PermisosUsuarioFindViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPermisosUsuario Controller End"));              
                    return View("PermisosUsuarioFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPermisosUsuario Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(PermisosUsuarioFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPermisosUsuario Controller Begin"));        
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
                    var pagedResult = _servicePermisosUsuario.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var PermisosUsuarioDetails = _serviceAlim.Query(
                    //    new PermisosUsuarioQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = PermisosUsuarioDetails.ToList() };
    
                    //var pagedResult = _servicePermisosUsuario.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterPermisosUsuario", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPermisosUsuario Controller End"));
                    return PartialView("_PermisosUsuarioFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPermisosUsuario Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("PermisosUsuarioFindView", new PermisosUsuarioFindViewModel(_servicePermisosUsuario, _serviceRolUsuario, _serviceUsuario));
        }
    
        #region Private Methods
    
        //private static QueryObject<PermisosUsuario> GenerateExpression(PermisosUsuarioFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(PermisosUsuarioFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.PermisosUsuario.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.PermisosUsuario.Id.Value.ToString() });
                    //And(d => d.Id == model.PermisosUsuario.Id.Value);
                if (model.PermisosUsuario.IdUsuario.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdUsuario", value = model.PermisosUsuario.IdUsuario.Value.ToString() });
                    //And(d => d.IdUsuario == model.PermisosUsuario.IdUsuario.Value);
                if (model.PermisosUsuario.IdRol.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdRol", value = model.PermisosUsuario.IdRol.Value.ToString() });
                    //And(d => d.IdRol == model.PermisosUsuario.IdRol.Value);
                if (model.PermisosUsuario.FechaInicio.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaInicio", value = model.PermisosUsuario.FechaInicio.Value.ToString() });
                    //And(d => d.FechaInicio == model.PermisosUsuario.FechaInicio.Value);
                if (model.PermisosUsuario.FechaTermino.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaTermino", value = model.PermisosUsuario.FechaTermino.Value.ToString() });
                    //And(d => d.FechaTermino == model.PermisosUsuario.FechaTermino.Value);
                if (model.PermisosUsuario.CreatedBy.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedBy", value = model.PermisosUsuario.CreatedBy.Value.ToString() });
                    //And(d => d.CreatedBy == model.PermisosUsuario.CreatedBy.Value);
                if (model.PermisosUsuario.CreatedDate.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedDate", value = model.PermisosUsuario.CreatedDate.Value.ToString() });
                    //And(d => d.CreatedDate == model.PermisosUsuario.CreatedDate.Value);
            }
    
    		return filtros;
            //return new QueryObject<PermisosUsuario>(expression ?? (d => true));
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
                //_servicePermisosUsuario.Dispose();
                //_serviceRolUsuario.Dispose();
                //_serviceUsuario.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
