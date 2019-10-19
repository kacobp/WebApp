namespace WebApp.Transversales.Interfaces
{
    /// <summary>
    /// Interfaz de colección de paginación
    /// </summary>
    public interface IPagedList
    {
        #region Properties

        /// <summary>
        /// Índice de la página actual
        /// </summary>
        int CurrentPageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Tamaño de paginación
        /// </summary>
        int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Número total de registros
        /// </summary>
        int TotalItemCount
        {
            get;
            set;
        }

        #endregion Properties
    }
}