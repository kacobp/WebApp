namespace WebApp.Transversales.Utilities.Encryptor
{
    using Common;
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using WebApp.Transversales.Extensions;

    /// <summary>
    /// DES (Estándar de cifrado de datos)
    /// La clave clave utilizada por DES es de 8 bytes, y el vector inicial IV también es de 8 bytes.
    /// </summary>
    public class DESEncryptor
    {
        #region Fields

        /// <summary>
        /// Clave de cifrado predeterminada
        /// </summary>
        private const string key = "WebApp.Utilities";

        /// <summary>
        /// Vector predeterminado
        /// </summary>
        private static byte[] iv = { 0x21, 0x45, 0x65, 0x87, 0x09, 0xBA, 0xDC, 0xEF };

        /// <summary>
        /// The DES
        /// </summary>
        private DES des = null;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Clave</param>
        /// <param name="iv">Vector</param>
        public DESEncryptor(byte[] key, byte[] iv)
        {
            des = new DESCryptoServiceProvider();
            des.Key = key;
            des.IV = iv;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key">Clave</param>
        /// <param name="iv">Vector</param>
        public DESEncryptor(string key, byte[] iv)
        {
            des = new DESCryptoServiceProvider();
            key = key.Substring(0, 8);
            key = key.PadRight(8, ' ');
            des.Key = Encoding.UTF8.GetBytes(key.Substring(0, 8));
            des.IV = iv;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Generar DES
        /// </summary>
        /// <returns>DES</returns>
        public static DES CreateDES()
        {
            return CreateDES(string.Empty);
        }

        /// <summary>
        /// Generar DES de acuerdo con la CLAVE
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>DES</returns>
        public static DES CreateDES(string key)
        {
            DES _des = new DESCryptoServiceProvider();
            DESCryptoServiceProvider _desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();

            if(!string.IsNullOrEmpty(key))
            {
                MD5 _md5 = new MD5CryptoServiceProvider();
                _des.Key = ArrayHelper.Copy<byte>(_md5.ComputeHash(Encoding.UTF8.GetBytes(key)), 0, 8);
            }
            else
            {
                _des.Key = _desCrypto.Key;
            }

            _des.IV = _des.IV;
            return _des;
        }

        /// <summary>
        /// Usar vector predeterminado, descifrado de clave
        /// </summary>
        /// <param name="text">Una cadena que necesita ser descifrada.</param>
        /// <returns>Cadena descifrada</returns>
        public static string Decrypt(string text)
        {
            DESEncryptor _helper = new DESEncryptor(key, iv);
            return _helper.DecryptString(text);
        }

        /// <summary>
        /// Utilice el vector predeterminado, cifrado KEY
        /// </summary>
        /// <param name="text">Cadena que necesita ser encriptada</param>
        /// <returns>Cadena encriptada</returns>
        public static string Encrypt(string text)
        {
            DESEncryptor _helper = new DESEncryptor(key, iv);
            return _helper.EncryptString(text);
        }

        /// <summary>
        /// Descifrar cadena
        /// </summary>
        /// <param name="text">Cadena para ser descifrada</param>
        /// <returns>Cadena descifrada</returns>
        public string DecryptString(string text)
        {
            byte[] _decryptedData = Convert.FromBase64String(text);
            using(MemoryStream ms = new MemoryStream())
            {
                try
                {
                    CryptoStream _cryptoStream = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                    _cryptoStream.Write(_decryptedData, 0, _decryptedData.Length);
                    _cryptoStream.FlushFinalBlock();
                }
                catch
                {
                    return "N/A";
                }

                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// Cadena encriptada
        /// </summary>
        /// <param name="text">Cadena que necesita ser encriptada</param>
        /// <returns>Cadena encriptada</returns>
        public string EncryptString(string text)
        {
            byte[] _encryptedData = Encoding.UTF8.GetBytes(text);
            using(MemoryStream ms = new MemoryStream())
            {
                CryptoStream _cryptoStream = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                _cryptoStream.Write(_encryptedData, 0, _encryptedData.Length);
                _cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        #endregion Methods
    }
}