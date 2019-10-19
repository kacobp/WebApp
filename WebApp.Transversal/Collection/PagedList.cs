namespace WebApp.Transversales.Collection
{
    using Interfaces;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// La recopilación de datos de paginación para los backends
    /// para devolver las colecciones paginadas y los 
    /// enlaces de control de paginación de la vista de frontend
    /// </summary>
    /// <typeparam name="T">Genérico</typeparam>
    public class PagedList<T> : List<T>, IPagedList
    {
        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">Coleccion</param>
        /// <param name="pageIndex">Índice de la página actual</param>
        /// <param name="pageSize">Número total de páginas</param>
        public PagedList(IList<T> items, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            TotalItemCount = items.Count;
            CurrentPageIndex = pageIndex;

            for(int i = StartRecordIndex - 1; i < EndRecordIndex; i++)
            {
                Add(items[i]);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">Coleccion</param>
        /// <param name="pageIndex">Índice de la página actual</param>
        /// <param name="pageSize">Número total de páginas</param>
        /// <param name="totalItemCount">Número de registros</param>
        public PagedList(IEnumerable<T> items, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(items);
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Índice de la página actual
        /// </summary>
        public int CurrentPageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Índice final de registro
        /// </summary>
        public int EndRecordIndex
        {
            get
            {
                return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount;
            }
        }

        /// <summary>
        /// Gets or sets the extra count.
        /// </summary>
        public int ExtraCount
        {
            get;
            set;
        }

        /// <summary>
        /// Tamaño de paginación
        /// </summary>
        public int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Índice de inicio de datos
        /// </summary>
        public int StartRecordIndex
        {
            get
            {
                return (CurrentPageIndex - 1) * PageSize + 1;
            }
        }

        /// <summary>
        /// Número total de registros
        /// </summary>
        public int TotalItemCount
        {
            get;
            set;
        }

        /// <summary>
        /// Número total de páginas
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                return (int)Math.Ceiling(TotalItemCount / (double)PageSize);
            }
        }

        #endregion Properties
    }
}