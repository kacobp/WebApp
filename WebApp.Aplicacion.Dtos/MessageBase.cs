// -----------------------------------------------------------------------
// <copyright file="MessageBase.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Aplicacion.Dtos
{
    #region Using Directives

    //using Crosscutting.Framework;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;
    using WebApp.Datos.Core;

    #endregion

    /// <summary>
    ///     Base class for request and response messsages
    /// </summary>
    [DataContract]
    public class MessageBase : Entity
    {
        /// <summary>
        ///     Gets or sets the unique key value which is returned to the caller in the validation result
        ///     to uniquely identify the account to which each result applies
        /// </summary>
        /// <value>
        ///     The unique concurrency key.
        /// </value>
        [Display(AutoGenerateField = false)]
        [DataMember]
        public string CorrelationId { get; set; }
    }
}