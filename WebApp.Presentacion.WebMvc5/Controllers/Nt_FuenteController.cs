
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
    
    public partial class Nt_FuenteController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly INt_FuenteAppService _serviceNt_Fuente;
        private readonly INt_CantAppService _serviceNt_Cant;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Fuente controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceNt_Cant">Service dependency</param>
        public Nt_FuenteController(INt_FuenteAppService service, INt_CantAppService serviceNt_Cant)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceNt_Cant == null)
                throw new ArgumentNullException("serviceNt_Cant", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceNt_Fuente = service;
            _serviceNt_Cant = serviceNt_Cant;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Fuente Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Nt_FuenteCrudViewModel(_serviceNt_Fuente, _serviceNt_Cant);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Fuente Controller End"));              
                return View("Nt_FuenteAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Fuente Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Nt_FuenteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Fuente Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Fuente.Insert(model.Nt_Fuente, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Fuente Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Fuente Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_FuenteAddView", new Nt_FuenteCrudViewModel(_serviceNt_Fuente, _serviceNt_Cant));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Fuente Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Nt_FuenteCrudViewModel(_serviceNt_Fuente, _serviceNt_Cant)
                    {
                        Nt_Fuente = _serviceNt_Fuente.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Fuente Controller End"));
                return View("Nt_FuenteModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Fuente Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Nt_FuenteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Fuente Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Fuente.Update(model.Nt_Fuente, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Fuente Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Fuente Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_FuenteModifyView", new Nt_FuenteCrudViewModel(_serviceNt_Fuente, _serviceNt_Cant));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Fuente Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Nt_FuenteCrudViewModel(_serviceNt_Fuente, _serviceNt_Cant)
                    {
                        Nt_Fuente = _serviceNt_Fuente.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Fuente Controller End"));
                return View("Nt_FuenteRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Fuente Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Nt_FuenteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Fuente Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceNt_Fuente.Delete(model.Nt_Fuente, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Fuente Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Fuente Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_FuenteRemoveView", new Nt_FuenteCrudViewModel(_serviceNt_Fuente, _serviceNt_Cant));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Fuente Controller Begin"));        
                
            try
            {
                // Add find logic here
                Nt_FuenteFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterNt_Fuente"))
                {
                    model = (Nt_FuenteFindViewModel)TempData.Peek("FilterNt_Fuente");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceNt_Fuente.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceNt_Fuente.FindPagedByFilter(new CustomQuery<Nt_Fuente> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedNt_Fuente Controller End"));              
                    return PartialView("_Nt_FuenteFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterNt_Fuente");
                    model = new Nt_FuenteFindViewModel(_serviceNt_Fuente, _serviceNt_Cant);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Fuente Controller End"));              
                    return View("Nt_FuenteFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Fuente Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Nt_FuenteFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Fuente Controller Begin"));        
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
                    var pagedResult = _serviceNt_Fuente.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Nt_FuenteDetails = _serviceAlim.Query(
                    //    new Nt_FuenteQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Nt_FuenteDetails.ToList() };
    
                    //var pagedResult = _serviceNt_Fuente.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterNt_Fuente", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Fuente Controller End"));
                    return PartialView("_Nt_FuenteFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Fuente Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Nt_FuenteFindView", new Nt_FuenteFindViewModel(_serviceNt_Fuente, _serviceNt_Cant));
        }
    
        #region Private Methods
    
        //private static QueryObject<Nt_Fuente> GenerateExpression(Nt_FuenteFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Nt_FuenteFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Nt_Fuente.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Nt_Fuente.Id.Value.ToString() });
                    //And(d => d.Id == model.Nt_Fuente.Id.Value);
                if (model.Nt_Fuente.Cod.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Cod", value = model.Nt_Fuente.Cod.Value.ToString() });
                    //And(d => d.Cod == model.Nt_Fuente.Cod.Value);
                if (!string.IsNullOrEmpty(model.Nt_Fuente.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Nt_Fuente.Nombre });				
                    //And(d => d.Nombre.Contains(model.Nt_Fuente.Nombre));
            }
    
    		return filtros;
            //return new QueryObject<Nt_Fuente>(expression ?? (d => true));
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
                //_serviceNt_Fuente.Dispose();
                //_serviceNt_Cant.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
