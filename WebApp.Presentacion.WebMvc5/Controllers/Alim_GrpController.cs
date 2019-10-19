
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
    
    public partial class Alim_GrpController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IAlim_GrpAppService _serviceAlim_Grp;
        private readonly IAlimAppService _serviceAlim;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Alim_Grp controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        public Alim_GrpController(IAlim_GrpAppService service, IAlimAppService serviceAlim)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceAlim_Grp = service;
            _serviceAlim = serviceAlim;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Grp Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Alim_GrpCrudViewModel(_serviceAlim_Grp, _serviceAlim);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Grp Controller End"));              
                return View("Alim_GrpAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Grp Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Alim_GrpCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Grp Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceAlim_Grp.Insert(model.Alim_Grp, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Grp Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim_Grp Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Alim_GrpAddView", new Alim_GrpCrudViewModel(_serviceAlim_Grp, _serviceAlim));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Grp Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Alim_GrpCrudViewModel(_serviceAlim_Grp, _serviceAlim)
                    {
                        Alim_Grp = _serviceAlim_Grp.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Grp Controller End"));
                return View("Alim_GrpModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Grp Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Alim_GrpCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Grp Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceAlim_Grp.Update(model.Alim_Grp, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Grp Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim_Grp Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Alim_GrpModifyView", new Alim_GrpCrudViewModel(_serviceAlim_Grp, _serviceAlim));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Grp Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Alim_GrpCrudViewModel(_serviceAlim_Grp, _serviceAlim)
                    {
                        Alim_Grp = _serviceAlim_Grp.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Grp Controller End"));
                return View("Alim_GrpRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Grp Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Alim_GrpCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Grp Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceAlim_Grp.Delete(model.Alim_Grp, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Grp Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim_Grp Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Alim_GrpRemoveView", new Alim_GrpCrudViewModel(_serviceAlim_Grp, _serviceAlim));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Grp Controller Begin"));        
                
            try
            {
                // Add find logic here
                Alim_GrpFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterAlim_Grp"))
                {
                    model = (Alim_GrpFindViewModel)TempData.Peek("FilterAlim_Grp");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceAlim_Grp.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceAlim_Grp.FindPagedByFilter(new CustomQuery<Alim_Grp> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedAlim_Grp Controller End"));              
                    return PartialView("_Alim_GrpFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterAlim_Grp");
                    model = new Alim_GrpFindViewModel(_serviceAlim_Grp, _serviceAlim);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Grp Controller End"));              
                    return View("Alim_GrpFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Grp Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Alim_GrpFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Grp Controller Begin"));        
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
                    var pagedResult = _serviceAlim_Grp.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Alim_GrpDetails = _serviceAlim.Query(
                    //    new Alim_GrpQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Alim_GrpDetails.ToList() };
    
                    //var pagedResult = _serviceAlim_Grp.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterAlim_Grp", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Grp Controller End"));
                    return PartialView("_Alim_GrpFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim_Grp Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Alim_GrpFindView", new Alim_GrpFindViewModel(_serviceAlim_Grp, _serviceAlim));
        }
    
        #region Private Methods
    
        //private static QueryObject<Alim_Grp> GenerateExpression(Alim_GrpFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Alim_GrpFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Alim_Grp.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Alim_Grp.Id.Value.ToString() });
                    //And(d => d.Id == model.Alim_Grp.Id.Value);
                if (model.Alim_Grp.Cod.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Cod", value = model.Alim_Grp.Cod.Value.ToString() });
                    //And(d => d.Cod == model.Alim_Grp.Cod.Value);
                if (!string.IsNullOrEmpty(model.Alim_Grp.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Alim_Grp.Nombre });				
                    //And(d => d.Nombre.Contains(model.Alim_Grp.Nombre));
            }
    
    		return filtros;
            //return new QueryObject<Alim_Grp>(expression ?? (d => true));
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
                //_serviceAlim_Grp.Dispose();
                //_serviceAlim.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
