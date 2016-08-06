//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IDisposableDependencyObjectWrapperOfT 
//        Description :    
//        Created by Wsy at 2016/8/6 17:04:48
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Dependency
{
    /// <summary>
    /// 此接口是用于包装从IOC容器解析出来的对象
    /// 继承自IDisposable,以便其更方便释放
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDisposableDependencyObjectWrapper<out T>:IDisposable
    {
        /// <summary>
        /// 解析出来的对象
        /// </summary>
        T Object { get; }
    }
}
