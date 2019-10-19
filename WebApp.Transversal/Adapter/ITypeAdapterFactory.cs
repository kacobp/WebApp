// -----------------------------------------------------------------------
// <copyright file="ITypeAdapterFactory.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Adapter
{
    /// <summary>
    ///     Base contract for adapter factory
    /// </summary>
    public interface ITypeAdapterFactory
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Create a type adater
        /// </summary>
        /// <returns>The created ITypeAdapter</returns>
        ITypeAdapter Create();

        #endregion
    }
}