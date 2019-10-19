namespace WebApp.Transversales.Collection
{
    //using Operator;

    /// <summary>
    /// Colección Json para el transporte JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonPagedList<T>
        where T : class
    {
        #region Fields

        /// <summary>
        /// Datos de recogida de paginación
        /// </summary>
        public readonly PagedList<T> PagedList;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pagedList">PagedList</param>
        public JsonPagedList(PagedList<T> pagedList)
        {
            //ValidateOperator.Begin().NotNull(pagedList, "分页数据集合");
            PagedList = pagedList;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Índice de la página actual
        /// </summary>
        public int CurrentPageIndex
        {
            get
            {
                return PagedList.CurrentPageIndex;
            }
        }

        /// <summary>
        /// Tamaño de paginación
        /// </summary>
        public int PageSize
        {
            get
            {
                return PagedList.PageSize;
            }
        }

        /// <summary>
        /// Número total de registros
        /// </summary>
        public int TotalItemCount
        {
            get
            {
                return PagedList.TotalItemCount;
            }
        }

        /// <summary>
        /// Número total de páginas
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                return PagedList.TotalPageCount;
            }
        }
        
        #endregion Properties
    }
}