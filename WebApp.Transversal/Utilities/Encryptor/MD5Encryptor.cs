namespace WebApp.Transversales.Utilities.Encryptor
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Clase auxiliar de cifrado MD5
    /// </summary>
    public static class MD5Encryptor
    {
        #region Methods

        /// <summary>
        /// Verifique el cifrado aleatorio de MD5
        /// </summary>
        /// <param name="data">Cadena para ser juzgado</param>
        /// <param name="rmd5">MD5 GUID</param>
        /// <returns>¿Es igual?</returns>
        public static bool EqualsRandomMD5(this string data, Guid rmd5)
        {
            byte[] _array = rmd5.ToByteArray();
            byte _randomKey = _array[0];
            using(var md5Provider = new MD5CryptoServiceProvider())
            {
                data += _randomKey;
                byte[] _bytes = Encoding.UTF8.GetBytes(data);
                byte[] _hash = md5Provider.ComputeHash(_bytes);
                
                for(int i = 1; i < 16; i++)
                {
                    if(_hash[i] != _array[i])
                    {
                        return false;
                    }
                }
                
                return true;
            }
        }

        /// <summary>
        /// Generar cifrado aleatorio
        /// </summary>
        /// <param name="data">Necesita encriptar la cadena</param>
        /// <returns>Guía de cifrado MD5</returns>
        public static Guid ToRandomMD5(this string data)
        {
            using(MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider())
            {
                //生成256以内的随机数
                byte _randomKey = (byte)Math.Abs(new object().GetHashCode() % 256);
                data += _randomKey;
                byte[] _array = Encoding.UTF8.GetBytes(data);
                byte[] _hash = md5Provider.ComputeHash(_array);
                _hash[0] = _randomKey;
                return new Guid(_hash);
            }
        }

        /// <summary>
        /// Obtenga la cadena encriptada MD5
        /// <para>eg:StringHelper.Encrypt("YanZhiwei");==>"b07ec574a666d8e7582885ce334b4d00"</para>
        /// </summary>
        /// <param name="data">Cadena que necesita ser encriptada</param>
        /// <returns>Cadena encriptada MD5</returns>
        public static string Encrypt(string data)
        {
            MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();
            byte[] _bytValue = Encoding.UTF8.GetBytes(data);
            byte[] _bytHash = _md5.ComputeHash(_bytValue);
            _md5.Clear();
            StringBuilder _builder = new StringBuilder();
            
            for(int i = 0; i < _bytHash.Length; i++)
            {
                _builder.Append(_bytHash[i].ToString("X").PadLeft(2, '0'));
            }
            
            return _builder.ToString().ToLower();
        }
        
        #endregion Methods
    }
}