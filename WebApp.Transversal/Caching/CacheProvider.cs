// -----------------------------------------------------------------------
// <copyright file="CacheProvider.cs" company="Profile Corporate Services (Pty) Ltd">
//     Copyright © Profile Corporate Services (Pty) Ltd. All rights reserved.
// </copyright>
// <author>Douglas Lund</author>
// -----------------------------------------------------------------------

namespace WebApp.Transversales.Caching
{
    #region Using Directives

    using System;
    using System.Configuration;
    using System.Runtime.Caching;

    #endregion

    /// <summary>
    ///     ObjectCache Provider
    /// </summary>
    public class CacheProvider
    {
        #region Properties

        private static ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }

        #endregion

        #region Public Methods and Operators

        public static void Delete(string key)
        {
            Cache.Remove(key);
        }

        public static bool Exist(string key)
        {
            return (Cache.Contains(key));
        }

        public static object Get(string key)
        {
            return Cache[key];
        }

        public static void Refresh(string key)
        {
            if (Cache.Contains(key))
            {
                var cache = Cache.GetCacheItem(key);
                if (cache != null)
                {
                    var policy = new CacheItemPolicy {AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["SessionTime"]))};
                    Cache.Set(cache, policy);
                }
            }
        }

        public static void Set(string key, object data, int time)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(time)
            };
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        ///     Sets the cache data for a duration configured in the app setting timeSetting.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="data">The data.</param>
        /// <param name="timeAppSetting">The name of application setting containing the cached duration.</param>
        public static void Set(string key, object data, string timeAppSetting = "CacheTime")
        {
            var time = Convert.ToInt32(ConfigurationManager.AppSettings[timeAppSetting]);
            Set(key, data, time);
        }

        #endregion
    }
}