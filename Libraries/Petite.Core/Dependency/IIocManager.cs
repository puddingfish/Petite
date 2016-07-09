//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IIocManager 
//        Description :    
//        Created by Wsy at 2016/7/9 13:24:44
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using Castle.Windsor;

namespace Petite.Core.Dependency
{
    public interface IIocManager:IIocResolver,IIocRegistrar,IDisposable
    {
        /// <summary>
        /// Castle Windsor Container.
        /// </summary>
        IWindsorContainer IocContainer { get; }

        /// <summary>
        /// 检测给定的类型是否已经注册
        /// </summary>
        /// <param name="type">Type</param>
        new bool IsRegistered(Type type);

        /// <summary>
        /// 检测给定的类型是否已经注册
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        new bool IsRegistered<T>();
    }
}
