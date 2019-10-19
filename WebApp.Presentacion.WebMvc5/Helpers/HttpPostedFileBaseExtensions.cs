
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web;

namespace WebApp.Presentacion.WebMvc5
{
    /// <summary>
    /// HttpPostedFileBase Method Extensions
    /// </summary>
    public static class HttpPostedFileBaseExtensions
    {
        /// <summary>
        /// gets the File name from path.
        /// </summary>
        /// <param name="httpPostedFileBase">The HTTP posted file base.</param>
        /// <returns></returns>
        public static string FileNameFromPath(this HttpPostedFileBase httpPostedFileBase)
        {
            return Path.GetFileName(httpPostedFileBase.FileName);
        }

        /// <summary>
        /// Gets the Memory Stream
        /// </summary>
        /// <param name="httpPostedFileBase">The HTTP posted file base.</param>
        /// <returns></returns>
        public static MemoryStream MemoryStream(this HttpPostedFileBase httpPostedFileBase)
        {
            MemoryStream memoryStream = null;
            using (Stream inputStream = httpPostedFileBase.InputStream)
            {
                memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
            }
            return memoryStream;
        }

        /// <summary>
        /// gets the Binary Content of the specified HTTP posted file base.
        /// </summary>
        /// <param name="httpPostedFileBase">The HTTP posted file base.</param>
        /// <returns></returns>
        public static byte[] Bytes(this HttpPostedFileBase httpPostedFileBase)
        {
            MemoryStream memoryStream = httpPostedFileBase.MemoryStream();
            return memoryStream != null ? memoryStream.ToArray() : new byte[]{};
        }

        /// <summary>
        /// gets the Binary Content of the specified HTTP posted file base.
        /// </summary>
        /// <param name="httpPostedFileBase">The HTTP posted file base.</param>
        /// <returns></returns>
        public static string FileExtension(this HttpPostedFileBase httpPostedFileBase)
        {
            return Path.GetFileName(httpPostedFileBase.FileName);
        }

        /// <summary>
        /// Determines whether the specified HTTP posted file base is image.
        /// </summary>
        /// <param name="httpPostedFileBase">The HTTP posted file base.</param>
        /// <returns>
        /// 	<c>true</c> if the specified HTTP posted file base is image; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsImage(this HttpPostedFileBase httpPostedFileBase)
        {
            if (httpPostedFileBase.ContentType.Contains("image"))
            {
                return true;
            }

            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg", ".bmp" };

            return formats.Any(item => httpPostedFileBase.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}
