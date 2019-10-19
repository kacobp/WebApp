
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
    
    public partial class UniMedController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IUniMedAppService _serviceUniMed;
        private readonly IAlimAppService _serviceAlim;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of UniMed controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        public UniMedController(IUniMedAppService service, IAlimAppService serviceAlim)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceUniMed = service;
            _serviceAlim = serviceAlim;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUniMed Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new UniMedCrudViewModel(_serviceUniMed, _serviceAlim);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUniMed Controller End"));              
                return View("UniMedAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUniMed Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UniMedCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUniMed Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUniMed.Insert(model.UniMed, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUniMed Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUniMed Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UniMedAddView", new UniMedCrudViewModel(_serviceUniMed, _serviceAlim));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUniMed Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new UniMedCrudViewModel(_serviceUniMed, _serviceAlim)
                    {
                        UniMed = _serviceUniMed.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUniMed Controller End"));
                return View("UniMedModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUniMed Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(UniMedCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUniMed Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUniMed.Update(model.UniMed, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUniMed Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUniMed Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UniMedModifyView", new UniMedCrudViewModel(_serviceUniMed, _serviceAlim));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUniMed Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new UniMedCrudViewModel(_serviceUniMed, _serviceAlim)
                    {
                        UniMed = _serviceUniMed.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUniMed Controller End"));
                return View("UniMedRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUniMed Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(UniMedCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUniMed Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceUniMed.Delete(model.UniMed, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUniMed Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUniMed Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UniMedRemoveView", new UniMedCrudViewModel(_serviceUniMed, _serviceAlim));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUniMed Controller Begin"));        
                
            try
            {
                // Add find logic here
                UniMedFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterUniMed"))
                {
                    model = (UniMedFindViewModel)TempData.Peek("FilterUniMed");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceUniMed.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceUniMed.FindPagedByFilter(new CustomQuery<UniMed> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedUniMed Controller End"));              
                    return PartialView("_UniMedFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterUniMed");
                    model = new UniMedFindViewModel(_serviceUniMed, _serviceAlim);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUniMed Controller End"));              
                    return View("UniMedFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUniMed Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(UniMedFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUniMed Controller Begin"));        
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
                    var pagedResult = _serviceUniMed.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var UniMedDetails = _serviceAlim.Query(
                    //    new UniMedQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = UniMedDetails.ToList() };
    
                    //var pagedResult = _serviceUniMed.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterUniMed", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUniMed Controller End"));
                    return PartialView("_UniMedFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUniMed Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("UniMedFindView", new UniMedFindViewModel(_serviceUniMed, _serviceAlim));
        }
    
        #region Private Methods
    
        //private static QueryObject<UniMed> GenerateExpression(UniMedFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(UniMedFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.UniMed.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.UniMed.Id.Value.ToString() });
                    //And(d => d.Id == model.UniMed.Id.Value);
                if (!string.IsNullOrEmpty(model.UniMed.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.UniMed.Nombre });				
                    //And(d => d.Nombre.Contains(model.UniMed.Nombre));
                if (!string.IsNullOrEmpty(model.UniMed.Descripcion))
    				filtros.Add(new filterRule() { op = "equal", field = "Descripcion", value = model.UniMed.Descripcion });				
                    //And(d => d.Descripcion.Contains(model.UniMed.Descripcion));
                if (!string.IsNullOrEmpty(model.UniMed.CodUMed))
    				filtros.Add(new filterRule() { op = "equal", field = "CodUMed", value = model.UniMed.CodUMed });				
                    //And(d => d.CodUMed.Contains(model.UniMed.CodUMed));
            }
    
    		return filtros;
            //return new QueryObject<UniMed>(expression ?? (d => true));
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
                //_serviceUniMed.Dispose();
                //_serviceAlim.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
