
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
    
    public partial class RendController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IRendAppService _serviceRend;
        private readonly IRendCantAppService _serviceRendCant;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Rend controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceRendCant">Service dependency</param>
        public RendController(IRendAppService service, IRendCantAppService serviceRendCant)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceRendCant == null)
                throw new ArgumentNullException("serviceRendCant", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceRend = service;
            _serviceRendCant = serviceRendCant;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRend Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new RendCrudViewModel(_serviceRend, _serviceRendCant);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRend Controller End"));              
                return View("RendAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRend Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RendCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRend Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRend.Insert(model.Rend, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRend Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRend Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RendAddView", new RendCrudViewModel(_serviceRend, _serviceRendCant));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRend Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new RendCrudViewModel(_serviceRend, _serviceRendCant)
                    {
                        Rend = _serviceRend.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRend Controller End"));
                return View("RendModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRend Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(RendCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRend Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRend.Update(model.Rend, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRend Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRend Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RendModifyView", new RendCrudViewModel(_serviceRend, _serviceRendCant));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRend Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new RendCrudViewModel(_serviceRend, _serviceRendCant)
                    {
                        Rend = _serviceRend.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRend Controller End"));
                return View("RendRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRend Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(RendCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRend Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceRend.Delete(model.Rend, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRend Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRend Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RendRemoveView", new RendCrudViewModel(_serviceRend, _serviceRendCant));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRend Controller Begin"));        
                
            try
            {
                // Add find logic here
                RendFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterRend"))
                {
                    model = (RendFindViewModel)TempData.Peek("FilterRend");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceRend.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceRend.FindPagedByFilter(new CustomQuery<Rend> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedRend Controller End"));              
                    return PartialView("_RendFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterRend");
                    model = new RendFindViewModel(_serviceRend, _serviceRendCant);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRend Controller End"));              
                    return View("RendFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRend Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(RendFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRend Controller Begin"));        
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
                    var pagedResult = _serviceRend.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var RendDetails = _serviceAlim.Query(
                    //    new RendQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = RendDetails.ToList() };
    
                    //var pagedResult = _serviceRend.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterRend", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRend Controller End"));
                    return PartialView("_RendFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRend Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("RendFindView", new RendFindViewModel(_serviceRend, _serviceRendCant));
        }
    
        #region Private Methods
    
        //private static QueryObject<Rend> GenerateExpression(RendFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(RendFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Rend.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Rend.Id.Value.ToString() });
                    //And(d => d.Id == model.Rend.Id.Value);
                if (!string.IsNullOrEmpty(model.Rend.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Rend.Nombre });				
                    //And(d => d.Nombre.Contains(model.Rend.Nombre));
            }
    
    		return filtros;
            //return new QueryObject<Rend>(expression ?? (d => true));
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
                //_serviceRend.Dispose();
                //_serviceRendCant.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
