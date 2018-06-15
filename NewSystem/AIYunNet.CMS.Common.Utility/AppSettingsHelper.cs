﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AIYunNet.CMS.Common.Utility
{
    /// <summary>
    /// 配置文件appSettings节点的帮助方法
    /// </summary>
    public class AppSettingsHelper
    {
        //图片地址
        public static string ImgUrl= ConfigurationManager.AppSettings["ImgUrl"];
        public static string  vueImgUrl = ConfigurationManager.AppSettings["vueImgUrl"];
        public static string thumbnailImage = ConfigurationManager.AppSettings["thumbnailImage"];
        public static string vuethumbnailImage = ConfigurationManager.AppSettings["vuethumbnailImage"];
        //短信验证密匙
        public static string SMSKey = ConfigurationManager.AppSettings["SMSKey"];
        //短信验证账号
        public static string SMSUid = ConfigurationManager.AppSettings["SMSUid"];
        
        
        private static readonly NameValueCollection AppSettings;

        static AppSettingsHelper()
        {
            AppSettings = System.Configuration.ConfigurationManager.AppSettings;
        }

        #region GetString

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的字符串类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>字符串</returns>
        public static string GetString(string key)
        {
            return getValue(key, true, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的字符串类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串</returns>
        public static string GetString(string key, string defaultValue)
        {
            return getValue(key, false, defaultValue);
        }

        #endregion

        #region GetStringArray

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的string[]类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="separator">分隔符</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStringArray(string key, string separator)
        {
            return GetStringArray(key, separator, true, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的string[]类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="separator">分隔符</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串数组</returns>
        public static string[] GetStringArray(string key, string separator, string[] defaultValue)
        {
            return GetStringArray(key, separator, false, defaultValue);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的string[]类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="separator">分隔符</param>
        /// <param name="valueRequired">指定配置文件中是否必须需要配置有该名称的元素，传入False则方法返回默认值，反之抛出异常</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串数组</returns>
        private static string[] GetStringArray(string key, string separator, bool valueRequired, string[] defaultValue)
        {
            string value = getValue(key, valueRequired, null);

            if (!string.IsNullOrEmpty(value))
                return value.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            else if (!valueRequired)
                return defaultValue;

            throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点，且没有指定默认值");
        }

        #endregion

        #region GetInt32

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的Int类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>Int</returns>
        public static int GetInt32(string key)
        {
            return GetInt32(key, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的Int类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int</returns>
        public static int GetInt32(string key, int defaultValue)
        {
            return GetInt32(key, defaultValue);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的Int类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>Int</returns>
        private static int GetInt32(string key, int? defaultValue)
        {
            return GetValue<int>(key, (v, pv) => int.TryParse(v, out pv), defaultValue);
        }

        #endregion

        #region GetBoolean

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的布尔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>布尔值</returns>
        public static bool GetBoolean(string key)
        {
            return GetBoolean(key, null);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的布尔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>布尔值</returns>
        public static bool GetBoolean(string key, bool defaultValue)
        {
            return GetBoolean(key, defaultValue);
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的布尔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>布尔值</returns>
        private static bool GetBoolean(string key, bool? defaultValue)
        {
            return GetValue<bool>(key, (v, pv) => bool.TryParse(v, out pv), defaultValue);
        }

        #endregion

        #region GetTimeSpan

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的时间间隔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <returns>时间间隔</returns>
        public static TimeSpan GetTimeSpan(string key)
        {
            return TimeSpan.Parse(getValue(key, true, null));
        }

        /// <summary>
        /// 获取配置文件中appSettings节点下指定索引键的时间间隔类型的的值
        /// </summary>
        /// <param name="key">索引键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>时间间隔</returns>
        public static TimeSpan GetTimeSpan(string key, TimeSpan defaultValue)
        {
            string val = getValue(key, false, null);

            if (val == null)
                return defaultValue;

            return TimeSpan.Parse(val);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 获取配置文件appSettings集合中指定索引的值
        /// </summary>
        /// <typeparam name="T">返回值类型参数</typeparam>
        /// <param name="key">索引键</param>
        /// <param name="parseValue">将指定索引键的值转化为返回类型的值的委托方法</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        private static T GetValue<T>(string key, Func<string, T, bool> parseValue, T? defaultValue) where T : struct
        {
            string value = AppSettings[key];

            if (value != null)
            {
                T parsedValue = default(T);

                if (parseValue(value, parsedValue))
                    return parsedValue;
                else
                    throw new ApplicationException(string.Format("Setting '{0}' was not a valid {1}", key,
                        typeof(T).FullName));
            }

            if (!defaultValue.HasValue)
                throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点，且没有指定默认值");
            else
                return defaultValue.Value;
        }

        /// <summary>
        /// 获取配置文件appSettings集合中指定索引的值
        /// </summary>
        /// <param name="key">索引</param>
        /// <param name="valueRequired">指定配置文件中是否必须需要配置有该名称的元素，传入False则方法返回默认值，反之抛出异常</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>字符串</returns>
        private static string getValue(string key, bool valueRequired, string defaultValue)
        {
            string value = AppSettings[key];

            if (value != null)
                return value;
            else if (!valueRequired)
                return defaultValue;

            throw new ApplicationException("在配置文件的appSettings节点集合中找不到key为" + key + "的子节点");
        }

        #endregion
    }
}
