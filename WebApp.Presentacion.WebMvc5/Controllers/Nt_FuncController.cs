
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
    
    public partial class Nt_FuncController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly INt_FuncAppService _serviceNt_Func;
        private readonly INutrienteAppService _serviceNutriente;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Func controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceNutriente">Service dependency</param>
        public Nt_FuncController(INt_FuncAppService service, INutrienteAppService serviceNutriente)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceNutriente == null)
                throw new ArgumentNullException("serviceNutriente", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceNt_Func = service;
            _serviceNutriente = serviceNutriente;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Func Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Nt_FuncCrudViewModel(_serviceNt_Func, _serviceNutriente);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Func Controller End"));              
                return View("Nt_FuncAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Func Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Nt_FuncCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Func Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Func.Insert(model.Nt_Func, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Func Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Func Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_FuncAddView", new Nt_FuncCrudViewModel(_serviceNt_Func, _serviceNutriente));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Func Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Nt_FuncCrudViewModel(_serviceNt_Func, _serviceNutriente)
                    {
                        Nt_Func = _serviceNt_Func.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Func Controller End"));
                return View("Nt_FuncModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Func Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Nt_FuncCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Func Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Func.Update(model.Nt_Func, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Func Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Func Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_FuncModifyView", new Nt_FuncCrudViewModel(_serviceNt_Func, _serviceNutriente));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Func Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Nt_FuncCrudViewModel(_serviceNt_Func, _serviceNutriente)
                    {
                        Nt_Func = _serviceNt_Func.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Func Controller End"));
                return View("Nt_FuncRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Func Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Nt_FuncCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Func Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceNt_Func.Delete(model.Nt_Func, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Func Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Func Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_FuncRemoveView", new Nt_FuncCrudViewModel(_serviceNt_Func, _serviceNutriente));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Func Controller Begin"));        
                
            try
            {
                // Add find logic here
                Nt_FuncFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterNt_Func"))
                {
                    model = (Nt_FuncFindViewModel)TempData.Peek("FilterNt_Func");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceNt_Func.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceNt_Func.FindPagedByFilter(new CustomQuery<Nt_Func> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedNt_Func Controller End"));              
                    return PartialView("_Nt_FuncFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterNt_Func");
                    model = new Nt_FuncFindViewModel(_serviceNt_Func, _serviceNutriente);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Func Controller End"));              
                    return View("Nt_FuncFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Func Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Nt_FuncFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Func Controller Begin"));        
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
                    var pagedResult = _serviceNt_Func.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Nt_FuncDetails = _serviceAlim.Query(
                    //    new Nt_FuncQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Nt_FuncDetails.ToList() };
    
                    //var pagedResult = _serviceNt_Func.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterNt_Func", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Func Controller End"));
                    return PartialView("_Nt_FuncFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Func Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Nt_FuncFindView", new Nt_FuncFindViewModel(_serviceNt_Func, _serviceNutriente));
        }
    
        #region Private Methods
    
        //private static QueryObject<Nt_Func> GenerateExpression(Nt_FuncFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Nt_FuncFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Nt_Func.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Nt_Func.Id.Value.ToString() });
                    //And(d => d.Id == model.Nt_Func.Id.Value);
                if (!string.IsNullOrEmpty(model.Nt_Func.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Nt_Func.Nombre });				
                    //And(d => d.Nombre.Contains(model.Nt_Func.Nombre));
                if (!string.IsNullOrEmpty(model.Nt_Func.Descripcion))
    				filtros.Add(new filterRule() { op = "equal", field = "Descripcion", value = model.Nt_Func.Descripcion });				
                    //And(d => d.Descripcion.Contains(model.Nt_Func.Descripcion));
            }
    
    		return filtros;
            //return new QueryObject<Nt_Func>(expression ?? (d => true));
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
                //_serviceNt_Func.Dispose();
                //_serviceNutriente.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
