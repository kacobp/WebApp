
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
    
    public partial class RolUsuarioController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IRolUsuarioAppService _serviceRolUsuario;
        private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of RolUsuario controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="servicePermisosUsuario">Service dependency</param>
        public RolUsuarioController(IRolUsuarioAppService service, IPermisosUsuarioAppService servicePermisosUsuario)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (servicePermisosUsuario == null)
                throw new ArgumentNullException("servicePermisosUsuario", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceRolUsuario = service;
            _servicePermisosUsuario = servicePermisosUsuario;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRolUsuario Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new RolUsuarioCrudViewModel(_serviceRolUsuario, _servicePermisosUsuario);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRolUsuario Controller End"));              
                return View("RolUsuarioAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRolUsuario Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RolUsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRolUsuario Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRolUsuario.Insert(model.RolUsuario, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRolUsuario Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRolUsuario Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RolUsuarioAddView", new RolUsuarioCrudViewModel(_serviceRolUsuario, _servicePermisosUsuario));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRolUsuario Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new RolUsuarioCrudViewModel(_serviceRolUsuario, _servicePermisosUsuario)
                    {
                        RolUsuario = _serviceRolUsuario.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRolUsuario Controller End"));
                return View("RolUsuarioModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRolUsuario Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(RolUsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRolUsuario Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRolUsuario.Update(model.RolUsuario, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRolUsuario Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRolUsuario Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RolUsuarioModifyView", new RolUsuarioCrudViewModel(_serviceRolUsuario, _servicePermisosUsuario));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRolUsuario Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new RolUsuarioCrudViewModel(_serviceRolUsuario, _servicePermisosUsuario)
                    {
                        RolUsuario = _serviceRolUsuario.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRolUsuario Controller End"));
                return View("RolUsuarioRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRolUsuario Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(RolUsuarioCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRolUsuario Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceRolUsuario.Delete(model.RolUsuario, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRolUsuario Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRolUsuario Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RolUsuarioRemoveView", new RolUsuarioCrudViewModel(_serviceRolUsuario, _servicePermisosUsuario));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRolUsuario Controller Begin"));        
                
            try
            {
                // Add find logic here
                RolUsuarioFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterRolUsuario"))
                {
                    model = (RolUsuarioFindViewModel)TempData.Peek("FilterRolUsuario");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceRolUsuario.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceRolUsuario.FindPagedByFilter(new CustomQuery<RolUsuario> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedRolUsuario Controller End"));              
                    return PartialView("_RolUsuarioFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterRolUsuario");
                    model = new RolUsuarioFindViewModel(_serviceRolUsuario, _servicePermisosUsuario);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRolUsuario Controller End"));              
                    return View("RolUsuarioFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRolUsuario Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(RolUsuarioFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRolUsuario Controller Begin"));        
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
                    var pagedResult = _serviceRolUsuario.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var RolUsuarioDetails = _serviceAlim.Query(
                    //    new RolUsuarioQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = RolUsuarioDetails.ToList() };
    
                    //var pagedResult = _serviceRolUsuario.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterRolUsuario", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRolUsuario Controller End"));
                    return PartialView("_RolUsuarioFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRolUsuario Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("RolUsuarioFindView", new RolUsuarioFindViewModel(_serviceRolUsuario, _servicePermisosUsuario));
        }
    
        #region Private Methods
    
        //private static QueryObject<RolUsuario> GenerateExpression(RolUsuarioFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(RolUsuarioFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.RolUsuario.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.RolUsuario.Id.Value.ToString() });
                    //And(d => d.Id == model.RolUsuario.Id.Value);
                if (!string.IsNullOrEmpty(model.RolUsuario.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.RolUsuario.Nombre });				
                    //And(d => d.Nombre.Contains(model.RolUsuario.Nombre));
                if (!string.IsNullOrEmpty(model.RolUsuario.Nota))
    				filtros.Add(new filterRule() { op = "equal", field = "Nota", value = model.RolUsuario.Nota });				
                    //And(d => d.Nota.Contains(model.RolUsuario.Nota));
                if (model.RolUsuario.Activo.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Activo", value = model.RolUsuario.Activo.Value.ToString() });
                    //And(d => d.Activo == model.RolUsuario.Activo.Value);
                if (model.RolUsuario.CreatedBy.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedBy", value = model.RolUsuario.CreatedBy.Value.ToString() });
                    //And(d => d.CreatedBy == model.RolUsuario.CreatedBy.Value);
                if (model.RolUsuario.CreatedDate.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "CreatedDate", value = model.RolUsuario.CreatedDate.Value.ToString() });
                    //And(d => d.CreatedDate == model.RolUsuario.CreatedDate.Value);
                if (model.RolUsuario.ModifiedBy.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ModifiedBy", value = model.RolUsuario.ModifiedBy.Value.ToString() });
                    //And(d => d.ModifiedBy == model.RolUsuario.ModifiedBy.Value);
                if (model.RolUsuario.ModifiedDate.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ModifiedDate", value = model.RolUsuario.ModifiedDate.Value.ToString() });
                    //And(d => d.ModifiedDate == model.RolUsuario.ModifiedDate.Value);
            }
    
    		return filtros;
            //return new QueryObject<RolUsuario>(expression ?? (d => true));
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
                //_serviceRolUsuario.Dispose();
                //_servicePermisosUsuario.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
