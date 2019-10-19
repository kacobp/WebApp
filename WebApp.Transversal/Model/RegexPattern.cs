namespace WebApp.Transversales.Model
{
    /// <summary>
    /// Expresión regular
    /// </summary>
    public class RegexPattern
    {
        #region Fields

        /// <summary>
        /// Base64 detecta expresiones regulares
        /// </summary>
        public const string Base64Check = "^[A-Z0-9/+=]*$";

        /// <summary>
        /// Verifique el código Bcd, por ejemplo, "01" o "3456"
        /// </summary>
        public const string BinaryCodedDecimal = @"^([0-9]{2})+$";

        /// <summary>
        /// Detección de formato de matrícula de expresión regular
        /// </summary>
        public const string CarLicenseCheck = @"^([\u4e00-\u9fa5]|[A-Z]){1,2}[A-Za-z0-9]{1,2}-[0-9A-Za-z]{5}$";
        
        /// <summary>
        /// Detección de formato de fecha expresión regular
        /// </summary>
        public const string DateCheck = @"\d{4}([/-年])\d{1,2}([/-月])\d{1,2}([日])\s?\d{0,2}:?\d{0,2}:?\d{0,2}";

        /// <summary>
        /// Verificar dos decimales
        /// </summary>
        public const string DecimalCheck = @"^[0-9]+(.[0-9]{2})?$";

        /// <summary>
        /// Detección de correo electrónico de expresión regular
        /// </summary>
        public const string EmailCheck = @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$";

        /// <summary>
        /// Archivo de detección de ruta de expresión regular
        /// </summary>
        public const string FileCheck = @"^(?<fpath>([a-zA-Z]:\\)([\s\.\-\w]+\\)*)(?<fname>[\w]+)(?<namext>(\.[\w]+)*)(?<suffix>\.[\w]+)";

        /// <summary>
        /// Si la expresión regular de detección de cadena hexadecimal
        /// </summary>
        public const string HexStringCheck = @"\A\b[0-9a-fA-F]+\b\Z";

        /// <summary>
        /// Identificación de la tarjeta de identificación de expresión regular
        /// </summary>
        public const string IdCardCheck = @"^(11|12|13|14|15|21|22|23|31|32|33|34|35|36|37|41|42|43|44|45|46|50|51|52|53|54|61|62|63|64|65|71|81|82|91)(\d{13}|\d{15}[\dx])$";

        /// <summary>
        /// Detección de enteros expresión regular
        /// </summary>
        public const string IntCheck = @"^[0-9]+[0-9]*$";

        /// <summary>
        /// Detección de IP expresión regular
        /// </summary>
        public const string IpCheck = @"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$";// @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$";

        /// <summary>
        /// A~Z,a~z detección de subtítulos expresión regular
        /// </summary>
        public const string LetterCheck = @"^[A-Za-z]+$";

        /// <summary>
        /// Detección digital de expresión regular
        /// </summary>
        public const string NumberCheck = @"^[0-9]+[0-9]*[.]?[0-9]*$";

        /// <summary>
        /// Verificar un entero positivo distinto de cero
        /// </summary>
        public const string NumberWithoutZeroCheck = @"^[A-Za-z]+$";

        /// <summary>
        /// Verifique la longitud de la contraseña (requiere una longitud de 6-18 dígitos)
        /// </summary>
        public const string PassWordLengthCheck = @"^\d{6,18}$";

        /// <summary>
        /// Código postal detección expresión regular
        /// </summary>
        public const string PostCodeCheck = @"^\d{6}$";

        /// <summary>
        /// Expresión regular de detección de URL
        /// </summary>
        public const string URLCheck = @"^(((file|gopher|news|nntp|telnet|http|ftp|https|ftps|sftp)://)|(www\.))+(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9\&amp;%_\./-~-]*)?$";
        
        #endregion Fields
    }
}