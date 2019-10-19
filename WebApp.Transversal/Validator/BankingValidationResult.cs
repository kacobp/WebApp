// -----------------------------------------------------------------------
//  <copyright file="BankingValidationResult.cs" company="Profile Holdings (Pty) Ltd">
//      Copyright (c) Profile Holdings (Pty) Ltd. All rights reserved.
//  </copyright>
//  <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace Profile.NLayer.Crosscutting.Framework.Validator
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// Banking validation result item
    /// </summary>
    [DataContract]
    [KnownType(typeof(BankingValidationResultTypes))]
    public class BankingValidationResult
    {
        private readonly IEnumerable<string> _memberNames;
        private string _errorMessage;
        private BankingValidationResultTypes _resultType = BankingValidationResultTypes.Invalid;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingValidationResult" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="errorMessage">The error message.</param>
        public BankingValidationResult(ValidationContext context, string errorMessage)
            : this(context, errorMessage, BankingValidationResultTypes.Invalid)
        {
        }

        public BankingValidationResult(ValidationContext context, ValidationResult validationResult)
            : this(context, validationResult.ErrorMessage, BankingValidationResultTypes.Invalid, validationResult.MemberNames.ToArray())
        {
            Contract.Requires(validationResult != null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingValidationResult" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="validationResult">The validation result object.</param>
        public BankingValidationResult(ValidationContext context, BankingValidationResult validationResult)
            : this(context, validationResult.ErrorMessage, validationResult.ResultType, validationResult.MemberNames.ToArray())
        {
            Contract.Requires(validationResult != null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BankingValidationResult" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="resultType">Type of the result.</param>
        /// <param name="memberNames">The list of member names that have validation errors.</param>
        public BankingValidationResult(ValidationContext context, string errorMessage, BankingValidationResultTypes resultType, params string[] memberNames)
        {
            this.ObjectType = context.ObjectType;
            this._errorMessage = errorMessage;
            this._resultType = resultType;
            this._memberNames = memberNames;
        }

        /// <summary>
        /// Gets or sets the type of the result.
        /// </summary>
        /// <value>
        /// The type of the result.
        /// </value>
        [DataMember]
        public BankingValidationResultTypes ResultType
        {
            get { return this._resultType; }
            set
            {
                if (!Equals(this._resultType, value))
                    this._resultType = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the entity class.
        /// </summary>
        /// <value>
        /// The name of the class.
        /// </value>
        [DataMember]
        public Type ObjectType { get; set; }

        /// <summary>
        /// Gets the collection of member names that indicate which fields have validation errors.
        /// </summary>
        /// <returns>The collection of member names that indicate which fields have validation errors.</returns>
        [DataMember]
        public IEnumerable<string> MemberNames
        {
            get { return this._memberNames; }
        }

        /// <summary>
        /// Gets the error message for the validation.
        /// </summary>
        /// <returns>The error message for the validation.</returns>
        [DataMember]
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }

        #region Methods

        /// <summary>
        /// Override the string representation of this instance, returning
        /// the <see cref="ErrorMessage"/> if not <c>null</c>, otherwise
        /// the base <see cref="Object.ToString"/> result.
        /// </summary>
        /// <remarks>
        /// If the <see cref="ErrorMessage"/> is empty, it will still qualify
        /// as being specified, and therefore returned from <see cref="ToString"/>.
        /// </remarks>
        /// <returns>The <see cref="ErrorMessage"/> property value if specified,
        /// otherwise, the base <see cref="Object.ToString"/> result.</returns>
        public override string ToString()
        {
            return this.ErrorMessage ?? base.ToString();
        }

        /// <summary>
        /// Gets or sets a demited list of member names.
        /// </summary>
        /// <value>
        /// The members string.
        /// </value>
        public string GetMemberNames()
        {
            return this.GetMemberNames(", ");
        }

        /// <summary>
        /// Gets or sets a demited list of member names.
        /// </summary>
        /// <value>
        /// The members string.
        /// </value>
        public string GetMemberNames(string delimiter)
        {
            return string.Join(delimiter, this.MemberNames);
        }

        #endregion Methods
    }
}