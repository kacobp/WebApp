// -----------------------------------------------------------------------
// <copyright file="TypeAdapterFactory.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Adapter
{
    public class TypeAdapterFactory
    {
        #region Static Fields

        private static ITypeAdapterFactory _currentTypeAdapterFactory;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Create a new type adapter from currect factory
        /// </summary>
        /// <returns>Created type adapter</returns>
        public static ITypeAdapter CreateAdapter()
        {
            return _currentTypeAdapterFactory.Create();
        }

        /// <summary>
        ///     Set the current type adapter factory
        /// </summary>
        /// <param name="adapterFactory">The adapter factory to set</param>
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            _currentTypeAdapterFactory = adapterFactory;
        }

        #endregion
    }
}