//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :SingletonDependency 
//        Description :    
//        Created by Wsy at 2016/8/5 17:38:59
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Dependency
{
    public static class SingletonDependency<T>
    {
        /// <summary>
        /// 获取实例.
        /// </summary>
        /// <value>
        /// 实例.
        /// </value>
        public static T Instance { get { return LazyInstance.Value; } }
        private static readonly Lazy<T> LazyInstance;

        static SingletonDependency()
        {
            LazyInstance = new Lazy<T>(() => IocManager.Instance.Resolve<T>());
        }
    }
}
