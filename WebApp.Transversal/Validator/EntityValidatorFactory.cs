// -----------------------------------------------------------------------
// <copyright file="EntityValidatorFactory.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Validator
{
    /// <summary>
    ///     Entity Validator Factory
    /// </summary>
    public static class EntityValidatorFactory
    {
        #region Static Fields

        private static IEntityValidatorFactory _factory;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Createt a new <paramref name="Profile.NLayer.Crosscutting.Logging.ILog" />
        /// </summary>
        /// <returns> Created ILog </returns>
        public static IEntityValidator CreateValidator()
        {
            return (_factory != null) ? _factory.Create() : null;
        }

        /// <summary>
        ///     Set the  log factory to use
        /// </summary>
        /// <param name="factory"> Log factory to use </param>
        public static void SetCurrent(IEntityValidatorFactory factory)
        {
            _factory = factory;
        }

        #endregion
    }
}