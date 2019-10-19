
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
    
    public partial class FamRecController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IFamRecAppService _serviceFamRec;
        private readonly IRecetaAppService _serviceReceta;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of FamRec controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceReceta">Service dependency</param>
        public FamRecController(IFamRecAppService service, IRecetaAppService serviceReceta)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceReceta == null)
                throw new ArgumentNullException("serviceReceta", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceFamRec = service;
            _serviceReceta = serviceReceta;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFamRec Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new FamRecCrudViewModel(_serviceFamRec, _serviceReceta);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFamRec Controller End"));              
                return View("FamRecAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFamRec Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FamRecCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFamRec Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceFamRec.Insert(model.FamRec, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFamRec Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFamRec Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("FamRecAddView", new FamRecCrudViewModel(_serviceFamRec, _serviceReceta));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFamRec Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new FamRecCrudViewModel(_serviceFamRec, _serviceReceta)
                    {
                        FamRec = _serviceFamRec.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFamRec Controller End"));
                return View("FamRecModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFamRec Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(FamRecCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFamRec Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceFamRec.Update(model.FamRec, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFamRec Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFamRec Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("FamRecModifyView", new FamRecCrudViewModel(_serviceFamRec, _serviceReceta));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFamRec Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new FamRecCrudViewModel(_serviceFamRec, _serviceReceta)
                    {
                        FamRec = _serviceFamRec.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFamRec Controller End"));
                return View("FamRecRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFamRec Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(FamRecCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFamRec Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceFamRec.Delete(model.FamRec, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFamRec Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFamRec Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("FamRecRemoveView", new FamRecCrudViewModel(_serviceFamRec, _serviceReceta));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFamRec Controller Begin"));        
                
            try
            {
                // Add find logic here
                FamRecFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterFamRec"))
                {
                    model = (FamRecFindViewModel)TempData.Peek("FilterFamRec");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceFamRec.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceFamRec.FindPagedByFilter(new CustomQuery<FamRec> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedFamRec Controller End"));              
                    return PartialView("_FamRecFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterFamRec");
                    model = new FamRecFindViewModel(_serviceFamRec, _serviceReceta);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFamRec Controller End"));              
                    return View("FamRecFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFamRec Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(FamRecFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFamRec Controller Begin"));        
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
                    var pagedResult = _serviceFamRec.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var FamRecDetails = _serviceAlim.Query(
                    //    new FamRecQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = FamRecDetails.ToList() };
    
                    //var pagedResult = _serviceFamRec.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterFamRec", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFamRec Controller End"));
                    return PartialView("_FamRecFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFamRec Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("FamRecFindView", new FamRecFindViewModel(_serviceFamRec, _serviceReceta));
        }
    
        #region Private Methods
    
        //private static QueryObject<FamRec> GenerateExpression(FamRecFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(FamRecFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.FamRec.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.FamRec.Id.Value.ToString() });
                    //And(d => d.Id == model.FamRec.Id.Value);
                if (!string.IsNullOrEmpty(model.FamRec.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.FamRec.Nombre });				
                    //And(d => d.Nombre.Contains(model.FamRec.Nombre));
                if (!string.IsNullOrEmpty(model.FamRec.Descripcion))
    				filtros.Add(new filterRule() { op = "equal", field = "Descripcion", value = model.FamRec.Descripcion });				
                    //And(d => d.Descripcion.Contains(model.FamRec.Descripcion));
                if (model.FamRec.Base.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Base", value = model.FamRec.Base.Value.ToString() });
                    //And(d => d.Base == model.FamRec.Base.Value);
                if (model.FamRec.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.FamRec.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.FamRec.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<FamRec>(expression ?? (d => true));
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
                //_serviceFamRec.Dispose();
                //_serviceReceta.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
