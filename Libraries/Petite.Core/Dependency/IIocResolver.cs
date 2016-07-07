//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IIocResolver 
//        Description :    
//        Created by Wsy at 2016/7/7 17:46:32
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petite.Core.Dependency
{
    /// <summary>
    /// 依赖项解析器
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 从 IOC container获取依赖对象
        /// 对象使用后必须 Released (<see cref="Release"/>) .
        /// </summary> 
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象实例</returns>
        T Resolve<T>();

        /// <summary>
        /// 从 IOC container获取依赖对象
        /// 对象使用后必须 Released (<see cref="Release"/>) .
        /// </summary> 
        /// <typeparam name="T">要映射的对象类型</typeparam>
        /// <param name="type">需要获取的对象类型</param>
        /// <returns>对象实例</returns>
        T Resolve<T>(Type type);

        /// <summary>
        /// 从 IOC container获取依赖对象
        /// 对象使用后必须 Released (<see cref="Release"/>) .
        /// </summary> 
        /// <typeparam name="T">需要获取的对象类型</typeparam>
        /// <param name="argumentsAsAnonymousType">构造函数参数</param>
        /// <returns>对象实例</returns>
        T Resolve<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// 从 IOC container获取依赖对象
        /// 对象使用后必须 Released (<see cref="Release"/>) .
        /// </summary> 
        /// <param name="type">需要获取的对象类型</param>
        /// <returns>对象实例</returns>
        object Resolve(Type type);

        /// <summary>
        /// 从 IOC container获取依赖对象
        /// 对象使用后必须 Released (<see cref="Release"/>) .
        /// </summary> 
        /// <param name="type">需要获取的对象类型</param>
        /// <param name="argumentsAsAnonymousType">构造函数参数</param>
        /// <returns>对象实例</returns>
        object Resolve(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// 释放前一个获取的对象. 参见 Resolve methods.
        /// </summary>
        /// <param name="obj">需要释放的对象</param>
        void Release(object obj);

        /// <summary>
        /// 检测给定的Type是否已经注册过
        /// </summary>
        /// <param name="type">需要检测的Type</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// 检测给定的Type是否已经注册过
        /// </summary>
        /// <typeparam name="T">需要检测的Type</typeparam>
        bool IsRegistered<T>();
    }
}
