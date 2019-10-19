namespace WebApp.Transversales.Collection
{
    using WebApp.Transversales.Collection;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Clase de ayuda de paginación
    /// </summary>
    public static class PageHelper
    {
        #region Methods

        /// <summary>
        /// Convertir a la colección PagedList
        /// </summary>
        /// <typeparam name="T">Genérico</typeparam>
        /// <param name="allItems">IQueryable</param>
        /// <param name="pageIndex">Índice de paginación</param>
        /// <param name="pageSize">Tamaño de paginación</param>
        /// <returns>Colección PagedList</returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
        {

            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            int _itemIndex = (pageIndex - 1) * pageSize;
            List<T> _pageOfItems = allItems.Skip(_itemIndex).Take(pageSize).ToList();
            int _totalItemCount = allItems.Count();
            return new PagedList<T>(_pageOfItems, pageIndex, pageSize, _totalItemCount);
        }

        #endregion Methods
    }
}