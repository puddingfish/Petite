//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ITypeList 
//        Description :    
//        Created by Wsy at 2016/8/6 15:01:23
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;


namespace Petite.Core.Extension
{
    /// <summary>
    /// object类型的<see cref="ITypeList{TBaseType}"/> .
    /// </summary>
    public interface ITypeList : ITypeList<object>
    {

    }

    /// <summary>
    /// 使用指定基类扩展 <see cref="IList{Type}"/> .
    /// </summary>
    /// <typeparam name="TBaseType">list对应的基类<see cref="Type"/>s </typeparam>
    public interface ITypeList<in TBaseType> : IList<Type>
    {
        /// <summary>
        /// 添加一个Type到当前List.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        void Add<T>() where T : TBaseType;

        /// <summary>
        /// 检查当前List是否存在指定Type.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns></returns>
        bool Contains<T>() where T : TBaseType;

        /// <summary>
        /// 从List中移除某个Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>() where T : TBaseType;
    }
}
