
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
    
    public partial class DesCantController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IDesCantAppService _serviceDesCant;
        private readonly IAlimAppService _serviceAlim;
        private readonly IDesechoAppService _serviceDesecho;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of DesCant controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        /// <param name="serviceDesecho">Service dependency</param>
        public DesCantController(IDesCantAppService service, IAlimAppService serviceAlim, IDesechoAppService serviceDesecho)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
            if (serviceDesecho == null)
                throw new ArgumentNullException("serviceDesecho", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceDesCant = service;
            _serviceAlim = serviceAlim;
            _serviceDesecho = serviceDesecho;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesCant Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new DesCantCrudViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesCant Controller End"));              
                return View("DesCantAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesCant Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DesCantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesCant Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceDesCant.Insert(model.DesCant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesCant Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddDesCant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("DesCantAddView", new DesCantCrudViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesCant Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new DesCantCrudViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho)
                    {
                        DesCant = _serviceDesCant.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesCant Controller End"));
                return View("DesCantModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesCant Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(DesCantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesCant Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceDesCant.Update(model.DesCant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesCant Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyDesCant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("DesCantModifyView", new DesCantCrudViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesCant Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new DesCantCrudViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho)
                    {
                        DesCant = _serviceDesCant.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesCant Controller End"));
                return View("DesCantRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesCant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(DesCantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesCant Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceDesCant.Delete(model.DesCant, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesCant Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveDesCant Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("DesCantRemoveView", new DesCantCrudViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesCant Controller Begin"));        
                
            try
            {
                // Add find logic here
                DesCantFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterDesCant"))
                {
                    model = (DesCantFindViewModel)TempData.Peek("FilterDesCant");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceDesCant.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceDesCant.FindPagedByFilter(new CustomQuery<DesCant> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedDesCant Controller End"));              
                    return PartialView("_DesCantFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterDesCant");
                    model = new DesCantFindViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesCant Controller End"));              
                    return View("DesCantFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesCant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(DesCantFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesCant Controller Begin"));        
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
                    var pagedResult = _serviceDesCant.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var DesCantDetails = _serviceAlim.Query(
                    //    new DesCantQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = DesCantDetails.ToList() };
    
                    //var pagedResult = _serviceDesCant.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterDesCant", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesCant Controller End"));
                    return PartialView("_DesCantFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindDesCant Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("DesCantFindView", new DesCantFindViewModel(_serviceDesCant, _serviceAlim, _serviceDesecho));
        }
    
        #region Private Methods
    
        //private static QueryObject<DesCant> GenerateExpression(DesCantFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(DesCantFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.DesCant.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.DesCant.Id.Value.ToString() });
                    //And(d => d.Id == model.DesCant.Id.Value);
                if (model.DesCant.IdAlim.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdAlim", value = model.DesCant.IdAlim.Value.ToString() });
                    //And(d => d.IdAlim == model.DesCant.IdAlim.Value);
                if (model.DesCant.IdDes.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdDes", value = model.DesCant.IdDes.Value.ToString() });
                    //And(d => d.IdDes == model.DesCant.IdDes.Value);
                if (model.DesCant.Cantidad.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Cantidad", value = model.DesCant.Cantidad.Value.ToString() });
                    //And(d => d.Cantidad == model.DesCant.Cantidad.Value);
                if (model.DesCant.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.DesCant.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.DesCant.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<DesCant>(expression ?? (d => true));
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
                //_serviceDesCant.Dispose();
                //_serviceAlim.Dispose();
                //_serviceDesecho.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
