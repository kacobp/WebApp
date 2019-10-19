
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
    
    public partial class Alim_FuenteController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IAlim_FuenteAppService _serviceAlim_Fuente;
        private readonly IAlimAppService _serviceAlim;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Alim_Fuente controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        public Alim_FuenteController(IAlim_FuenteAppService service, IAlimAppService serviceAlim)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceAlim_Fuente = service;
            _serviceAlim = serviceAlim;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Fuente Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Alim_FuenteCrudViewModel(_serviceAlim_Fuente, _serviceAlim);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Fuente Controller End"));              
                return View("Alim_FuenteAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Fuente Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Alim_FuenteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Fuente Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceAlim_Fuente.Insert(model.Alim_Fuente, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Fuente Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Fuente Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Alim_FuenteAddView", new Alim_FuenteCrudViewModel(_serviceAlim_Fuente, _serviceAlim));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Fuente Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Alim_FuenteCrudViewModel(_serviceAlim_Fuente, _serviceAlim)
                    {
                        Alim_Fuente = _serviceAlim_Fuente.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Fuente Controller End"));
                return View("Alim_FuenteModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Fuente Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Alim_FuenteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Fuente Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceAlim_Fuente.Update(model.Alim_Fuente, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Fuente Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Fuente Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Alim_FuenteModifyView", new Alim_FuenteCrudViewModel(_serviceAlim_Fuente, _serviceAlim));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Fuente Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Alim_FuenteCrudViewModel(_serviceAlim_Fuente, _serviceAlim)
                    {
                        Alim_Fuente = _serviceAlim_Fuente.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Fuente Controller End"));
                return View("Alim_FuenteRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Fuente Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Alim_FuenteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Fuente Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceAlim_Fuente.Delete(model.Alim_Fuente, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Fuente Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Fuente Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Alim_FuenteRemoveView", new Alim_FuenteCrudViewModel(_serviceAlim_Fuente, _serviceAlim));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Fuente Controller Begin"));        
                
            try
            {
                // Add find logic here
                Alim_FuenteFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterAlim_Fuente"))
                {
                    model = (Alim_FuenteFindViewModel)TempData.Peek("FilterAlim_Fuente");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceAlim_Fuente.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceAlim_Fuente.FindPagedByFilter(new CustomQuery<Alim_Fuente> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedAlim_Fuente Controller End"));              
                    return PartialView("_Alim_FuenteFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterAlim_Fuente");
                    model = new Alim_FuenteFindViewModel(_serviceAlim_Fuente, _serviceAlim);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Fuente Controller End"));              
                    return View("Alim_FuenteFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Fuente Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Alim_FuenteFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Fuente Controller Begin"));        
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
                    var pagedResult = _serviceAlim_Fuente.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Alim_FuenteDetails = _serviceAlim.Query(
                    //    new Alim_FuenteQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Alim_FuenteDetails.ToList() };
    
                    //var pagedResult = _serviceAlim_Fuente.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterAlim_Fuente", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Fuente Controller End"));
                    return PartialView("_Alim_FuenteFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Fuente Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Alim_FuenteFindView", new Alim_FuenteFindViewModel(_serviceAlim_Fuente, _serviceAlim));
        }
    
        #region Private Methods
    
        //private static QueryObject<Alim_Fuente> GenerateExpression(Alim_FuenteFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Alim_FuenteFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Alim_Fuente.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Alim_Fuente.Id.Value.ToString() });
                    //And(d => d.Id == model.Alim_Fuente.Id.Value);
                if (model.Alim_Fuente.Cod.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Cod", value = model.Alim_Fuente.Cod.Value.ToString() });
                    //And(d => d.Cod == model.Alim_Fuente.Cod.Value);
                if (!string.IsNullOrEmpty(model.Alim_Fuente.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Alim_Fuente.Nombre });				
                    //And(d => d.Nombre.Contains(model.Alim_Fuente.Nombre));
            }
    
    		return filtros;
            //return new QueryObject<Alim_Fuente>(expression ?? (d => true));
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
                //_serviceAlim_Fuente.Dispose();
                //_serviceAlim.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
