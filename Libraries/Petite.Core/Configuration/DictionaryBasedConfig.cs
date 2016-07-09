//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :DictionaryBasedConfig 
//        Description :    
//        Created by Wsy at 2016/7/9 10:36:48
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using Petite.Core.Extension;

namespace Petite.Core.Configuration
{
    public class DictionaryBasedConfig:IDictionaryBasedConfig
    {
        /// <summary>
        /// 自定义配置的字典
        /// </summary>
        protected Dictionary<string, object> CustomSettings { get; private set; }

        /// <summary>
        /// 获取或设置一个配置值 
        /// 不存在则返回Null
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <returns>配置值</returns>
        public object this[string name]
        {
            get { return CustomSettings.GetOrDefault(name); }
            set { CustomSettings[name] = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected DictionaryBasedConfig()
        {
            CustomSettings = new Dictionary<string, object>();
        }

        /// <summary>
        /// 获取具体类型的配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns>对应值，不存在则返回null</returns>
        public T Get<T>(string name)
        {
            var value = this[name];
            return value == null
                ? default(T)
                : (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary>
        /// 设置一个Name为string类型的配置
        /// 如果具有同名配置，则覆盖
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <param name="value">配置值</param>
        public void Set<T>(string name, T value)
        {
            this[name] = value;
        }

        /// <summary>
        /// 通过Name获取配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <returns>对应值，不存在则返回 null</returns>
        public object Get(string name)
        {
            return Get(name, null);
        }

        /// <summary>
        /// 通过Name获取配置
        /// </summary>
        /// <param name="name">配置名称</param>
        /// <param name="defaultValue">不存在时返回的默认值</param>
        /// <returns>对应值，不存在则返回 null</returns>
        public object Get(string name, object defaultValue)
        {
            var value = this[name];
            if (value == null)
            {
                return defaultValue;
            }

            return this[name];
        }

        /// <summary>
        /// 通过Name获取配置
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">配置名称</param>
        /// <param name="defaultValue">不存在时返回默认值</param>
        /// <returns>不存在时返回默认值</returns>
        public T Get<T>(string name, T defaultValue)
        {
            return (T)Get(name, (object)defaultValue);
        }

        /// <summary>
        /// 通过Name获取配置
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">配置名称</param>
        /// <param name="creator">未找到对应的配置时调用的方法</param>
        /// <returns>未找到返回null</returns>
        public T GetOrCreate<T>(string name, Func<T> creator)
        {
            var value = Get(name);
            if (value == null)
            {
                value = creator();
                Set(name, value);
            }
            return (T)value;
        }
    }
}
