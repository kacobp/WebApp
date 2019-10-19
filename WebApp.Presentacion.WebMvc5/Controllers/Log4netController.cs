
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
    
    public partial class Log4netController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly ILog4netAppService _serviceLog4net;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Log4net controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        public Log4netController(ILog4netAppService service)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceLog4net = service;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLog4net Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new Log4netCrudViewModel(_serviceLog4net);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLog4net Controller End"));              
                return View("Log4netAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLog4net Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Log4netCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLog4net Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceLog4net.Insert(model.Log4net, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLog4net Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddLog4net Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Log4netAddView", new Log4netCrudViewModel(_serviceLog4net));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLog4net Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new Log4netCrudViewModel(_serviceLog4net)
                    {
                        Log4net = _serviceLog4net.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLog4net Controller End"));
                return View("Log4netModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLog4net Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(Log4netCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLog4net Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceLog4net.Update(model.Log4net, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLog4net Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyLog4net Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Log4netModifyView", new Log4netCrudViewModel(_serviceLog4net));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLog4net Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new Log4netCrudViewModel(_serviceLog4net)
                    {
                        Log4net = _serviceLog4net.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLog4net Controller End"));
                return View("Log4netRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLog4net Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Log4netCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLog4net Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceLog4net.Delete(model.Log4net, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLog4net Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveLog4net Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("Log4netRemoveView", new Log4netCrudViewModel(_serviceLog4net));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLog4net Controller Begin"));        
                
            try
            {
                // Add find logic here
                Log4netFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterLog4net"))
                {
                    model = (Log4netFindViewModel)TempData.Peek("FilterLog4net");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceLog4net.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceLog4net.FindPagedByFilter(new CustomQuery<Log4net> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedLog4net Controller End"));              
                    return PartialView("_Log4netFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterLog4net");
                    model = new Log4netFindViewModel(_serviceLog4net);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLog4net Controller End"));              
                    return View("Log4netFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLog4net Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(Log4netFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLog4net Controller Begin"));        
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
                    var pagedResult = _serviceLog4net.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var Log4netDetails = _serviceAlim.Query(
                    //    new Log4netQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = Log4netDetails.ToList() };
    
                    //var pagedResult = _serviceLog4net.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterLog4net", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLog4net Controller End"));
                    return PartialView("_Log4netFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindLog4net Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("Log4netFindView", new Log4netFindViewModel(_serviceLog4net));
        }
    
        #region Private Methods
    
        //private static QueryObject<Log4net> GenerateExpression(Log4netFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(Log4netFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Log4net.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Log4net.Id.Value.ToString() });
                    //And(d => d.Id == model.Log4net.Id.Value);
                if (!string.IsNullOrEmpty(model.Log4net.Level))
    				filtros.Add(new filterRule() { op = "equal", field = "Level", value = model.Log4net.Level });				
                    //And(d => d.Level.Contains(model.Log4net.Level));
                if (!string.IsNullOrEmpty(model.Log4net.Logger))
    				filtros.Add(new filterRule() { op = "equal", field = "Logger", value = model.Log4net.Logger });				
                    //And(d => d.Logger.Contains(model.Log4net.Logger));
                if (!string.IsNullOrEmpty(model.Log4net.Host))
    				filtros.Add(new filterRule() { op = "equal", field = "Host", value = model.Log4net.Host });				
                    //And(d => d.Host.Contains(model.Log4net.Host));
                if (model.Log4net.Date.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Date", value = model.Log4net.Date.Value.ToString() });
                    //And(d => d.Date == model.Log4net.Date.Value);
                if (!string.IsNullOrEmpty(model.Log4net.Thread))
    				filtros.Add(new filterRule() { op = "equal", field = "Thread", value = model.Log4net.Thread });				
                    //And(d => d.Thread.Contains(model.Log4net.Thread));
                if (!string.IsNullOrEmpty(model.Log4net.Message))
    				filtros.Add(new filterRule() { op = "equal", field = "Message", value = model.Log4net.Message });				
                    //And(d => d.Message.Contains(model.Log4net.Message));
                if (!string.IsNullOrEmpty(model.Log4net.Exception))
    				filtros.Add(new filterRule() { op = "equal", field = "Exception", value = model.Log4net.Exception });				
                    //And(d => d.Exception.Contains(model.Log4net.Exception));
            }
    
    		return filtros;
            //return new QueryObject<Log4net>(expression ?? (d => true));
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
                //_serviceLog4net.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
