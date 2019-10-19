//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;

//using WebApp.Aplicacion.Dtos;
using WebApp.Aplicacion.AppServices;
using WebApp.Datos.Core;
using WebApp.Datos.Repository;
using WebApp.Dominio.Entidades;
using WebApp.Presentacion.WebMvc5.Models;
using WebApp.Transversales.Caching;
using WebApp.Transversales.Extensions;
using WebApp.Transversales.Utilities.Encryptor;
using WebApp.Presentacion.WebMvc5.Resources;
using WebApp.Presentacion.WebMvc5.ViewModels;
using System.Linq;

using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System;
using System.Security.Cryptography;
using WebApp.Dominio.Core.UnitOfWork;
using System.Collections.Generic;
using System.Collections;

namespace WebApp.Presentacion.WebMvc5.Controllers
{
    [Authorize]
    public class AccountController : ControllerBase
    {
        //private ApplicationUserManager _userManager;
        #region Fields

        private readonly IUsuarioAppService _serviceUsuario;
        private readonly ILoginAttemptsAppService _serviceLoginAttempts;
        private readonly IPermisosUsuarioAppService _servicePermisosUsuario;
        private readonly IUserPasswordsAppService _serviceUserPasswords;
        private readonly IUserPhotosAppService _serviceUserPhotos;
        private readonly IPasswordAppService _servicePassword;
        private readonly IUnitOfWorkAsync _unitOfWork;
        private DESEncryptor desHelper = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of Usuario controller
        /// </summary>
        /// <param name="service">Service dependency</param>
        /// <param name="serviceLoginAttempts">Service dependency</param>
        /// <param name="servicePermisosUsuario">Service dependency</param>
        /// <param name="serviceUserPasswords">Service dependency</param>
        /// <param name="serviceUserPhotos">Service dependency</param>
        public AccountController(IUsuarioAppService service, ILoginAttemptsAppService serviceLoginAttempts, IPermisosUsuarioAppService servicePermisosUsuario, IUserPasswordsAppService serviceUserPasswords, IUserPhotosAppService serviceUserPhotos, IPasswordAppService servicePassword, IUnitOfWorkAsync unitOfWork)
        {
            if (service == null)
                throw new ArgumentNullException("service", PresentationResources.exception_WithoutService);
            if (serviceLoginAttempts == null)
                throw new ArgumentNullException("serviceLoginAttempts", PresentationResources.exception_WithoutService);
            if (servicePermisosUsuario == null)
                throw new ArgumentNullException("servicePermisosUsuario", PresentationResources.exception_WithoutService);
            if (serviceUserPasswords == null)
                throw new ArgumentNullException("serviceUserPasswords", PresentationResources.exception_WithoutService);
            if (serviceUserPhotos == null)
                throw new ArgumentNullException("serviceUserPhotos", PresentationResources.exception_WithoutService);

            _serviceUsuario = service;
            _serviceLoginAttempts = serviceLoginAttempts;
            _servicePermisosUsuario = servicePermisosUsuario;
            _serviceUserPasswords = serviceUserPasswords;
            _serviceUserPhotos = serviceUserPhotos;
            _servicePassword = servicePassword;
            _unitOfWork = unitOfWork;
            DES _newDes = DESEncryptor.CreateDES("WebApp.AppServices");
            _newDes.IV = new byte[8] { 0x01, 0x02, 0x03, 0x4, 0x05, 0x06, 0x07, 0x08 };
            desHelper = new DESEncryptor(_newDes.Key, _newDes.IV);

        }

        #endregion
        //public AccountController(ApplicationUserManager userManager)
        //{
        //    UserManager = userManager;
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}









        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            Usuario oUser = new Usuario();
            Password oPass = new Password();

