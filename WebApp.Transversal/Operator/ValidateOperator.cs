
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using WebApp.Transversales.Extensions;
    using WebApp.Transversales.Model;
    using WebApp.Transversales.Resources;

namespace WebApp.Transversales.Operator
{
    /// <summary>
    /// Clase de ayuda, Validación de parámetros 
    /// </summary>
    public static class ValidateOperator
    {
        #region Methods

        /// <summary>
        /// Verificar la inicialización
        /// </summary>
        /// <returns>Validation</returns>
        public static Validation Begin()
        {
            return null;
        }

        /// <summary>
        /// Expresión regular a verificar
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="checkFactory">委托</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation Check(this Validation validation, Func<bool> checkFactory, string pattern, string argumentName)
        {
            return Check<ArgumentException>(validation, checkFactory, string.Format(Messages.ParameterCheck_Match2, argumentName));
        }

        /// <summary>
        /// Comprobación de parámetros personalizados
        /// </summary>
        /// <typeparam name="TException">泛型</typeparam>
        /// <param name="validation">Validation</param>
        /// <param name="checkedFactory">委托</param>
        /// <param name="message">自定义错误消息</param>
        /// <returns>Validation</returns>
        /// 时间：2016/7/19 11:37
        /// 备注：
        public static Validation Check<TException>(this Validation validation, Func<bool> checkedFactory, string message)
        where TException : Exception
        {
            if(checkedFactory())
            {
                return validation ?? new Validation()
                {
                    IsValid = true
                };
            }
            else
            {
                TException _exception = (TException)Activator.CreateInstance(typeof(TException), message);
                throw _exception;
            }
        }

        /// <summary>
        /// La carpeta que verifica la ruta especificada debe existir; de lo contrario, se produce una excepción <see cref = "DirectoryNotFoundException" />.
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">判断数据</param>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        /// <exception cref="DirectoryNotFoundException">DirectoryNotFoundException</exception>
        /// <returns>Validation</returns>
        public static Validation CheckDirectoryExists(this Validation validation, string data)
        {
            return Check<DirectoryNotFoundException>(validation, () => Directory.Exists(data), string.Format(Messages.ParameterCheck_DirectoryNotExists, data));
        }

        /// <summary>
        /// El archivo que verifica la ruta especificada debe existir; de lo contrario, se produce una excepción <see cref = "FileNotFoundException" />.
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">参数</param>
        /// <exception cref="ArgumentNullException">当文件路径为null时</exception>
        /// <exception cref="FileNotFoundException">当文件路径不存在时</exception>
        /// <returns>Validation</returns>
        public static Validation CheckFileExists(this Validation validation, string data)
        {
            return Check<FileNotFoundException>(validation, () => File.Exists(data), string.Format(Messages.ParameterCheck_FileNotExists, data));
        }

        /// <summary>
        /// El parámetro de verificación debe ser mayor que [o igual a, el parámetro canEqual] especificado; de lo contrario, se produce una excepción <see cref = "ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">参数类型。</typeparam>
        /// <param name="validation">Validation</param>
        /// <param name="value">判断数据</param>
        /// <param name="paramName">参数名称。</param>
        /// <param name="target">要比较的值。</param>
        /// <param name="canEqual">是否可等于。</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</exception>
        /// <returns>Validation</returns>
        public static Validation CheckGreaterThan<T>(this Validation validation, T value, string paramName, T target, bool canEqual)
        where T : IComparable<T>
        {
            // bool flag = canEqual ? value.CompareTo(target) >= 0 : value.CompareTo(target) > 0;
            string _format = canEqual ? Messages.ParameterCheck_NotGreaterThanOrEqual : Messages.ParameterCheck_NotGreaterThan;
            return Check<ArgumentOutOfRangeException>(validation, () => canEqual ? value.CompareTo(target) >= 0 : value.CompareTo(target) > 0, string.Format(_format, paramName, target));
        }

        /// <summary>
        /// El parámetro de verificación debe ser menor que [o igual que el parámetro canEqual] especificado; de lo contrario, se produce una excepción <see cref = "ArgumentOutOfRangeException" />.
        /// </summary>
        /// <typeparam name="T">参数类型。</typeparam>
        /// <param name="validation">Validation</param>
        /// <param name="value">判断数据</param>
        /// <param name="paramName">参数名称。</param>
        /// <param name="target">要比较的值。</param>
        /// <param name="canEqual">是否可等于。</param>
        /// <exception cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</exception>
        /// <returns>Validation</returns>
        public static Validation CheckLessThan<T>(this Validation validation, T value, string paramName, T target, bool canEqual)
        where T : IComparable<T>
        {
            string _format = canEqual ? Messages.ParameterCheck_NotLessThanOrEqual : Messages.ParameterCheck_NotLessThan;
            return Check<ArgumentOutOfRangeException>(validation, () => canEqual ? value.CompareTo(target) <= 0 : value.CompareTo(target) < 0, string.Format(_format, paramName, target));
        }

