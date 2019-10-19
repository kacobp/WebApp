namespace WebApp.Transversales.Extensions
{
    using Model;
    using System;

    /// <summary>
    /// Consultar clase de ayuda
    /// </summary>
    public static class CheckHelper
    {
        #region Methods

        /// <summary>
        /// Determinar si la cadena está en un cierto rango
        /// <para>eg:CheckHelper.InRange("2", 1, 5);==>true</para>
        /// <para>Juicio: menor o igual que y mayor o igual que</para>
        /// </summary>
        /// <param name="data">Juez cadena</param>
        /// <param name="minValue">Rango mínimo</param>
        /// <param name="maxValue">Alcance máximo</param>
        /// <returns>Si está en un cierto rango</returns>
        public static bool InRange(string data, int minValue, int maxValue)
        {
            bool _result = false;
            int _number = -1;

            if(int.TryParse(data, out _number))
            {
                _result = (_number >= minValue && _number <= maxValue);
            }

            return _result;
        }

        /// <summary>
        /// Determinar si el tiempo está dentro del rango de tiempo
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="includeEq">if set to <c>true</c> [include eq].</param>
        /// <returns></returns>
        public static bool InRange(DateTime date, DateTime startTime, DateTime endTime, bool includeEq)
        {
            bool _result = false;

            if(includeEq)
            {
                if((date >= startTime) && (date <= endTime))
                {
                    _result = true;
                }
            }
            else
            {
                if((date > startTime) && (date < endTime))
                {
                    _result = true;
                }
            }

            return _result;
        }

        /// <summary>
        /// ¿Es Base64?
        /// </summary>
        /// <param name="data">验证数据</param>
        /// <returns>是否是Base64</returns>
        public static bool IsBase64(string data)
        {
            return (data.Length % 4) == 0 && RegexHelper.IsMatch(data, RegexPattern.Base64Check);
        }

        /// <summary>
        /// ¿Es un tipo Bigint?
        /// </summary>
        /// <param name="value">判断字符串</param>
        /// <param name="number">Bigint</param>
        /// <returns>是否是Bigint类型</returns>
        public static bool IsBigint(string value, out long number)
        {
            number = -1;
            return long.TryParse(value, out number);
        }

        /// <summary>
        /// Determinar si es una cadena BCD
        /// </summary>
        /// <param name="data">cadena BCD</param>
        /// <returns>No es una cadena BCD</returns>
        public static bool IsBinaryCodedDecimal(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.BinaryCodedDecimal);
        }

        /// <summary>
        /// ¿Es un tipo booleano?
        /// </summary>
        /// <param name="data">Datos</param>
        /// <returns>Tipo booleano</returns>
        public static bool IsBool(object data)
        {
            switch(data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;

                case "1":
                    return true;

                case "Si":
                    return true;

                case "No":
                    return false;

                case "yes":
                    return true;

                case "no":
                    return false;

                default:
                    return false;
            }
        }

        /// <summary>
        /// ¿Es un formato de fecha?
        /// <para>eg:CheckHelper.IsDate("12 de diciembre de 2014");==>true</para>
        /// </summary>
        /// <param name="data">cadena a juzgar</param>
        /// <returns>¿Es un formato de fecha?</returns>
        public static bool IsDate(string data)
        {
            if(String.IsNullOrEmpty(data)) return false;

            if(RegexHelper.IsMatch(data, RegexPattern.DateCheck))
            {
                data = data.Replace("Año", "-");
                data = data.Replace("Mes", "-");
                data = data.Replace("Día", " ");
                data = data.Replace("  ", " ");
                DateTime _date;
                return DateTime.TryParse(data, out _date);
            }

            return false;
        }

        /// <summary>
        /// Verificar si es correo electrónico
        /// <para>eg:CheckHelper.IsEmail("Yan.Zhiwei@hotmail.com");==true</para>
        /// </summary>
        /// <param name="data">Cadena de verificación</param>
        /// <returns>¿Es correo electrónico?</returns>
        public static bool IsEmail(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.EmailCheck);
        }

        /// <summary>
        /// Si es incluso    
        /// </summary>
        /// <param name="data">Necesito juzgar</param>
        /// <returns>Si es incluso</returns>
        public static bool IsEven(int data)
        {
            return ((data & 1) == 0);
        }

        /// <summary>
        /// Verificar si es una ruta de archivo
        /// <para>eg:CheckHelper.IsFilePath(@"C:\alipay\log.txt");==>true</para>
        /// </summary>
        /// <param name="data">Cadena de verificación</param>
        /// <returns>¿Es una ruta de archivo?</returns>
        public static bool IsFilePath(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.FileCheck);
        }

        /// <summary>
        /// Si es una cadena hexadecimal
        /// </summary>
        /// <param name="data">Datos de verificación</param>
        /// <returns>Si es una cadena hexadecimal</returns>
        public static bool IsHexString(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.HexStringCheck);
        }

        /// <summary>
        /// ¿Es un número de identificación?
        /// </summary>
        /// <param name="data">Datos de verificación</param>
        /// <returns>¿Es un número de identificación?</returns>
        public static bool IsIdCard(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.IdCardCheck);
        }

        /// <summary>
        /// Determine si el byte de imagen [] es legal
        /// </summary>
        /// <param name="data">Byte de imagen []</param>
        /// <returns>Es legal?</returns>
        public static bool IsImageFormat(byte[] data)
        {
            if(data == null || data.Length < 4)
            {
                return false;
            }

            string _fileClass = "";
            int _len = data.Length;

            try
            {
                _fileClass = data[0].ToString();
                _fileClass += data[1].ToString();
                _fileClass = _fileClass.Trim();

                if(_fileClass == "7173" || _fileClass == "13780")  //7173:gif;13780:PNG;
                {
                    return true;
                }
                else      // Jpg,Jpeg
                {
                    byte[] _jpg = new byte[4];
                    _jpg[0] = 0xff;
                    _jpg[1] = 0xd8;
                    _jpg[2] = 0xff;
                    _jpg[3] = 0xd9;

                    if(data[0] == _jpg[0] && data[1] == _jpg[1]
                            && data[_len - 2] == _jpg[2] && data[_len - 1] == _jpg[3])
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ¿Es un número entero?
        /// </summary>
        /// <returns>Validation</returns>
        public static bool IsInt(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.IntCheck);
        }

        /// <summary>
        /// Determine si es una dirección IP4, IP6 legal
        /// <para>eg: Assert.IsTrue(CheckHelper.IsIp46Address("192.168.1.1:8060"));</para>
        /// <para>    Assert.IsTrue(CheckHelper.IsIp46Address("[2001:0DB8:02de::0e13]:9010"));</para>
        /// </summary>
        /// <param name="data">Cadena para ser juzgado</param>
        /// <returns>Si es legal, volverá a la parte del host. Si no es legal, volverá nulo.</returns>
        public static bool IsIp46Address(string data)
        {
            bool _result = false;

            if(!string.IsNullOrEmpty(data))
            {
                UriHostNameType _hostType = Uri.CheckHostName(data);

                if(_hostType == UriHostNameType.Unknown)  // Por ejemplo, "192.168.1.1:8060" o [2001: 0DB8: 02de :: 0e13]: 9010
                {
                    Uri _url;

                    if(Uri.TryCreate(string.Format("http://{0}", data), UriKind.Absolute, out _url))
                    {
                        _result = true;
                    }
                }
                else if(_hostType == UriHostNameType.IPv4 || _hostType == UriHostNameType.IPv6)
                {
                    _result = true;
                }
            }

            return _result;
        }

        /// <summary>
        /// ¿Es IP?
        /// </summary>
        /// <param name="data">Necesidad de detectar IP</param>
        /// <returns>Validation</returns>
        public static bool IsIp4Address(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.IpCheck);
        }

        /// <summary>
        /// Determinar si es latitud legal
        /// </summary>
        /// <param name="data">Latitud para ser juzgado</param>
        /// <returns>Es legal?</returns>
        public static bool IsLatitude(decimal data)
        {
            return !(data < -90 || data > 90);
        }

        /// <summary>
        /// ¿Es una IP de intranet?
        /// </summary>
        /// <param name="ipAddress">Dirección IP</param>
        /// <returns></returns>
        public static bool IsLocalIp4(this string ipAddress)
        {
            /*
             *Conocimiento:
                 *Los diseñadores de Internet reservan una parte del espacio de direcciones IPv4 para direcciones privadas. 
                 * Las direcciones IPv4 en el espacio de direcciones privadas se denominan direcciones privadas.
                 * Estas direcciones nunca se asignan como direcciones públicas, por lo que las direcciones privadas nunca vienen con direcciones públicas. Repetir
                 * La dirección privada IPv4 es la siguiente:  *IP rating IP location ==> Clase A 10.0.0.0 - 10.255.255.255
                 * Máscara de subred predeterminada: 255.0.0.0 ==> Clase B 172.16.0.0 - 172.31.255.255
                 * Máscara de subred predeterminada: 255.255.0.0 ==> Clase C 192.168.0.0 - 192.168.255.255
                 * Máscara de subred predeterminada: 255.255.255.0
                 * La intranet está disponible para acceso a Internet.La intranet necesita un servidor o enrutador como puerta de enlace para acceder a Internet.
    
                 * El servidor que hace la puerta de enlace tiene la dirección IP de una puerta de enlace(servidor / enrutador). 
                 * La IP de otras computadoras de la intranet se puede configurar de acuerdo con ella, siempre que los primeros tres dígitos de IP sean los mismos que el tercero,
                 * y el cuarto puede ser de 0 - 255.Opcional pero diferente de la IP del servidor
            */

             bool _result = false;
            if(!string.IsNullOrEmpty(ipAddress) && IsIp4Address(ipAddress))
            {
                if(ipAddress.StartsWith("192.168.") || ipAddress.StartsWith("172.") || ipAddress.StartsWith("10."))
                {
                    _result = true;
                }
            }

            return _result;
        }

        /// <summary>
        /// Determinar si es longitud legal
        /// </summary>
        /// <param name="data">Longitud para ser juzgado</param>
        /// <returns>Es legal?</returns>
        public static bool IsLongitude(decimal data)
        {
            return !(data < -180 || data > 180);
        }

        /// <summary>
        /// ¿Es un número?
        /// <para>eg:CheckHelper.IsNumber("abc");==>false</para>
        /// </summary>
        /// <param name="data">Juez cadena</param>
        /// <returns>¿Es un número?</returns>
        public static bool IsNumber(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.NumberCheck);
        }

        /// <summary>
        /// ¿Es extraño?
        /// </summary>
        /// <param name="data">Necesito juzgar</param>
        /// <returns>¿Es extraño?</returns>
        public static bool IsOdd(int data)
        {
            return ((data & 1) == 1);
        }

        /// <summary>
        /// Verificar si es un código postal
        /// </summary>
        /// <param name="data">Cadena de verificación</param>
        /// <returns>¿Es un código postal?</returns>
        public static bool IsPoseCode(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.PostCodeCheck);
        }

        /// <summary>
        /// ¿Es un tipo Smallint?
        /// </summary>
        /// <param name="value">Juez cadena</param>
        /// <param name="number">short</param>
        /// <returns>¿Es un tipo Smallint?</returns>
        public static bool IsSmallint(string value, out short number)
        {
            number = -1;
            return short.TryParse(value, out number);
        }

        /// <summary>
        /// ¿Es Tinyint?
        /// </summary>
        /// <param name="value">Juez cadena</param>
        /// <param name="number">Tinyint</param>
        /// <returns>¿Es Tinyint?</returns>
        public static bool IsTinyint(string value, out byte number)
        {
            number = 0;
            return byte.TryParse(value, out number);
        }

        /// <summary>
        /// Verificar si es una URL
        /// <para>eg:CheckHelper.IsURL("www.cnblogs.com/yan-zhiwei");==>true</para>
        /// </summary>
        /// <param name="data">Cadena de verificación</param>
        /// <returns>¿Es una URL?</returns>
        public static bool IsURL(string data)
        {
            return RegexHelper.IsMatch(data, RegexPattern.URLCheck);
        }

        /// <summary>
        /// Compruebe si el número de puerto establecido es correcto
        /// </summary>
        /// <param name="port">Número de puerto</param>
        /// <returns>¿Es correcto el número de puerto?</returns>
        public static bool IsValidPort(string port)
        {
            bool _result = false;
            int _minPORT = 0, _maxPORT = 65535;
            int _portValue = -1;

            if(int.TryParse(port, out _portValue))
            {
                _result = !((_portValue < _minPORT) || (_portValue > _maxPORT));
            }

            return _result;
        }

        /// <summary>
        /// Verificar no vacío
        /// </summary>
        /// <param name="data">Objeto de verificación</param>
        /// <returns>Verificar no vacío</returns>
        public static bool NotNull(object data)
        {
            return !(data == null);
        }

        #endregion Methods
    }
}