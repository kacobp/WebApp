// -----------------------------------------------------------------------
//  <copyright file="IBankingEntityValidator.cs" company="Profile Holdings (Pty) Ltd">
//      Copyright (c) Profile Holdings (Pty) Ltd. All rights reserved.
//  </copyright>
//  <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace Profile.NLayer.Crosscutting.Framework.Validator
{
    #region Using Directives

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    #endregion

    public interface IBankingEntityValidator<in TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Validates the specified item.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        IEnumerable<BankingValidationResult> Validate(ValidationContext context, TEntity item);
    }
}