﻿// -----------------------------------------------------------------------
// <copyright file="DataAnnotationsEntityValidatorFactory.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Validator
{
    /// <summary>
    ///     Data Annotations based entity validator factory
    /// </summary>
    public class DataAnnotationsEntityValidatorFactory : IEntityValidatorFactory
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Create a entity validator
        /// </summary>
        /// <returns> </returns>
        public IEntityValidator Create()
        {
            return new DataAnnotationsEntityValidator();
        }

        #endregion
    }
}