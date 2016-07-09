//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IDictionaryBasedConfig 
//        Description :    
//        Created by Wsy at 2016/7/9 10:12:32
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Configuration
{
    /// <summary>
    /// 使用Dictionary保存配置
    /// </summary>
    public interface IDictionaryBasedConfig
    {
        /// <summary>
        /// 设置一个string字典
        /// 如果已经存在 <paramref name="name"/>的字典,则覆盖.
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="value">配置值</param>
        /// <returns>返回<paramref name="value"/></returns>
        void Set<T>(string name, T value);

        /// <summary>
        /// 通过名称获取配置
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <returns>字典值，如果没找到则返回null</returns>
        object Get(string name);

        /// <summary>
        ///  通过名称获取配置
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">唯一名称</param>
        /// <returns>字典值，如果没找到则返回null</returns>
        T Get<T>(string name);

        /// <summary>
        /// 通过名称获取配置
        /// </summary>
        /// <param name="name">唯一名称</param>
        /// <param name="defaultValue">如果不存在此名称的配置则返回此默认值</param>
        /// <returns>字典值，如果没找到则返回defaultValue</returns>
        object Get(string name, object defaultValue);

        /// <summary>
        /// 通过名称获取配置
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">配置名称</param>
        /// <param name="defaultValue">如果不存在此名称的配置则返回此默认值</param>
        /// <returns>字典值，如果没找到则返回defaultValue</returns>
        T Get<T>(string name, T defaultValue);

        /// <summary>
        /// 通过名称获取配置
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">配置名称</param>
        /// <param name="creator">如果未找到匹配值，则调用此方法</param>
        /// <returns>字典值，如果没找到则返回null</returns>
        T GetOrCreate<T>(string name, Func<T> creator);
    }
}
