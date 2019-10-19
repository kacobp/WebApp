
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
    
    public partial class RendCantController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IRendCantAppService _serviceRendCant;
        private readonly IAlimAppService _serviceAlim;
        private readonly IRendAppService _serviceRend;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of RendCant controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        /// <param name="serviceRend">Service dependency</param>
        public RendCantController(IRendCantAppService service, IAlimAppService serviceAlim, IRendAppService serviceRend)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
            if (serviceRend == null)
                throw new ArgumentNullException("serviceRend", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceRendCant = service;
            _serviceAlim = serviceAlim;
            _serviceRend = serviceRend;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRendCant Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new RendCantCrudViewModel(_serviceRendCant, _serviceAlim, _serviceRend);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRendCant Controller End"));              
                return View("RendCantAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRendCant Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RendCantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRendCant Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRendCant.Insert(model.RendCant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRendCant Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRendCant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RendCantAddView", new RendCantCrudViewModel(_serviceRendCant, _serviceAlim, _serviceRend));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRendCant Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new RendCantCrudViewModel(_serviceRendCant, _serviceAlim, _serviceRend)
                    {
                        RendCant = _serviceRendCant.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRendCant Controller End"));
                return View("RendCantModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRendCant Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(RendCantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRendCant Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRendCant.Update(model.RendCant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRendCant Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRendCant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RendCantModifyView", new RendCantCrudViewModel(_serviceRendCant, _serviceAlim, _serviceRend));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRendCant Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new RendCantCrudViewModel(_serviceRendCant, _serviceAlim, _serviceRend)
                    {
                        RendCant = _serviceRendCant.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRendCant Controller End"));
                return View("RendCantRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRendCant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(RendCantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRendCant Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceRendCant.Delete(model.RendCant, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRendCant Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRendCant Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RendCantRemoveView", new RendCantCrudViewModel(_serviceRendCant, _serviceAlim, _serviceRend));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRendCant Controller Begin"));        
                
            try
            {
                // Add find logic here
                RendCantFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterRendCant"))
                {
                    model = (RendCantFindViewModel)TempData.Peek("FilterRendCant");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceRendCant.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceRendCant.FindPagedByFilter(new CustomQuery<RendCant> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedRendCant Controller End"));              
                    return PartialView("_RendCantFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterRendCant");
                    model = new RendCantFindViewModel(_serviceRendCant, _serviceAlim, _serviceRend);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRendCant Controller End"));              
                    return View("RendCantFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRendCant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(RendCantFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRendCant Controller Begin"));        
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
                    var pagedResult = _serviceRendCant.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var RendCantDetails = _serviceAlim.Query(
                    //    new RendCantQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = RendCantDetails.ToList() };
    
                    //var pagedResult = _serviceRendCant.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterRendCant", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRendCant Controller End"));
                    return PartialView("_RendCantFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRendCant Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("RendCantFindView", new RendCantFindViewModel(_serviceRendCant, _serviceAlim, _serviceRend));
        }
    
        #region Private Methods
    
        //private static QueryObject<RendCant> GenerateExpression(RendCantFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(RendCantFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.RendCant.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.RendCant.Id.Value.ToString() });
                    //And(d => d.Id == model.RendCant.Id.Value);
                if (model.RendCant.IdAlim.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdAlim", value = model.RendCant.IdAlim.Value.ToString() });
                    //And(d => d.IdAlim == model.RendCant.IdAlim.Value);
                if (model.RendCant.IdRend.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdRend", value = model.RendCant.IdRend.Value.ToString() });
                    //And(d => d.IdRend == model.RendCant.IdRend.Value);
                if (model.RendCant.Cantidad.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Cantidad", value = model.RendCant.Cantidad.Value.ToString() });
                    //And(d => d.Cantidad == model.RendCant.Cantidad.Value);
                if (model.RendCant.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.RendCant.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.RendCant.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<RendCant>(expression ?? (d => true));
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
                //_serviceRendCant.Dispose();
                //_serviceAlim.Dispose();
                //_serviceRend.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
