// -----------------------------------------------------------------------
// <copyright file="AutomapperTypeAdapter.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Adapter
{
    #region Using Directives

    using AutoMapper;

    #endregion

    /// <summary>
    ///     Automapper type adapter implementation
    /// </summary>
    public class AutomapperTypeAdapter : ITypeAdapter
    {

        private readonly IMapper _mapper;
        public AutomapperTypeAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Public Methods and Operators

        /// <summary>
        /// Adapt a source object to an instance of type TTarget
        /// </summary>
        /// <typeparam name="TSource">Type of source item</typeparam>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns>
        ///   <paramref name="source" /> mapped to <typeparamref name="TTarget" />
        /// </returns>
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return _mapper.Map<TSource, TTarget>(source);
        }

        /// <summary>
        /// Adapt a source object to an instnace of type TTarget
        /// </summary>
        /// <typeparam name="TTarget">Type of target item</typeparam>
        /// <param name="source">Instance to adapt</param>
        /// <returns>
        ///   <paramref name="source" /> mapped to <typeparamref name="TTarget" />
        /// </returns>
        public TTarget Adapt<TTarget>(object source) where TTarget : class
        {
            return _mapper.Map<TTarget>(source);
        }

        #endregion
    }
}