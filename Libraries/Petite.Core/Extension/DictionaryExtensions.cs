//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :DictionaryExtensions 
//        Description :    
//        Created by Wsy at 2016/7/9 10:42:26
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petite.Core.Extension
{
    /// <summary>
    /// 字典扩展类
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 确认字典中有没有Key对应的值存在
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dictionary">字典</param>
        /// <param name="key">Key</param>
        /// <param name="value">Key对应的值，如果不存在则为默认值</param>
        /// <returns>不存在则返回True</returns>
        internal static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
        {
            object valueObj;
            if (dictionary.TryGetValue(key, out valueObj) && valueObj is T)
            {
                value = (T)valueObj;
                return true;
            }

            value = default(T);
            return false;
        }

        /// <summary>
        /// 通过Key查找，如果不存在则返回默认值
        /// </summary>
        /// <param name="dictionary">字典</param>
        /// <param name="key">Key</param>
        /// <typeparam name="TKey">Key类型</typeparam>
        /// <typeparam name="TValue">Value类型</typeparam>
        /// <returns>如果存在则返回Value，否则返回默认值.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue obj;
            return dictionary.TryGetValue(key, out obj) ? obj : default(TValue);
        }
    }
}
