
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
    
    public partial class Nt_GrpController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly INt_GrpAppService _serviceNt_Grp;
        private readonly INt_Grp_CantAppService _serviceNt_Grp_Cant;
        private readonly INutrienteAppService _serviceNutriente;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Grp controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceNt_Grp_Cant">Service dependency</param>
        /// <param name="serviceNutriente">Service dependency</param>
        public Nt_GrpController(INt_GrpAppService service, INt_Grp_CantAppService serviceNt_Grp_Cant, INutrienteAppService serviceNutriente)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceNt_Grp_Cant == null)
                throw new ArgumentNullException("serviceNt_Grp_Cant", PresentationResources.exception_WithoutService);
            if (serviceNutriente == null)
                throw new ArgumentNullException("serviceNutriente", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceNt_Grp = service;
            _serviceNt_Grp_Cant = serviceNt_Grp_Cant;
            _serviceNutriente = serviceNutriente;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Nt_GrpCrudViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp Controller End"));              
                return View("Nt_GrpAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Nt_GrpCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Grp.Insert(model.Nt_Grp, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_GrpAddView", new Nt_GrpCrudViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Nt_GrpCrudViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente)
                    {
                        Nt_Grp = _serviceNt_Grp.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp Controller End"));
                return View("Nt_GrpModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Nt_GrpCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Grp.Update(model.Nt_Grp, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_GrpModifyView", new Nt_GrpCrudViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Nt_GrpCrudViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente)
                    {
                        Nt_Grp = _serviceNt_Grp.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp Controller End"));
                return View("Nt_GrpRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Nt_GrpCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceNt_Grp.Delete(model.Nt_Grp, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_GrpRemoveView", new Nt_GrpCrudViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp Controller Begin"));        
                
            try
            {
                // Add find logic here
                Nt_GrpFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterNt_Grp"))
                {
                    model = (Nt_GrpFindViewModel)TempData.Peek("FilterNt_Grp");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceNt_Grp.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceNt_Grp.FindPagedByFilter(new CustomQuery<Nt_Grp> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedNt_Grp Controller End"));              
                    return PartialView("_Nt_GrpFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterNt_Grp");
                    model = new Nt_GrpFindViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp Controller End"));              
                    return View("Nt_GrpFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Nt_GrpFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp Controller Begin"));        
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
                    var pagedResult = _serviceNt_Grp.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Nt_GrpDetails = _serviceAlim.Query(
                    //    new Nt_GrpQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Nt_GrpDetails.ToList() };
    
                    //var pagedResult = _serviceNt_Grp.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterNt_Grp", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp Controller End"));
                    return PartialView("_Nt_GrpFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Nt_GrpFindView", new Nt_GrpFindViewModel(_serviceNt_Grp, _serviceNt_Grp_Cant, _serviceNutriente));
        }
    
        #region Private Methods
    
        //private static QueryObject<Nt_Grp> GenerateExpression(Nt_GrpFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Nt_GrpFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Nt_Grp.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Nt_Grp.Id.Value.ToString() });
                    //And(d => d.Id == model.Nt_Grp.Id.Value);
                if (!string.IsNullOrEmpty(model.Nt_Grp.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Nt_Grp.Nombre });				
                    //And(d => d.Nombre.Contains(model.Nt_Grp.Nombre));
                if (!string.IsNullOrEmpty(model.Nt_Grp.Descripcion))
    				filtros.Add(new filterRule() { op = "equal", field = "Descripcion", value = model.Nt_Grp.Descripcion });				
                    //And(d => d.Descripcion.Contains(model.Nt_Grp.Descripcion));
                if (model.Nt_Grp.IdGrpCantNT.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdGrpCantNT", value = model.Nt_Grp.IdGrpCantNT.Value.ToString() });
                    //And(d => d.IdGrpCantNT == model.Nt_Grp.IdGrpCantNT.Value);
            }
    
    		return filtros;
            //return new QueryObject<Nt_Grp>(expression ?? (d => true));
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
                //_serviceNt_Grp.Dispose();
                //_serviceNt_Grp_Cant.Dispose();
                //_serviceNutriente.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
