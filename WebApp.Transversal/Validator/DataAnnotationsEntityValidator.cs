// -----------------------------------------------------------------------
// <copyright file="DataAnnotationsEntityValidator.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Validator
{
    #region Using Directives

    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    #endregion

    /// <summary>
    ///     Validator based on Data Annotations.
    ///     This validator use IValidatableObject interface and
    ///     ValidationAttribute ( hierachy of this) for
    ///     perform validation
    /// </summary>
    public class DataAnnotationsEntityValidator : IEntityValidator
    {
        #region Public Methods and Operators

        public IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class
        {
            if (item == null)
            {
                return null;
            }

            var validationErrors = new List<string>();

            this.SetValidatableObjectErrors(item, validationErrors);
            this.SetValidationAttributeErrors(item, validationErrors);

            return validationErrors;
        }

        public bool IsValid<TEntity>(TEntity item) where TEntity : class
        {
            if (item == null)
            {
                return false;
            }

            var validationErrors = new List<string>();

            this.SetValidatableObjectErrors(item, validationErrors);
            this.SetValidationAttributeErrors(item, validationErrors);

            return !validationErrors.Any();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Get erros if object implement IValidatableObject
        /// </summary>
        /// <typeparam name="TEntity"> The typeof entity </typeparam>
        /// <param name="item"> The item to validate </param>
        /// <param name="errors"> A collection of current errors </param>
        private void SetValidatableObjectErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
        {
            if (typeof(IValidatableObject).IsAssignableFrom(typeof(TEntity)))
            {
                var validationContext = new ValidationContext(item, null, null);

                var validationResults = ((IValidatableObject) item).Validate(validationContext);

                errors.AddRange(validationResults.Select(vr => vr.ErrorMessage));
            }
        }

        /// <summary>
        ///     Get errors on ValidationAttribute
        /// </summary>
        /// <typeparam name="TEntity"> The type of entity </typeparam>
        /// <param name="item"> The entity to validate </param>
        /// <param name="errors"> A collection of current errors </param>
        private void SetValidationAttributeErrors<TEntity>(TEntity item, List<string> errors) where TEntity : class
        {
            var result = from property in TypeDescriptor.GetProperties(item).Cast<PropertyDescriptor>()
                from attribute in property.Attributes.OfType<ValidationAttribute>()
                where !attribute.IsValid(property.GetValue(item))
                select attribute.FormatErrorMessage(string.Empty);

            var resultList = result.ToList();
            if (resultList.Any())
            {
                errors.AddRange(resultList);
            }
        }

        #endregion
    }
}