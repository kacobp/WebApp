// -----------------------------------------------------------------------
// <copyright file="IEntityValidator.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Validator
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     The entity validator generic base contract
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IEntityValidator<in TEntity> : IEntityValidator
        where TEntity : class
    {
        IEnumerable<String> GetInvalidMessages(TEntity item);
        bool IsValid(TEntity item);
    }

    /// <summary>
    ///     The entity validator base contract
    /// </summary>
    public interface IEntityValidator
    {
        /// <summary>
        ///     Return the collection of errors if entity state is not valid
        /// </summary>
        /// <typeparam name="TEntity"> The type of entity </typeparam>
        /// <param name="item"> The instance with validation errors </param>
        /// <returns> A collection of validation errors </returns>
        IEnumerable<String> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class;

        /// <summary>
        ///     Perform validation and return if the entity state is valid
        /// </summary>
        /// <typeparam name="TEntity"> The type of entity to validate </typeparam>
        /// <param name="item"> The instance to validate </param>
        /// <returns> True if entity state is valid </returns>
        bool IsValid<TEntity>(TEntity item) where TEntity : class;
    }
}