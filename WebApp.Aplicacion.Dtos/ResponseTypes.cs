// -----------------------------------------------------------------------
// <copyright file="ResponseTypes.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Aplicacion.Dtos
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    ///     An flags enumeration containing the possible bank account validation result types.
    /// </summary>
    [Flags]
    public enum ResponseTypes
    {
        /// <summary>
        ///     Used to clear flags
        /// </summary>
        None = 0,

        /// <summary>
        ///     Success
        /// </summary>
        Success = 1,

        /// <summary>
        ///     Invalid
        /// </summary>
        Invalid = 2,

        /// <summary>
        ///     Includes all validation results
        /// </summary>
        AllResults = Success | Invalid,
    }
}