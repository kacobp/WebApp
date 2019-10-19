
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
    
    public partial class NutrienteController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly INutrienteAppService _serviceNutriente;
        private readonly INt_CantAppService _serviceNt_Cant;
        private readonly INt_FuncAppService _serviceNt_Func;
        private readonly INt_GrpAppService _serviceNt_Grp;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Nutriente controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceNt_Cant">Service dependency</param>
        /// <param name="serviceNt_Func">Service dependency</param>
        /// <param name="serviceNt_Grp">Service dependency</param>
        public NutrienteController(INutrienteAppService service, INt_CantAppService serviceNt_Cant, INt_FuncAppService serviceNt_Func, INt_GrpAppService serviceNt_Grp)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceNt_Cant == null)
                throw new ArgumentNullException("serviceNt_Cant", PresentationResources.exception_WithoutService);
            if (serviceNt_Func == null)
                throw new ArgumentNullException("serviceNt_Func", PresentationResources.exception_WithoutService);
            if (serviceNt_Grp == null)
                throw new ArgumentNullException("serviceNt_Grp", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceNutriente = service;
            _serviceNt_Cant = serviceNt_Cant;
            _serviceNt_Func = serviceNt_Func;
            _serviceNt_Grp = serviceNt_Grp;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNutriente Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new NutrienteCrudViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNutriente Controller End"));              
                return View("NutrienteAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNutriente Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NutrienteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNutriente Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNutriente.Insert(model.Nutriente, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNutriente Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddNutriente Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("NutrienteAddView", new NutrienteCrudViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNutriente Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new NutrienteCrudViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp)
                    {
                        Nutriente = _serviceNutriente.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNutriente Controller End"));
                return View("NutrienteModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNutriente Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(NutrienteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNutriente Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceNutriente.Update(model.Nutriente, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNutriente Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyNutriente Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("NutrienteModifyView", new NutrienteCrudViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNutriente Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new NutrienteCrudViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp)
                    {
                        Nutriente = _serviceNutriente.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNutriente Controller End"));
                return View("NutrienteRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNutriente Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(NutrienteCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNutriente Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceNutriente.Delete(model.Nutriente, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNutriente Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveNutriente Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("NutrienteRemoveView", new NutrienteCrudViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNutriente Controller Begin"));        
                
            try
            {
                // Add find logic here
                NutrienteFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterNutriente"))
                {
                    model = (NutrienteFindViewModel)TempData.Peek("FilterNutriente");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceNutriente.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceNutriente.FindPagedByFilter(new CustomQuery<Nutriente> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedNutriente Controller End"));              
                    return PartialView("_NutrienteFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterNutriente");
                    model = new NutrienteFindViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNutriente Controller End"));              
                    return View("NutrienteFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNutriente Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(NutrienteFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNutriente Controller Begin"));        
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
                    var pagedResult = _serviceNutriente.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var NutrienteDetails = _serviceAlim.Query(
                    //    new NutrienteQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = NutrienteDetails.ToList() };
    
                    //var pagedResult = _serviceNutriente.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterNutriente", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNutriente Controller End"));
                    return PartialView("_NutrienteFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindNutriente Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("NutrienteFindView", new NutrienteFindViewModel(_serviceNutriente, _serviceNt_Cant, _serviceNt_Func, _serviceNt_Grp));
        }
    
        #region Private Methods
    
        //private static QueryObject<Nutriente> GenerateExpression(NutrienteFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(NutrienteFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Nutriente.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Nutriente.Id.Value.ToString() });
                    //And(d => d.Id == model.Nutriente.Id.Value);
                if (model.Nutriente.Codigo.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Codigo", value = model.Nutriente.Codigo.Value.ToString() });
                    //And(d => d.Codigo == model.Nutriente.Codigo.Value);
                if (!string.IsNullOrEmpty(model.Nutriente.Simbolo))
    				filtros.Add(new filterRule() { op = "equal", field = "Simbolo", value = model.Nutriente.Simbolo });				
                    //And(d => d.Simbolo.Contains(model.Nutriente.Simbolo));
                if (!string.IsNullOrEmpty(model.Nutriente.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Nutriente.Nombre });				
                    //And(d => d.Nombre.Contains(model.Nutriente.Nombre));
                if (!string.IsNullOrEmpty(model.Nutriente.Tag))
    				filtros.Add(new filterRule() { op = "equal", field = "Tag", value = model.Nutriente.Tag });				
                    //And(d => d.Tag.Contains(model.Nutriente.Tag));
                if (model.Nutriente.Decimales.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Decimales", value = model.Nutriente.Decimales.Value.ToString() });
                    //And(d => d.Decimales == model.Nutriente.Decimales.Value);
                if (model.Nutriente.IdUniMed.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdUniMed", value = model.Nutriente.IdUniMed.Value.ToString() });
                    //And(d => d.IdUniMed == model.Nutriente.IdUniMed.Value);
                if (model.Nutriente.IdFuncNT.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdFuncNT", value = model.Nutriente.IdFuncNT.Value.ToString() });
                    //And(d => d.IdFuncNT == model.Nutriente.IdFuncNT.Value);
                if (model.Nutriente.IdGrpNT.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdGrpNT", value = model.Nutriente.IdGrpNT.Value.ToString() });
                    //And(d => d.IdGrpNT == model.Nutriente.IdGrpNT.Value);
                if (model.Nutriente.esEsencial.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "esEsencial", value = model.Nutriente.esEsencial.Value.ToString() });
                    //And(d => d.esEsencial == model.Nutriente.esEsencial.Value);
            }
    
    		return filtros;
            //return new QueryObject<Nutriente>(expression ?? (d => true));
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
                //_serviceNutriente.Dispose();
                //_serviceNt_Cant.Dispose();
                //_serviceNt_Func.Dispose();
                //_serviceNt_Grp.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
