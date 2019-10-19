
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
    
    public partial class UserPhotosController : ControllerBase
    {
        #region Fields
            
        private readonly IUnitOfWorkAsync _unitOfWork;
    private readonly IUserPhotosAppService _serviceUserPhotos;
        private readonly IImagenesAppService _serviceImagenes;
        private readonly IUsuarioAppService _serviceUsuario;
    
        #endregion
    
        #region Constructor
    
        /// <summary>
        /// Create a new instance of UserPhotos controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceImagenes">Service dependency</param>
        /// <param name="serviceUsuario">Service dependency</param>
        public UserPhotosController(IUserPhotosAppService service, IImagenesAppService serviceImagenes, IUsuarioAppService serviceUsuario)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceImagenes == null)
                throw new ArgumentNullException("serviceImagenes", PresentationResources.exception_WithoutService);
            if (serviceUsuario == null)
                throw new ArgumentNullException("serviceUsuario", PresentationResources.exception_WithoutService);
    
    		//_unitOfWork = unitOfWork;
            _serviceUserPhotos = service;
            _serviceImagenes = serviceImagenes;
            _serviceUsuario = serviceUsuario;
        }
    
        #endregion
    
        // GET
        public ActionResult Add()
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPhotos Controller Begin"));
                
            try
            {
                // Add add logic here
                var model = new UserPhotosCrudViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario);
    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPhotos Controller End"));              
                return View("UserPhotosAddView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPhotos Controller ERROR"), ex);         
            }
    
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(UserPhotosCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPhotos Controller Begin"));    
    
            try
            {
                // Add add logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUserPhotos.Insert(model.UserPhotos, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPhotos Controller End"));              
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - AddUserPhotos Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UserPhotosAddView", new UserPhotosCrudViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario));
        }
    
        // GET
        public ActionResult Modify(int id)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPhotos Controller Begin"));        
                
            try
            {
                // Add modify logic here
                var model = new UserPhotosCrudViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario)
                    {
                        UserPhotos = _serviceUserPhotos.Find(id)
                    };
                    
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPhotos Controller End"));
                return View("UserPhotosModifyView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPhotos Controller ERROR"), ex);
            }
    
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modify(UserPhotosCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPhotos Controller Begin"));        
    
            try
            {
                // Add modify logic here
                if (ModelState.IsValid)
                {
                    var committed = _serviceUserPhotos.Update(model.UserPhotos, null);
    				_unitOfWork.SaveChanges();
                    if (committed)
                    {
                        //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPhotos Controller End"));
                        return RedirectToAction("Find");
                    }
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - ModifyUserPhotos Controller ERROR"), ex);
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UserPhotosModifyView", new UserPhotosCrudViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario));
        }
    
        // GET
        public ActionResult Remove(int id)
        {    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPhotos Controller Begin"));        
                
            try
            {
                // Add remove logic here
                var model = new UserPhotosCrudViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario)
                    {
                        UserPhotos = _serviceUserPhotos.Find(id)
                    };
                
                //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPhotos Controller End"));
                return View("UserPhotosRemoveView", model);
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPhotos Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Find");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(UserPhotosCrudViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPhotos Controller Begin"));
                
            try
            {
                // Add remove logic here			
                var committed = _serviceUserPhotos.Delete(model.UserPhotos, null);
    			_unitOfWork.SaveChanges();
                if (committed)
                {
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPhotos Controller End"));
                    return RedirectToAction("Find");
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - RemoveUserPhotos Controller ERROR"), ex);          
            }
    
            ModelState.AddModelError("", PresentationResources.Error);
            return View("UserPhotosRemoveView", new UserPhotosCrudViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario));
        }    
    
        // GET
        public ActionResult Find(int? page = 1, string sort = "Id", string sortDir = "ASC")
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPhotos Controller Begin"));        
                
            try
            {
                // Add find logic here
                UserPhotosFindViewModel model;
    
                if (Request.IsAjaxRequest() && TempData.ContainsKey("FilterUserPhotos"))
                {
                    model = (UserPhotosFindViewModel)TempData.Peek("FilterUserPhotos");
                    var filtros = GenerateExpression(model);
                    var pagedResult = _serviceUserPhotos.FindPagedByFilter(filtros, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir, null, null);
                    model.Paginate(pagedResult, "");
    
                    //var pagedResult = _serviceUserPhotos.FindPagedByFilter(new CustomQuery<UserPhotos> { SerializedExpression = model.Filter }, null, page != null ? (int)page : model.PageIndex, model.PageSize, sort, sortDir == "ASC", null);
                    //model.Paginate(pagedResult, model.Filter);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindPagedUserPhotos Controller End"));              
                    return PartialView("_UserPhotosFindPartialView", model);
                }
                else
                {
                    TempData.Remove("FilterUserPhotos");
                    model = new UserPhotosFindViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario);
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPhotos Controller End"));              
                    return View("UserPhotosFindView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPhotos Controller ERROR"), ex);          
            }
                
            return RedirectToAction("Index", "Home");
        }
    
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Find(UserPhotosFindViewModel model)
        {
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPhotos Controller Begin"));        
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
                    var pagedResult = _serviceUserPhotos.FindPagedByFilter(filtros, null, 1, model.PageSize, model.OrderBy, "Asc", null, null);
                    model.Paginate(pagedResult, "");
    
                    //var UserPhotosDetails = _serviceAlim.Query(
                    //    new UserPhotosQuery().Withfilter(filtros))
                    //    .OrderBy(n => n.OrderBy("Id", "Asc"))
                    //    .SelectPage(1, model.PageSize, out totalCount);
                    //var pagelist = new { total = totalCount, rows = UserPhotosDetails.ToList() };
    
                    //var pagedResult = _serviceUserPhotos.FindPagedByFilter(expression, includes, 1, model.PageSize, "Id", model.OrderBy, model.Ascendent, null, null);            
                    //model.Paginate(pagedResult, expression.SerializedExpression);
                    
                    TempData.Clear();
                    TempData.Add("FilterUserPhotos", model);
    
                    //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPhotos Controller End"));
                    return PartialView("_UserPhotosFindPartialView", model);
                }
            }
            catch (Exception ex)
            {
                //LoggerFactory.CreateLog().Error(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindUserPhotos Controller ERROR"), ex);           
            }
    
            ModelState.AddModelError("", PresentationResources.Error);    
            return View("UserPhotosFindView", new UserPhotosFindViewModel(_serviceUserPhotos, _serviceImagenes, _serviceUsuario));
        }
    
        #region Private Methods
    
        //private static QueryObject<UserPhotos> GenerateExpression(UserPhotosFindViewModel model)
        private static IEnumerable<filterRule> GenerateExpression(UserPhotosFindViewModel model)
        {
    
            //LoggerFactory.CreateLog().Debug(string.Format(CultureInfo.InvariantCulture, "Presentation Layer - FindAlim Controller Begin"));        
            //var filters = JsonConvert.DeserializeObject<IEnumerable<filterRule>>(filterRules);
            //return Json(pagelist, JsonRequestBehavior.AllowGet);
            IList<filterRule> filtros = new List<filterRule>();
    
            if (model != null)
            {
                            
                if (model.UserPhotos.Id.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "Id", value = model.UserPhotos.Id.Value.ToString() });
                    //And(d => d.Id == model.UserPhotos.Id.Value);
                if (model.UserPhotos.IdUsuario.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdUsuario", value = model.UserPhotos.IdUsuario.Value.ToString() });
                    //And(d => d.IdUsuario == model.UserPhotos.IdUsuario.Value);
                if (model.UserPhotos.IdImagen.HasValue)
    				filtros.Add(new filterRule() { op = "equal", field = "IdImagen", value = model.UserPhotos.IdImagen.Value.ToString() });
                    //And(d => d.IdImagen == model.UserPhotos.IdImagen.Value);
            }
    
    		return filtros;
            //return new QueryObject<UserPhotos>(expression ?? (d => true));
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
                //_serviceUserPhotos.Dispose();
                //_serviceImagenes.Dispose();
                //_serviceUsuario.Dispose();
            }
            base.Dispose(disposing);
        }
    
        #endregion
    }
}
