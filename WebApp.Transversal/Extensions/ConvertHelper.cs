﻿namespace WebApp.Transversales.Extensions
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Globalization;

    /// <summary>
    /// Conversion helper class
    /// </summary>
    public static class ConvertHelper
    {
        #region Methods

        /// <summary>
        /// 转换成布尔类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static bool ToBooleanOrDefault(this object data, bool errorValue)
        {
            bool _result = false;

            if(data != null)
            {
                if(bool.TryParse(data.ToString(), out _result))
                {
                    return _result;
                }
            }

            return errorValue;
        }

        /// <summary>
        /// 转换成Byte类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static byte ToByteOrDefault(this object data, byte errorValue)
        {
            if(data != null)
            {
                byte _result = 0;

                if(byte.TryParse(data.ToString(), out _result))
                {
                    return _result;
                }
            }

            return errorValue;
        }

 
        /// <summary>
        /// 转换成日期
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="errorValue">转换失败返回数据</param>
        /// <returns>日期</returns>
        public static DateTime ToDateOrDefault(this object data, DateTime errorValue)
        {
            if(data != null)
            {
                DateTime _result;
                return DateTime.TryParse(data.ToString(), out _result) ? _result : errorValue;
            }

            return errorValue;
        }

        /// <summary>
        ///  转换成decimal类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static decimal ToDecimalOrDefault(this object data, decimal errorValue)
        {
            if(data != null)
            {
                decimal _parsedecimalValue = 0;
                bool _parseResult = decimal.TryParse(data.ToString(), out _parsedecimalValue);
                return _parseResult == true ? _parsedecimalValue : errorValue;
            }

            return errorValue;
        }

        /// <summary>
        /// 转换成double类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static double ToDoubleOrDefault(this object data, double errorValue)
        {
            if(data != null)
            {
                double _parseIntValue = 0;
                bool _parseResult = double.TryParse(data.ToString(), out _parseIntValue);
                return _parseResult == true ? _parseIntValue : errorValue;
            }

            return errorValue;
        }

        /// <summary>
        /// 转换成Int类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorData">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static int ToIntOrDefault(this object data, int errorData)
        {
            if(data != null)
            {
                int _parseIntValue = 0;
                bool _parseResult = int.TryParse(data.ToString(), out _parseIntValue);
                return _parseResult == true ? _parseIntValue : errorData;
            }

            return errorData;
        }

        /// <summary>
        /// 按照列名称获取Int值
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="columnName">列名称</param>
        /// <param name="failValue">若列等于NULL，需要返回的值</param>
        /// <returns>若列不等于NULL则返回实际值</returns>
        public static int ToIntOrDefault(this DataRow row, string columnName, int failValue)
        {
            if(row != null)
            {
                if(row.IsNull(columnName))
                {
                    int.TryParse(row[columnName].ToString(), out failValue);
                }
            }

            return failValue;
        }

        /// <summary>
        /// 按照列索引获取Int值
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="failValue">若列等于NULL，需要返回的值</param>
        /// <returns>若列不等于NULL则返回实际值</returns>
        public static int ToIntOrDefault(this DataRow row, int columnIndex, int failValue)
        {
            if(row != null)
            {
                if(row.IsNull(columnIndex))
                {
                    int.TryParse(row[columnIndex].ToString(), out failValue);
                }
            }

            return failValue;
        }

        /// <summary>
        /// 转换成Int32类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static int ToInt32OrDefault(this object data, int errorValue)
        {
            if(data != null)
            {
                int _parseIntValue = 0;
                bool _parseResult = int.TryParse(data.ToString(), out _parseIntValue);
                return _parseResult == true ? _parseIntValue : errorValue;
            }

            return errorValue;
        }

        /// <summary>
        /// 转换成Int64类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static long ToInt64OrDefault(this object data, long errorValue)
        {
            if(data != null)
            {
                long _parseIntValue = 0;
                bool _parseResult = long.TryParse(data.ToString(), out _parseIntValue);
                return _parseResult == true ? _parseIntValue : errorValue;
            }

            return errorValue;
        }

        /// <summary>
        /// 转换成Int16类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorData">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static short ToShortOrDefault(this object data, short errorData)
        {
            if(data != null)
            {
                short _parseIntValue = 0;
                bool _parseResult = short.TryParse(data.ToString(), out _parseIntValue);
                return _parseResult == true ? _parseIntValue : errorData;
            }

            return errorData;
        }

        /// <summary>
        /// 转换成string类型
        /// </summary>
        /// <param name="data">需要转换的object</param>
        /// <param name="errorValue">转换失败后返回类型</param>
        /// <returns>转换返回</returns>
        public static string ToStringOrDefault(this object data, string errorValue)
        {
            return data == null ? errorValue : data.ToString();
        }

        /// <summary>
        /// 泛型数组转换为字符串
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="array">泛型数组</param>
        /// <param name="delimiter">分隔符</param>
        /// <returns>转换好的字符串</returns>
        public static string ToString<T>(this T[] array, string delimiter)
        {
            string[] _array = Array.ConvertAll<T, string>(array, n => n.ToString());
            return string.Join(delimiter, _array);
        }

        /// <summary>
        /// 将时间类型转换为字符串表述
        /// </summary>
        /// <param name="data">DateTime</param>
        /// <param name="formartString">格式化字符串</param>
        /// <param name="errorValue">处理失败返回值</param>
        /// <returns>字符串</returns>
        public static string ToStringOrDefault(this DateTime data, string formartString, string errorValue)
        {
            if(data != null && data != default(DateTime))
            {
                return data.ToString(formartString);
            }

            return errorValue;
        }

        /// <summary>
        /// 按照列名称获取Sting值
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="columnName">列名称</param>
        /// <param name="failValue">若列等于NULL，需要返回的值</param>
        /// <returns>若列不等于NULL则返回实际值</returns>
        public static string ToStringOrDefault(this DataRow row, string columnName, string failValue)
        {
            if(row != null)
            {
                failValue = row.IsNull(columnName) == true ? failValue : row[columnName].ToString();
            }

            return failValue;
        }

        /// <summary>
        /// 按照列索引获取Sting值
        /// </summary>
        /// <param name="row">DataRow</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="failValue">若列等于NULL，需要返回的值</param>
        /// <returns>若列不等于NULL则返回实际值</returns>
        public static string ToStringOrDefault(this DataRow row, int columnIndex, string failValue)
        {
            if(row != null)
            {
                failValue = row.IsNull(columnIndex) == true ? failValue : row[columnIndex].ToString().Trim();
            }

            return failValue;
        }

        /// <summary>
        /// 字符串类型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="data">需要转换的字符串</param>
        /// <returns>转换类型</returns>
        public static T ToStringBase<T>(this string data)
        {
            T _result = default(T);

            if(!string.IsNullOrEmpty(data))
            {
                TypeConverter _convert = TypeDescriptor.GetConverter(typeof(T));
                _result = (T)_convert.ConvertFrom(data);
            }

            return _result;
        }

        #endregion Methods
    }
}