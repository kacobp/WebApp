
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
    
    public partial class DesechoController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IDesechoAppService _serviceDesecho;
        private readonly IDesCantAppService _serviceDesCant;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Desecho controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceDesCant">Service dependency</param>
        public DesechoController(IDesechoAppService service, IDesCantAppService serviceDesCant)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceDesCant == null)
                throw new ArgumentNullException("serviceDesCant", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceDesecho = service;
            _serviceDesCant = serviceDesCant;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesecho Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new DesechoCrudViewModel(_serviceDesecho, _serviceDesCant);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesecho Controller End"));              
                return View("DesechoAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesecho Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DesechoCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesecho Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceDesecho.Insert(model.Desecho, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesecho Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesecho Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("DesechoAddView", new DesechoCrudViewModel(_serviceDesecho, _serviceDesCant));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesecho Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new DesechoCrudViewModel(_serviceDesecho, _serviceDesCant)
                    {
                        Desecho = _serviceDesecho.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesecho Controller End"));
                return View("DesechoModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesecho Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(DesechoCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesecho Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceDesecho.Update(model.Desecho, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesecho Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesecho Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("DesechoModifyView", new DesechoCrudViewModel(_serviceDesecho, _serviceDesCant));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesecho Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new DesechoCrudViewModel(_serviceDesecho, _serviceDesCant)
                    {
                        Desecho = _serviceDesecho.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesecho Controller End"));
                return View("DesechoRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesecho Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(DesechoCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesecho Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceDesecho.Delete(model.Desecho, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesecho Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesecho Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("DesechoRemoveView", new DesechoCrudViewModel(_serviceDesecho, _serviceDesCant));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesecho Controller Begin"));        
                
            try
            {
                // Add find logic here
                DesechoFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterDesecho"))
                {
                    model = (DesechoFindViewModel)TempData.Peek("FilterDesecho");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceDesecho.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceDesecho.FindPagedByFilter(new CustomQuery<Desecho> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedDesecho Controller End"));              
                    return PartialView("_DesechoFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterDesecho");
                    model = new DesechoFindViewModel(_serviceDesecho, _serviceDesCant);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesecho Controller End"));              
                    return View("DesechoFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesecho Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(DesechoFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesecho Controller Begin"));        
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
                    var pagedResult = _serviceDesecho.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var DesechoDetails = _serviceAlim.Query(
                    //    new DesechoQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = DesechoDetails.ToList() };
    
                    //var pagedResult = _serviceDesecho.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterDesecho", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesecho Controller End"));
                    return PartialView("_DesechoFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesecho Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("DesechoFindView", new DesechoFindViewModel(_serviceDesecho, _serviceDesCant));
        }
    
        #region Private Methods
    
        //private static QueryObject<Desecho> GenerateExpression(DesechoFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(DesechoFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Desecho.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Desecho.Id.Value.ToString() });
                    //And(d => d.Id == model.Desecho.Id.Value);
                if (!string.IsNullOrEmpty(model.Desecho.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Desecho.Nombre });				
                    //And(d => d.Nombre.Contains(model.Desecho.Nombre));
            }
    
    		return filtros;
            //return new QueryObject<Desecho>(expression ?? (d => true));
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
                //_serviceDesecho.Dispose();
                //_serviceDesCant.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
