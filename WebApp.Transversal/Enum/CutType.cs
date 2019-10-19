namespace WebApp.Transversales.Enum
{
    #region Enumerations

    /// <summary>
    /// Método de recorte de imagen
    /// </summary>
    public enum CutType
    {
        /// <summary>
        /// Cortar según altura y ancho
        /// </summary>
        CutWH = 1,

        /// <summary>
        /// Según amplia cizalla
        /// </summary>
        CutW = 2,

        /// <summary>
        /// Según el alto cizallamiento
        /// </summary>
        CutH = 3,

        /// <summary>
        /// El zoom no se recorta
        /// </summary>
        CutNo = 4
    }

    #endregion Enumerations
}