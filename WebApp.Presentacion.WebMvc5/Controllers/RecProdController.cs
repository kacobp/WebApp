
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
    
    public partial class RecProdController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IRecProdAppService _serviceRecProd;
        private readonly IAlimAppService _serviceAlim;
        private readonly IRecetaAppService _serviceReceta;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of RecProd controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        /// <param name="serviceReceta">Service dependency</param>
        public RecProdController(IRecProdAppService service, IAlimAppService serviceAlim, IRecetaAppService serviceReceta)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
            if (serviceReceta == null)
                throw new ArgumentNullException("serviceReceta", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceRecProd = service;
            _serviceAlim = serviceAlim;
            _serviceReceta = serviceReceta;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRecProd Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new RecProdCrudViewModel(_serviceRecProd, _serviceAlim, _serviceReceta);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRecProd Controller End"));              
                return View("RecProdAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRecProd Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RecProdCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRecProd Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRecProd.Insert(model.RecProd, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRecProd Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddRecProd Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RecProdAddView", new RecProdCrudViewModel(_serviceRecProd, _serviceAlim, _serviceReceta));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRecProd Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new RecProdCrudViewModel(_serviceRecProd, _serviceAlim, _serviceReceta)
                    {
                        RecProd = _serviceRecProd.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRecProd Controller End"));
                return View("RecProdModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRecProd Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(RecProdCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRecProd Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceRecProd.Update(model.RecProd, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRecProd Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyRecProd Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RecProdModifyView", new RecProdCrudViewModel(_serviceRecProd, _serviceAlim, _serviceReceta));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRecProd Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new RecProdCrudViewModel(_serviceRecProd, _serviceAlim, _serviceReceta)
                    {
                        RecProd = _serviceRecProd.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRecProd Controller End"));
                return View("RecProdRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRecProd Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(RecProdCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRecProd Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceRecProd.Delete(model.RecProd, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRecProd Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveRecProd Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RecProdRemoveView", new RecProdCrudViewModel(_serviceRecProd, _serviceAlim, _serviceReceta));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRecProd Controller Begin"));        
                
            try
            {
                // Add find logic here
                RecProdFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterRecProd"))
                {
                    model = (RecProdFindViewModel)TempData.Peek("FilterRecProd");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceRecProd.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceRecProd.FindPagedByFilter(new CustomQuery<RecProd> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedRecProd Controller End"));              
                    return PartialView("_RecProdFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterRecProd");
                    model = new RecProdFindViewModel(_serviceRecProd, _serviceAlim, _serviceReceta);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRecProd Controller End"));              
                    return View("RecProdFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRecProd Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(RecProdFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRecProd Controller Begin"));        
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
                    var pagedResult = _serviceRecProd.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var RecProdDetails = _serviceAlim.Query(
                    //    new RecProdQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = RecProdDetails.ToList() };
    
                    //var pagedResult = _serviceRecProd.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterRecProd", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRecProd Controller End"));
                    return PartialView("_RecProdFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindRecProd Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("RecProdFindView", new RecProdFindViewModel(_serviceRecProd, _serviceAlim, _serviceReceta));
        }
    
        #region Private Methods
    
        //private static QueryObject<RecProd> GenerateExpression(RecProdFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(RecProdFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.RecProd.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.RecProd.Id.Value.ToString() });
                    //And(d => d.Id == model.RecProd.Id.Value);
                if (model.RecProd.IdReceta.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdReceta", value = model.RecProd.IdReceta.Value.ToString() });
                    //And(d => d.IdReceta == model.RecProd.IdReceta.Value);
                if (model.RecProd.IdProducto.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdProducto", value = model.RecProd.IdProducto.Value.ToString() });
                    //And(d => d.IdProducto == model.RecProd.IdProducto.Value);
                if (model.RecProd.IdProveedor.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdProveedor", value = model.RecProd.IdProveedor.Value.ToString() });
                    //And(d => d.IdProveedor == model.RecProd.IdProveedor.Value);
                if (model.RecProd.Gramos.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Gramos", value = model.RecProd.Gramos.Value.ToString() });
                    //And(d => d.Gramos == model.RecProd.Gramos.Value);
                if (model.RecProd.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.RecProd.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.RecProd.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<RecProd>(expression ?? (d => true));
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
                //_serviceRecProd.Dispose();
                //_serviceAlim.Dispose();
                //_serviceReceta.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
