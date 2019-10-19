
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
    
    public partial class FactConvController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IFactConvAppService _serviceFactConv;
        private readonly IAlimAppService _serviceAlim;
        private readonly IMedidaAppService _serviceMedida;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of FactConv controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        /// <param name="serviceMedida">Service dependency</param>
        public FactConvController(IFactConvAppService service, IAlimAppService serviceAlim, IMedidaAppService serviceMedida)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
            if (serviceMedida == null)
                throw new ArgumentNullException("serviceMedida", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceFactConv = service;
            _serviceAlim = serviceAlim;
            _serviceMedida = serviceMedida;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFactConv Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new FactConvCrudViewModel(_serviceFactConv, _serviceAlim, _serviceMedida);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFactConv Controller End"));              
                return View("FactConvAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFactConv Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(FactConvCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFactConv Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceFactConv.Insert(model.FactConv, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFactConv Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddFactConv Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("FactConvAddView", new FactConvCrudViewModel(_serviceFactConv, _serviceAlim, _serviceMedida));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFactConv Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new FactConvCrudViewModel(_serviceFactConv, _serviceAlim, _serviceMedida)
                    {
                        FactConv = _serviceFactConv.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFactConv Controller End"));
                return View("FactConvModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFactConv Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(FactConvCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFactConv Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceFactConv.Update(model.FactConv, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFactConv Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyFactConv Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("FactConvModifyView", new FactConvCrudViewModel(_serviceFactConv, _serviceAlim, _serviceMedida));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFactConv Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new FactConvCrudViewModel(_serviceFactConv, _serviceAlim, _serviceMedida)
                    {
                        FactConv = _serviceFactConv.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFactConv Controller End"));
                return View("FactConvRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFactConv Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(FactConvCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFactConv Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceFactConv.Delete(model.FactConv, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFactConv Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveFactConv Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("FactConvRemoveView", new FactConvCrudViewModel(_serviceFactConv, _serviceAlim, _serviceMedida));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFactConv Controller Begin"));        
                
            try
            {
                // Add find logic here
                FactConvFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterFactConv"))
                {
                    model = (FactConvFindViewModel)TempData.Peek("FilterFactConv");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceFactConv.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceFactConv.FindPagedByFilter(new CustomQuery<FactConv> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedFactConv Controller End"));              
                    return PartialView("_FactConvFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterFactConv");
                    model = new FactConvFindViewModel(_serviceFactConv, _serviceAlim, _serviceMedida);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFactConv Controller End"));              
                    return View("FactConvFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFactConv Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(FactConvFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFactConv Controller Begin"));        
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
                    var pagedResult = _serviceFactConv.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var FactConvDetails = _serviceAlim.Query(
                    //    new FactConvQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = FactConvDetails.ToList() };
    
                    //var pagedResult = _serviceFactConv.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterFactConv", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFactConv Controller End"));
                    return PartialView("_FactConvFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindFactConv Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("FactConvFindView", new FactConvFindViewModel(_serviceFactConv, _serviceAlim, _serviceMedida));
        }
    
        #region Private Methods
    
        //private static QueryObject<FactConv> GenerateExpression(FactConvFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(FactConvFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.FactConv.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.FactConv.Id.Value.ToString() });
                    //And(d => d.Id == model.FactConv.Id.Value);
                if (model.FactConv.IdAlim.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdAlim", value = model.FactConv.IdAlim.Value.ToString() });
                    //And(d => d.IdAlim == model.FactConv.IdAlim.Value);
                if (model.FactConv.IdMed.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdMed", value = model.FactConv.IdMed.Value.ToString() });
                    //And(d => d.IdMed == model.FactConv.IdMed.Value);
                if (model.FactConv.Factor.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Factor", value = model.FactConv.Factor.Value.ToString() });
                    //And(d => d.Factor == model.FactConv.Factor.Value);
                if (model.FactConv.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.FactConv.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.FactConv.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<FactConv>(expression ?? (d => true));
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
                //_serviceFactConv.Dispose();
                //_serviceAlim.Dispose();
                //_serviceMedida.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
