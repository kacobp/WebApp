// -----------------------------------------------------------------------
// <copyright file="IEntityValidatorFactory.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Validator
{
    /// <summary>
    ///     Base contract for entity validator abstract factory
    /// </summary>
    public interface IEntityValidatorFactory
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Create a new IEntityValidator
        /// </summary>
        /// <returns> IEntityValidator </returns>
        IEntityValidator Create();

        #endregion
    }
}