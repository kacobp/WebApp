﻿namespace WebApp.Transversales.Extensions
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Clase auxiliar de expresión regular
    /// </summary>
    public class RegexHelper
    {
        #region Methods

        /// <summary>
        /// 正则表达式匹配，匹配返回true
        /// </summary>
        /// <param name="checkString">检查字符串</param>
        /// <param name="regexString">正则表达式字符串</param>
        /// <returns>是否匹配</returns>
        /// 日期：2015-10-10 9:10
        /// 备注：
        public static bool IsMatch(string checkString, string regexString)
        {
            return IsMatch(checkString, regexString, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 正则表达式匹配，匹配返回true
        /// </summary>
        /// <param name="checkString">检查字符串</param>
        /// <param name="regexString">正则表达式字符串</param>
        /// <param name="options">筛选条件</param>
        /// <returns>是否匹配</returns>
        public static bool IsMatch(string checkString, string regexString, RegexOptions options)
        {
            return Regex.IsMatch(checkString, regexString, options);
        }

        /// <summary>
        /// 正则表达式匹配，匹配返回true
        /// </summary>
        /// <param name="checkString">检查字符串</param>
        /// <param name="regexString">模式字符串</param>
        /// <param name="result">若匹配成功，则返回Match</param>
        /// <returns>匹配是否成功</returns>
        public static bool IsMatch(string checkString, string regexString, out Match result)
        {
            result = null;
            Regex _regex = new Regex(regexString);
            result = _regex.Match(checkString);
            bool _checkResult = result.Success;
            return _checkResult;
        }

        #endregion Methods
    }
}