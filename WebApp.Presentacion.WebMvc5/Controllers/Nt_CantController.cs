
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
    
    public partial class Nt_CantController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly INt_CantAppService _serviceNt_Cant;
        private readonly IAlimAppService _serviceAlim;
        private readonly INutrienteAppService _serviceNutriente;
        private readonly INt_FuenteAppService _serviceNt_Fuente;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Cant controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceAlim">Service dependency</param>
        /// <param name="serviceNutriente">Service dependency</param>
        /// <param name="serviceNt_Fuente">Service dependency</param>
        public Nt_CantController(INt_CantAppService service, IAlimAppService serviceAlim, INutrienteAppService serviceNutriente, INt_FuenteAppService serviceNt_Fuente)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceAlim == null)
                throw new ArgumentNullException("serviceAlim", PresentationResources.exception_WithoutService);
            if (serviceNutriente == null)
                throw new ArgumentNullException("serviceNutriente", PresentationResources.exception_WithoutService);
            if (serviceNt_Fuente == null)
                throw new ArgumentNullException("serviceNt_Fuente", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceNt_Cant = service;
            _serviceAlim = serviceAlim;
            _serviceNutriente = serviceNutriente;
            _serviceNt_Fuente = serviceNt_Fuente;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Cant Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Nt_CantCrudViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Cant Controller End"));              
                return View("Nt_CantAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Cant Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Nt_CantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Cant Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Cant.Insert(model.Nt_Cant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Cant Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Cant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_CantAddView", new Nt_CantCrudViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Cant Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Nt_CantCrudViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente)
                    {
                        Nt_Cant = _serviceNt_Cant.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Cant Controller End"));
                return View("Nt_CantModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Cant Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Nt_CantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Cant Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Cant.Update(model.Nt_Cant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Cant Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Cant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_CantModifyView", new Nt_CantCrudViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Cant Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Nt_CantCrudViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente)
                    {
                        Nt_Cant = _serviceNt_Cant.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Cant Controller End"));
                return View("Nt_CantRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Cant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Nt_CantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Cant Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceNt_Cant.Delete(model.Nt_Cant, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Cant Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Cant Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_CantRemoveView", new Nt_CantCrudViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Cant Controller Begin"));        
                
            try
            {
                // Add find logic here
                Nt_CantFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterNt_Cant"))
                {
                    model = (Nt_CantFindViewModel)TempData.Peek("FilterNt_Cant");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceNt_Cant.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceNt_Cant.FindPagedByFilter(new CustomQuery<Nt_Cant> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedNt_Cant Controller End"));              
                    return PartialView("_Nt_CantFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterNt_Cant");
                    model = new Nt_CantFindViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Cant Controller End"));              
                    return View("Nt_CantFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Cant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Nt_CantFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Cant Controller Begin"));        
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
                    var pagedResult = _serviceNt_Cant.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Nt_CantDetails = _serviceAlim.Query(
                    //    new Nt_CantQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Nt_CantDetails.ToList() };
    
                    //var pagedResult = _serviceNt_Cant.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterNt_Cant", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Cant Controller End"));
                    return PartialView("_Nt_CantFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Cant Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Nt_CantFindView", new Nt_CantFindViewModel(_serviceNt_Cant, _serviceAlim, _serviceNutriente, _serviceNt_Fuente));
        }
    
        #region Private Methods
    
        //private static QueryObject<Nt_Cant> GenerateExpression(Nt_CantFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Nt_CantFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Nt_Cant.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Nt_Cant.Id.Value.ToString() });
                    //And(d => d.Id == model.Nt_Cant.Id.Value);
                if (model.Nt_Cant.IdAlim.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdAlim", value = model.Nt_Cant.IdAlim.Value.ToString() });
                    //And(d => d.IdAlim == model.Nt_Cant.IdAlim.Value);
                if (model.Nt_Cant.IdNtFte.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdNtFte", value = model.Nt_Cant.IdNtFte.Value.ToString() });
                    //And(d => d.IdNtFte == model.Nt_Cant.IdNtFte.Value);
                if (model.Nt_Cant.IdNut.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdNut", value = model.Nt_Cant.IdNut.Value.ToString() });
                    //And(d => d.IdNut == model.Nt_Cant.IdNut.Value);
                if (model.Nt_Cant.Valor.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Valor", value = model.Nt_Cant.Valor.Value.ToString() });
                    //And(d => d.Valor == model.Nt_Cant.Valor.Value);
                if (model.Nt_Cant.ErrorEstandar.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ErrorEstandar", value = model.Nt_Cant.ErrorEstandar.Value.ToString() });
                    //And(d => d.ErrorEstandar == model.Nt_Cant.ErrorEstandar.Value);
                if (model.Nt_Cant.NumObs.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "NumObs", value = model.Nt_Cant.NumObs.Value.ToString() });
                    //And(d => d.NumObs == model.Nt_Cant.NumObs.Value);
                if (model.Nt_Cant.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.Nt_Cant.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.Nt_Cant.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<Nt_Cant>(expression ?? (d => true));
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
                //_serviceNt_Cant.Dispose();
                //_serviceAlim.Dispose();
                //_serviceNutriente.Dispose();
                //_serviceNt_Fuente.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