        /// <summary>
        /// 验证是否在范围内
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">输入项</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation InRange(this Validation validation, int data, int min, int max, string argumentName)
        {
            return Check<ArgumentOutOfRangeException>(validation, () => data >= min && data <= max, string.Format(Messages.ParameterCheck_Between, argumentName, min, max));
        }

        /// <summary>
        /// 是否是电子邮箱
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="email">需要验证的邮箱</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsEmail(this Validation validation, string email, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsEmail(email), RegexPattern.EmailCheck, argumentName);
        }

        /// <summary>
        /// 是否是文件路径
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">路径</param>
        /// <returns>Validation</returns>
        public static Validation IsFilePath(this Validation validation, string data)
        {
            return Check<ArgumentException>(validation, () => CheckHelper.IsFilePath(data), string.Format(Messages.ParameterCheck_IsFilePath, data));
        }

        /// <summary>
        /// 是否是十六进制字符串
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">验证数据</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsHexString(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsHexString(data), RegexPattern.HexStringCheck, argumentName);
        }

        /// <summary>
        /// 是否是身份证号码
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">验证数据</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsIdCard(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsIdCard(data), RegexPattern.IdCardCheck, argumentName);
        }

        /// <summary>
        /// 是否是整数
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">需要检测的字符串</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsInt(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsInt(data), RegexPattern.IntCheck, argumentName);
        }

        /// <summary>
        /// 是否是IP
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">需要检测到IP</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsIp(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsIp4Address(data), RegexPattern.IpCheck, argumentName);
        }

        /// <summary>
        /// 是否是数字
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">需要检测的字符串</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsNumber(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsNumber(data), RegexPattern.NumberCheck, argumentName);
        }

        /// <summary>
        /// 是否是合法端口
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">参数值</param>
        /// <param name="paramName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsPort(this Validation validation, string data, string paramName)
        {
            return Check<ArgumentException>(validation, () => CheckHelper.IsValidPort(data), string.Format(Messages.ParameterCheck_Port, paramName));
        }

        /// <summary>
        /// 是否是邮政编码
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">邮政编码</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsPoseCode(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsPoseCode(data), RegexPattern.PostCodeCheck, argumentName);
        }

        /// <summary>
        /// 判断字符串是否是要求的长度
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="input">验证的字符串</param>
        /// <param name="requireLength">要求的长度</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsRequireLen(this Validation validation, string input, int requireLength, string argumentName)
        {
            return Check<ArgumentException>(
                       validation,
                       () => input.Length == requireLength,
                       string.Format(Messages.ParameterCheck_StringLength, argumentName, requireLength));
        }

        /// <summary>
        /// 判断类型是否能序列化
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">输入项</param>
        /// <returns>Validation</returns>
        /// 时间：2016-01-14 9:57
        /// 备注：
        public static Validation IsSerializable(this Validation validation, object data)
        {
            return Check<ArgumentException>(validation, () => data.GetType().IsSerializable, string.Format("¡Este tipo de parámetro {0} no se puede serializar!", data.GetType().FullName));
        }

        /// <summary>
        /// ¿Es una URL?
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">url</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation IsURL(this Validation validation, string data, string argumentName)
        {
            return Check(validation, () => CheckHelper.IsURL(data), RegexPattern.URLCheck, argumentName);
        }

        /// <summary>
        /// El parámetro de verificación no puede ser igual a un valor
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">输入项</param>
        /// <param name="equalObj">比较项</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation NotEqual(this Validation validation, object data, object equalObj, string argumentName)
        {
            return Check<ArgumentException>(validation, () => data != equalObj, string.Format(Messages.ParameterCheck_NotEqual, argumentName, data));
        }

        /// <summary>
        /// Verificar no vacío
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="data">输入项</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation NotNull(this Validation validation, object data, string argumentName)
        {
            return Check<ArgumentNullException>(validation, () => CheckHelper.NotNull(data), string.Format(Messages.ParameterCheck_NotNull, argumentName));
        }

        /// <summary>
        /// No puede ser nulo o NULL verificado
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="input">输入项</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation NotNullOrEmpty(this Validation validation, string input, string argumentName)
        {
            return Check<ArgumentNullException>(validation, () => !string.IsNullOrEmpty(input), string.Format(Messages.ParameterCheck_NotNullOrEmpty_String, argumentName));
        }

        /// <summary>
        /// Expresión regular a verificar
        /// </summary>
        /// <param name="validation">Validation</param>
        /// <param name="input">需要匹配的输入项</param>
        /// <param name="pattern">正则表达式</param>
        /// <param name="argumentName">参数名称</param>
        /// <returns>Validation</returns>
        public static Validation RegexMatch(this Validation validation, string input, string pattern, string argumentName)
        {
            return Check<ArgumentException>(validation, () => Regex.IsMatch(input, pattern), string.Format(Messages.ParameterCheck_Match, input, argumentName));
        }

        #endregion Methods
    }
}