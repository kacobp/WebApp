
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
    
    public partial class RecetaController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IRecetaAppService _serviceReceta;
        private readonly IFamRecAppService _serviceFamRec;
        private readonly IRecProdAppService _serviceRecProd;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Receta controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceFamRec">Service dependency</param>
        /// <param name="serviceRecProd">Service dependency</param>
        public RecetaController(IRecetaAppService service, IFamRecAppService serviceFamRec, IRecProdAppService serviceRecProd)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceFamRec == null)
                throw new ArgumentNullException("serviceFamRec", PresentationResources.exception_WithoutService);
            if (serviceRecProd == null)
                throw new ArgumentNullException("serviceRecProd", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceReceta = service;
            _serviceFamRec = serviceFamRec;
            _serviceRecProd = serviceRecProd;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddReceta Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new RecetaCrudViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddReceta Controller End"));              
                return View("RecetaAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddReceta Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(RecetaCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddReceta Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceReceta.Insert(model.Receta, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddReceta Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddReceta Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RecetaAddView", new RecetaCrudViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyReceta Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new RecetaCrudViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd)
                    {
                        Receta = _serviceReceta.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyReceta Controller End"));
                return View("RecetaModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyReceta Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(RecetaCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyReceta Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceReceta.Update(model.Receta, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyReceta Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyReceta Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RecetaModifyView", new RecetaCrudViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveReceta Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new RecetaCrudViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd)
                    {
                        Receta = _serviceReceta.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveReceta Controller End"));
                return View("RecetaRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveReceta Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(RecetaCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveReceta Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceReceta.Delete(model.Receta, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveReceta Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveReceta Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("RecetaRemoveView", new RecetaCrudViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindReceta Controller Begin"));        
                
            try
            {
                // Add find logic here
                RecetaFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterReceta"))
                {
                    model = (RecetaFindViewModel)TempData.Peek("FilterReceta");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceReceta.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceReceta.FindPagedByFilter(new CustomQuery<Receta> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedReceta Controller End"));              
                    return PartialView("_RecetaFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterReceta");
                    model = new RecetaFindViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindReceta Controller End"));              
                    return View("RecetaFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindReceta Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(RecetaFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindReceta Controller Begin"));        
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
                    var pagedResult = _serviceReceta.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var RecetaDetails = _serviceAlim.Query(
                    //    new RecetaQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = RecetaDetails.ToList() };
    
                    //var pagedResult = _serviceReceta.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterReceta", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindReceta Controller End"));
                    return PartialView("_RecetaFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindReceta Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("RecetaFindView", new RecetaFindViewModel(_serviceReceta, _serviceFamRec, _serviceRecProd));
        }
    
        #region Private Methods
    
        //private static QueryObject<Receta> GenerateExpression(RecetaFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(RecetaFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Receta.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Receta.Id.Value.ToString() });
                    //And(d => d.Id == model.Receta.Id.Value);
                if (model.Receta.IdFamRec.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdFamRec", value = model.Receta.IdFamRec.Value.ToString() });
                    //And(d => d.IdFamRec == model.Receta.IdFamRec.Value);
                if (model.Receta.IdRecetaBase.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdRecetaBase", value = model.Receta.IdRecetaBase.Value.ToString() });
                    //And(d => d.IdRecetaBase == model.Receta.IdRecetaBase.Value);
                if (!string.IsNullOrEmpty(model.Receta.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Receta.Nombre });				
                    //And(d => d.Nombre.Contains(model.Receta.Nombre));
                if (!string.IsNullOrEmpty(model.Receta.Alias))
    				filtros.Add(new filterRule() { op = "equal", field = "Alias", value = model.Receta.Alias });				
                    //And(d => d.Alias.Contains(model.Receta.Alias));
                if (model.Receta.Ubicacion.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Ubicacion", value = model.Receta.Ubicacion.Value.ToString() });
                    //And(d => d.Ubicacion == model.Receta.Ubicacion.Value);
                if (!string.IsNullOrEmpty(model.Receta.Descripcion))
    				filtros.Add(new filterRule() { op = "equal", field = "Descripcion", value = model.Receta.Descripcion });				
                    //And(d => d.Descripcion.Contains(model.Receta.Descripcion));
                if (!string.IsNullOrEmpty(model.Receta.Preparacion))
    				filtros.Add(new filterRule() { op = "equal", field = "Preparacion", value = model.Receta.Preparacion });				
                    //And(d => d.Preparacion.Contains(model.Receta.Preparacion));
                if (model.Receta.IdFoto.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdFoto", value = model.Receta.IdFoto.Value.ToString() });
                    //And(d => d.IdFoto == model.Receta.IdFoto.Value);
                if (model.Receta.IdEstado.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdEstado", value = model.Receta.IdEstado.Value.ToString() });
                    //And(d => d.IdEstado == model.Receta.IdEstado.Value);
                if (model.Receta.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.Receta.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.Receta.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<Receta>(expression ?? (d => true));
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
                //_serviceReceta.Dispose();
                //_serviceFamRec.Dispose();
                //_serviceRecProd.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
