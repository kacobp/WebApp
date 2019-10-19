// -----------------------------------------------------------------------
// <copyright file="ITypeAdapter.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Adapter
{
    /// <summary>
    ///     Base contract for map dto to aggregate or aggregate to dto.
    ///     <remarks>
    ///         This is a  contract for work with "auto" mappers ( automapper,emitmapper,valueinjecter...)
    ///         or adhoc mappers
    ///     </remarks>
    /// </summary>
    public interface ITypeAdapter
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Adapt a source object to an instance of type TTarget
        /// </summary>
        /// <typeparam name="TSource"> Type of source item </typeparam>
        /// <typeparam name="TTarget"> Type of target item </typeparam>
        /// <param name="source"> Instance to adapt </param>
        /// <returns> <paramref name="source" /> mapped to <typeparamref name="TTarget" /> </returns>
        TTarget Adapt<TSource, TTarget>(TSource source) where TTarget : class, new() where TSource : class;

        /// <summary>
        ///     Adapt a source object to an instnace of type TTarget
        /// </summary>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns> <paramref name="source" /> mapped to <typeparamref name="TTarget" /> </returns>
        TTarget Adapt<TTarget>(object source) where TTarget : class;

        #endregion
    }
}