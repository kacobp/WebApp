
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
    
    public partial class AlimController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IAlimAppService _serviceAlim;
        private readonly IFactConvAppService _serviceFactConv;
        private readonly INt_CantAppService _serviceNt_Cant;
        private readonly IAlim_GrpAppService _serviceAlim_Grp;
        private readonly IAlim_FuenteAppService _serviceAlim_Fuente;
        private readonly IUniMedAppService _serviceUniMed;
        private readonly IRecProdAppService _serviceRecProd;
        private readonly IDesCantAppService _serviceDesCant;
        private readonly IRendCantAppService _serviceRendCant;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of Alim controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceFactConv">Service dependency</param>
        /// <param name="serviceNt_Cant">Service dependency</param>
        /// <param name="serviceAlim_Grp">Service dependency</param>
        /// <param name="serviceAlim_Fuente">Service dependency</param>
        /// <param name="serviceUniMed">Service dependency</param>
        /// <param name="serviceRecProd">Service dependency</param>
        /// <param name="serviceDesCant">Service dependency</param>
        /// <param name="serviceRendCant">Service dependency</param>
        public AlimController(IAlimAppService service, IFactConvAppService serviceFactConv, INt_CantAppService serviceNt_Cant, IAlim_GrpAppService serviceAlim_Grp, IAlim_FuenteAppService serviceAlim_Fuente, IUniMedAppService serviceUniMed, IRecProdAppService serviceRecProd, IDesCantAppService serviceDesCant, IRendCantAppService serviceRendCant)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceFactConv == null)
                throw new ArgumentNullException("serviceFactConv", PresentationResources.exception_WithoutService);
            if (serviceNt_Cant == null)
                throw new ArgumentNullException("serviceNt_Cant", PresentationResources.exception_WithoutService);
            if (serviceAlim_Grp == null)
                throw new ArgumentNullException("serviceAlim_Grp", PresentationResources.exception_WithoutService);
            if (serviceAlim_Fuente == null)
                throw new ArgumentNullException("serviceAlim_Fuente", PresentationResources.exception_WithoutService);
            if (serviceUniMed == null)
                throw new ArgumentNullException("serviceUniMed", PresentationResources.exception_WithoutService);
            if (serviceRecProd == null)
                throw new ArgumentNullException("serviceRecProd", PresentationResources.exception_WithoutService);
            if (serviceDesCant == null)
                throw new ArgumentNullException("serviceDesCant", PresentationResources.exception_WithoutService);
            if (serviceRendCant == null)
                throw new ArgumentNullException("serviceRendCant", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceAlim = service;
            _serviceFactConv = serviceFactConv;
            _serviceNt_Cant = serviceNt_Cant;
            _serviceAlim_Grp = serviceAlim_Grp;
            _serviceAlim_Fuente = serviceAlim_Fuente;
            _serviceUniMed = serviceUniMed;
            _serviceRecProd = serviceRecProd;
            _serviceDesCant = serviceDesCant;
            _serviceRendCant = serviceRendCant;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new AlimCrudViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim Controller End"));              
                return View("AlimAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AlimCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceAlim.Insert(model.Alim, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddAlim Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("AlimAddView", new AlimCrudViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new AlimCrudViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant)
                    {
                        Alim = _serviceAlim.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim Controller End"));
                return View("AlimModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(AlimCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceAlim.Update(model.Alim, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyAlim Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("AlimModifyView", new AlimCrudViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new AlimCrudViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant)
                    {
                        Alim = _serviceAlim.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim Controller End"));
                return View("AlimRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(AlimCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceAlim.Delete(model.Alim, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveAlim Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("AlimRemoveView", new AlimCrudViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
                
            try
            {
                // Add find logic here
                AlimFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterAlim"))
                {
                    model = (AlimFindViewModel)TempData.Peek("FilterAlim");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceAlim.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceAlim.FindPagedByFilter(new CustomQuery<Alim> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedAlim Controller End"));              
                    return PartialView("_AlimFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterAlim");
                    model = new AlimFindViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller End"));              
                    return View("AlimFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(AlimFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
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
                    var pagedResult = _serviceAlim.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var AlimDetails = _serviceAlim.Query(
                    //    new AlimQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = AlimDetails.ToList() };
    
                    //var pagedResult = _serviceAlim.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterAlim", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller End"));
                    return PartialView("_AlimFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("AlimFindView", new AlimFindViewModel(_serviceAlim, _serviceFactConv, _serviceNt_Cant, _serviceAlim_Grp, _serviceAlim_Fuente, _serviceUniMed, _serviceRecProd, _serviceDesCant, _serviceRendCant));
        }
    
        #region Private Methods
    
        //private static QueryObject<Alim> GenerateExpression(AlimFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(AlimFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.Alim.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.Alim.Id.Value.ToString() });
                    //And(d => d.Id == model.Alim.Id.Value);
                if (!string.IsNullOrEmpty(model.Alim.Nombre))
    				filtros.Add(new filterRule() { op = "equal", field = "Nombre", value = model.Alim.Nombre });				
                    //And(d => d.Nombre.Contains(model.Alim.Nombre));
                if (model.Alim.IdEstado.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdEstado", value = model.Alim.IdEstado.Value.ToString() });
                    //And(d => d.IdEstado == model.Alim.IdEstado.Value);
                if (model.Alim.FactorRendimiento.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FactorRendimiento", value = model.Alim.FactorRendimiento.Value.ToString() });
                    //And(d => d.FactorRendimiento == model.Alim.FactorRendimiento.Value);
                if (model.Alim.FactorDescuento.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FactorDescuento", value = model.Alim.FactorDescuento.Value.ToString() });
                    //And(d => d.FactorDescuento == model.Alim.FactorDescuento.Value);
                if (model.Alim.Fraccionado.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Fraccionado", value = model.Alim.Fraccionado.Value.ToString() });
                    //And(d => d.Fraccionado == model.Alim.Fraccionado.Value);
                if (model.Alim.ConversionInyectado.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "ConversionInyectado", value = model.Alim.ConversionInyectado.Value.ToString() });
                    //And(d => d.ConversionInyectado == model.Alim.ConversionInyectado.Value);
                if (model.Alim.FactorConversion.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FactorConversion", value = model.Alim.FactorConversion.Value.ToString() });
                    //And(d => d.FactorConversion == model.Alim.FactorConversion.Value);
                if (model.Alim.Inactivo.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Inactivo", value = model.Alim.Inactivo.Value.ToString() });
                    //And(d => d.Inactivo == model.Alim.Inactivo.Value);
                if (!string.IsNullOrEmpty(model.Alim.NomAbreviado))
    				filtros.Add(new filterRule() { op = "equal", field = "NomAbreviado", value = model.Alim.NomAbreviado });				
                    //And(d => d.NomAbreviado.Contains(model.Alim.NomAbreviado));
                if (!string.IsNullOrEmpty(model.Alim.NomCientifico))
    				filtros.Add(new filterRule() { op = "equal", field = "NomCientifico", value = model.Alim.NomCientifico });				
                    //And(d => d.NomCientifico.Contains(model.Alim.NomCientifico));
                if (model.Alim.esAlimento.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "esAlimento", value = model.Alim.esAlimento.Value.ToString() });
                    //And(d => d.esAlimento == model.Alim.esAlimento.Value);
                if (model.Alim.NT_MedidaBase.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "NT_MedidaBase", value = model.Alim.NT_MedidaBase.Value.ToString() });
                    //And(d => d.NT_MedidaBase == model.Alim.NT_MedidaBase.Value);
                if (model.Alim.IdUniMed.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdUniMed", value = model.Alim.IdUniMed.Value.ToString() });
                    //And(d => d.IdUniMed == model.Alim.IdUniMed.Value);
                if (model.Alim.IdAlimGrp.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdAlimGrp", value = model.Alim.IdAlimGrp.Value.ToString() });
                    //And(d => d.IdAlimGrp == model.Alim.IdAlimGrp.Value);
                if (model.Alim.IdAlimFte.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdAlimFte", value = model.Alim.IdAlimFte.Value.ToString() });
                    //And(d => d.IdAlimFte == model.Alim.IdAlimFte.Value);
                if (model.Alim.FechaRegistro.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "FechaRegistro", value = model.Alim.FechaRegistro.Value.ToString() });
                    //And(d => d.FechaRegistro == model.Alim.FechaRegistro.Value);
            }
    
    		return filtros;
            //return new QueryObject<Alim>(expression ?? (d => true));
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
                //_serviceAlim.Dispose();
                //_serviceFactConv.Dispose();
                //_serviceNt_Cant.Dispose();
                //_serviceAlim_Grp.Dispose();
                //_serviceAlim_Fuente.Dispose();
                //_serviceUniMed.Dispose();
                //_serviceRecProd.Dispose();
                //_serviceDesCant.Dispose();
                //_serviceRendCant.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
