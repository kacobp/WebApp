namespace WebApp.Transversales.Utilities.Encryptor
{
    using Operator;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Cifrado SHA256
    /// </summary>
    public class SHA256Encryptor
    {
        #region Methods

        /// <summary>
        /// Cifrado
        /// </summary>
        /// <param name="secretKey">Clave de cifrado</param>
        /// <param name="encryptString">Cadena que necesita ser encriptada</param>
        /// <returns></returns>
        public static string Encrypt(string secretKey, string encryptString)
        {
            ValidateOperator.Begin().NotNullOrEmpty(secretKey, "Clave de cifrado").NotNullOrEmpty(encryptString, "Cadena que necesita ser encriptada");
            byte[] _keyData = Encoding.UTF8.GetBytes(secretKey);
            byte[] _plainData = Encoding.UTF8.GetBytes(encryptString);
            using(HMACSHA256 sha256 = new HMACSHA256(_keyData))
            {
                StringBuilder _builder = new StringBuilder();
                byte[] _hashValue = sha256.ComputeHash(_plainData);
                
                foreach(byte item in _hashValue)
                {
                    _builder.Append(string.Format("{0:x2}", item));
                }
                
                return _builder.ToString();
            }
        }
        
        #endregion Methods
    }
}