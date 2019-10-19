
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
    
    public partial class Nt_Grp_CantController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly INt_Grp_CantAppService _serviceNt_Grp_Cant;
        private readonly INt_GrpAppService _serviceNt_Grp;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nt_Grp_Cant controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceNt_Grp">Service dependency</param>
        public Nt_Grp_CantController(INt_Grp_CantAppService service, INt_GrpAppService serviceNt_Grp)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceNt_Grp == null)
                throw new ArgumentNullException("serviceNt_Grp", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceNt_Grp_Cant = service;
            _serviceNt_Grp = serviceNt_Grp;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp_Cant Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Nt_Grp_CantCrudViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp_Cant Controller End"));              
                return View("Nt_Grp_CantAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp_Cant Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Nt_Grp_CantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp_Cant Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Grp_Cant.Insert(model.Nt_Grp_Cant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp_Cant Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNt_Grp_Cant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_Grp_CantAddView", new Nt_Grp_CantCrudViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp_Cant Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Nt_Grp_CantCrudViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp)
                    {
                        Nt_Grp_Cant = _serviceNt_Grp_Cant.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp_Cant Controller End"));
                return View("Nt_Grp_CantModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp_Cant Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Nt_Grp_CantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp_Cant Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNt_Grp_Cant.Update(model.Nt_Grp_Cant, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp_Cant Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNt_Grp_Cant Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_Grp_CantModifyView", new Nt_Grp_CantCrudViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp_Cant Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Nt_Grp_CantCrudViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp)
                    {
                        Nt_Grp_Cant = _serviceNt_Grp_Cant.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp_Cant Controller End"));
                return View("Nt_Grp_CantRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp_Cant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Nt_Grp_CantCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp_Cant Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceNt_Grp_Cant.Delete(model.Nt_Grp_Cant, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp_Cant Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNt_Grp_Cant Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Nt_Grp_CantRemoveView", new Nt_Grp_CantCrudViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp_Cant Controller Begin"));        
                
            try
            {
                // Add find logic here
                Nt_Grp_CantFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterNt_Grp_Cant"))
                {
                    model = (Nt_Grp_CantFindViewModel)TempData.Peek("FilterNt_Grp_Cant");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceNt_Grp_Cant.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceNt_Grp_Cant.FindPagedByFilter(new CustomQuery<Nt_Grp_Cant> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedNt_Grp_Cant Controller End"));              
                    return PartialView("_Nt_Grp_CantFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterNt_Grp_Cant");
                    model = new Nt_Grp_CantFindViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp_Cant Controller End"));              
                    return View("Nt_Grp_CantFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp_Cant Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Nt_Grp_CantFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp_Cant Controller Begin"));        
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
                    var pagedResult = _serviceNt_Grp_Cant.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Nt_Grp_CantDetails = _serviceAlim.Query(
                    //    new Nt_Grp_CantQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Nt_Grp_CantDetails.ToList() };
    
                    //var pagedResult = _serviceNt_Grp_Cant.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterNt_Grp_Cant", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp_Cant Controller End"));
                    return PartialView("_Nt_Grp_CantFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNt_Grp_Cant Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Nt_Grp_CantFindView", new Nt_Grp_CantFindViewModel(_serviceNt_Grp_Cant, _serviceNt_Grp));
        }
    
        #region Private Methods
    
        //private static QueryObject<Nt_Grp_Cant> GenerateExpression(Nt_Grp_CantFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Nt_Grp_CantFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Nt_Grp_Cant.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Nt_Grp_Cant.Id.Value.ToString() });
                    //And(d => d.Id == model.Nt_Grp_Cant.Id.Value);
                if (!string.IsNullOrEmpty(model.Nt_Grp_Cant.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Nt_Grp_Cant.Nombre });				
                    //And(d => d.Nombre.Contains(model.Nt_Grp_Cant.Nombre));
                if (!string.IsNullOrEmpty(model.Nt_Grp_Cant.Descripcion))
    				filtros.Add(new filterRule() { op = "equal", field = "Descripcion", value = model.Nt_Grp_Cant.Descripcion });				
                    //And(d => d.Descripcion.Contains(model.Nt_Grp_Cant.Descripcion));
            }
    
    		return filtros;
            //return new QueryObject<Nt_Grp_Cant>(expression ?? (d => true));
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
                //_serviceNt_Grp_Cant.Dispose();
                //_serviceNt_Grp.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
