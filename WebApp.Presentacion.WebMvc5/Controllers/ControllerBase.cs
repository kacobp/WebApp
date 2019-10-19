// -----------------------------------------------------------------------
// <copyright file="ControllerBase.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Presentacion.WebMvc5.Controllers
{
    #region Using Directives

    using System;
    using System.Text;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// Base MVC Controller class
    /// </summary>
    public abstract class ControllerBase : Controller
    {
        /// <summary>
        /// Content Type constants
        /// </summary>
        public static class ContentType
        {
            /// <summary>
            /// Application constants
            /// </summary>
            public static class Application
            {
                /// <summary>
                /// The json
                /// </summary>
                public const string Json = "application/json";
            }
        }

        #region Override Methods

        /// <summary>
        /// Creates a <see cref="T:System.Web.Mvc.JsonResult" /> object that serializes the specified object to JavaScript Object Notation (JSON) format using the content type, content encoding, and the JSON request behavior.
        /// </summary>
        /// <param name="data">The JavaScript object graph to serialize.</param>
        /// <param name="contentType">The content type (MIME type).</param>
        /// <param name="contentEncoding">The content encoding.</param>
        /// <param name="behavior">The JSON request behavior</param>
        /// <returns>
        /// The result object that serializes the specified object to JSON format.
        /// </returns>
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            var result = base.Json(data, contentType, contentEncoding, behavior);
            result.MaxJsonLength = Int32.MaxValue;
            return result;
        }

        #endregion
    }
}