            if (ModelState.IsValid)
            {
                 //var lstPass = _serviceUserPasswords.Queryable();
                 oUser = _serviceUsuario.Queryable().Where(u => u.AccountName == model.Email).FirstOrDefault();

                string _srtEncrypt = desHelper.EncryptString(model.Password);
                //string _strDecrypt = desHelper.DecryptString("39S4D8vXqfk=");
                oPass = _servicePassword.Queryable().Where(p => p.PasswordHash == _srtEncrypt).FirstOrDefault();

                var lstUserPass = _serviceUserPasswords
                              .Queryable()
                              .Where(p => p.IdUsuario == oUser.Id)
                              .Where(p => p.IdPassword == oPass.Id)
                              .FirstOrDefault();

                var lst = _serviceUsuario
                    .Queryable()
                    .Where(u => u.AccountName == model.Email)
                    .Select(u => u.UserPasswords.Where(p => p.Password.PasswordHash == _srtEncrypt))
                    .FirstOrDefault();


                if (lstUserPass != null)
                {
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }

                //return RedirectToLocal(returnUrl);
                //var user = await _serviceUsuario.FindAsync(model.Email, model.Password);
                //if (user != null)
                //{
                //    //await SignInAsync(user, model.RememberMe);
                //    return RedirectToLocal(returnUrl);
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Invalid username or password.");
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        public ActionResult Register(RegisterViewModel model)
        {
            bool committed;

            if (ModelState.IsValid)
            {
                Usuario oUser = new Usuario();
                UserPasswords oUserPass = new UserPasswords();
                IList<UserPasswords> lstUserPass = new List<UserPasswords>();
                Password oPass = new Password();

                //Usuario
                //Password
                //string _srtEncrypt = desHelper.EncryptString(model.Password);
                //string _strDecrypt = desHelper.DecryptString("39S4D8vXqfk=");
                //oPass.PasswordHash = _srtEncrypt;
                //lstPass.Add(oPass);

                //Passwords de Usuario
                oPass.Password1 = model.Password;
                oUserPass.Password = oPass;
                lstUserPass.Add(oUserPass);

                //Usuario
                oUser.AccountName = model.Email;
                oUser.UserPasswords = lstUserPass;
                committed = _serviceUsuario.Insert(oUser, null);
                if (committed)
                {
                    return RedirectToAction("Index", "Home");
                }

                //_servicePassword.Insert(oPass, null);
                //committed = _serviceUserPasswords.Insert(oUserPass, null);
                //_unitOfWork.SaveChanges();

                //return RedirectToAction("Index", "Home");

                //if (committed)
                //{
                //    if (committed)
                //    {
                //    }

                //}

                //var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
                //IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                //    //await SignInAsync(user, isPersistent: false);

                //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //    // Send an email with this link
                //    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                //    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                //    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    //AddErrors(result);
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        ////
        //// GET: /Account/ConfirmEmail
        //[AllowAnonymous]
        //public async Task<ActionResult> ConfirmEmail(string userId, string code)
        //{
        //    if (userId == null || code == null)
        //    {
        //        return View("Error");
        //    }

        //    IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);
        //    if (result.Succeeded)
        //    {
        //        return View("ConfirmEmail");
        //    }
        //    else
        //    {
        //        AddErrors(result);
        //        return View();
        //    }
        //}

        ////
        //// GET: /Account/ForgotPassword
        //[AllowAnonymous]
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/ForgotPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.FindByNameAsync(model.Email);
        //        if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
        //        {
        //            ModelState.AddModelError("", "The user either does not exist or is not confirmed.");
        //            return View();
        //        }

        //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //        // Send an email with this link
        //        // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        //        // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //        // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        //        // return RedirectToAction("ForgotPasswordConfirmation", "Account");
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/ForgotPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ForgotPasswordConfirmation()
        //{
        //    return View();
        //}

        ////
        //// GET: /Account/ResetPassword
        //[AllowAnonymous]
        //public ActionResult ResetPassword(string code)
        //{
        //    if (code == null)
        //    {
        //        return View("Error");
        //    }
        //    return View();
        //}

        ////
        //// POST: /Account/ResetPassword
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await UserManager.FindByNameAsync(model.Email);
        //        if (user == null)
        //        {
        //            ModelState.AddModelError("", "No user found.");
        //            return View();
        //        }
        //        IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("ResetPasswordConfirmation", "Account");
        //        }
        //        else
        //        {
        //            AddErrors(result);
        //            return View();
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// GET: /Account/ResetPasswordConfirmation
        //[AllowAnonymous]
        //public ActionResult ResetPasswordConfirmation()
        //{
        //    return View();
        //}

        ////
        //// POST: /Account/Disassociate
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Disassociate(string loginProvider, string providerKey)
        //{
        //    ManageMessageId? message = null;
        //    IdentityResult result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
        //    if (result.Succeeded)
        //    {
        //        var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //        await SignInAsync(user, isPersistent: false);
        //        message = ManageMessageId.RemoveLoginSuccess;
        //    }
        //    else
        //    {
        //        message = ManageMessageId.Error;
        //    }
        //    return RedirectToAction("Manage", new { Message = message });
        //}

        ////
        //// GET: /Account/Manage
        //public ActionResult Manage(ManageMessageId? message)
        //{
        //    ViewBag.StatusMessage =
        //        message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
        //        : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
        //        : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
        //        : message == ManageMessageId.Error ? "An error has occurred."
        //        : "";
        //    ViewBag.HasLocalPassword = HasPassword();
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    return View();
        //}

        ////
        //// POST: /Account/Manage
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Manage(ManageUserViewModel model)
        //{
        //    bool hasPassword = HasPassword();
        //    ViewBag.HasLocalPassword = hasPassword;
        //    ViewBag.ReturnUrl = Url.Action("Manage");
        //    if (hasPassword)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
        //                await SignInAsync(user, isPersistent: false);
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        // User does not have a password so remove any validation errors caused by a missing OldPassword field
        //        ModelState state = ModelState["OldPassword"];
        //        if (state != null)
        //        {
        //            state.Errors.Clear();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
        //            }
        //            else
        //            {
        //                AddErrors(result);
        //            }
        //        }
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        ////
        //// POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    // Request a redirect to the external login provider
        //    return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}

        ////
        //// GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    // Sign in the user with this external login provider if the user already has a login
        //    var user = await UserManager.FindAsync(loginInfo.Login);
        //    if (user != null)
        //    {
        //        await SignInAsync(user, isPersistent: false);
        //        return RedirectToLocal(returnUrl);
        //    }
        //    else
        //    {
        //        // If the user does not have an account, then prompt the user to create an account
        //        ViewBag.ReturnUrl = returnUrl;
        //        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
        //        return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        //    }
        //}

        ////
        //// POST: /Account/LinkLogin
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LinkLogin(string provider)
        //{
        //    // Request a redirect to the external login provider to link a login for the current user
        //    return new ChallengeResult(provider, Url.Action("LinkLoginCallback", "Account"), User.Identity.GetUserId());
        //}

        ////
        //// GET: /Account/LinkLoginCallback
        //public async Task<ActionResult> LinkLoginCallback()
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        //    }
        //    IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
        //    if (result.Succeeded)
        //    {
        //        return RedirectToAction("Manage");
        //    }
        //    return RedirectToAction("Manage", new { Message = ManageMessageId.Error });
        //}

        ////
        //// POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Manage");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            return View("ExternalLoginFailure");
        //        }
        //        var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
        //        IdentityResult result = await UserManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //            if (result.Succeeded)
        //            {
        //                await SignInAsync(user, isPersistent: false);

        //                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //                // Send an email with this link
        //                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //                // SendEmail(user.Email, callbackUrl, "Confirm your account", "Please confirm your account by clicking this link");

        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        //
        // POST: /Account/LogOff
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut();
        //    return RedirectToAction("Index", "Home");
        //}

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        //[ChildActionOnly]
        //public ActionResult RemoveAccountList()
        //{
        //    var linkedAccounts = UserManager.GetLogins(User.Identity.GetUserId());
        //    ViewBag.ShowRemoveButton = HasPassword() || linkedAccounts.Count > 1;
        //    return (ActionResult)PartialView("_RemoveAccountPartial", linkedAccounts);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && UserManager != null)
        //    {
        //        UserManager.Dispose();
        //        UserManager = null;
        //    }
        //    base.Dispose(disposing);
        //}

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get
        //    {
        //        return HttpContext.GetOwinContext().Authentication;
        //    }
        //}

        //private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        //}

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError("", error);
        //    }
        //}

        //private bool HasPassword()
        //{
        //    var user = UserManager.FindById(User.Identity.GetUserId());
        //    if (user != null)
        //    {
        //        return user.PasswordHash != null;
        //    }
        //    return false;
        //}

        private void SendEmail(string email, string callbackUrl, string subject, string message)
        {
            // For information on sending mail, please visit http://go.microsoft.com/fwlink/?LinkID=320771
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }

            public string RedirectUri { get; set; }

            public string UserId { get; set; }

            //public override void ExecuteResult(ControllerContext context)
            //{
            //    var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
            //    if (UserId != null)
            //    {
            //        properties.Dictionary[XsrfKey] = UserId;
            //    }
            //    context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            //}
        }

        #endregion Helpers
    }
}