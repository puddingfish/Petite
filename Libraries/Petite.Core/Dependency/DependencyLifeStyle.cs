//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :DependencyLifeStyle 
//        Description :    
//        Created by Wsy at 2016/7/9 13:57:27
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Dependency
{
    public enum DependencyLifeStyle
    {
         /// <summary>
        /// 单例模式对象，首次解析时被创建
        /// 下次使用同一对象
        /// </summary>
        Singleton,

        /// <summary>
        /// 临时对象，每次解析都会创建一个新的实例
        /// </summary>
        Transient
    }
}
