//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ConventionalRegistrationContext 
//        Description :    
//        Created by Wsy at 2016/7/9 13:47:02
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Reflection;
using Petite.Core.Configuration;

namespace Petite.Core.Dependency
{
    /// <summary>
    /// 传递依赖注册过程中需要的对象
    /// </summary>
    public class ConventionalRegistrationContext:IConventionalRegistrationContext
    {
        /// <summary>
        /// 获取注册的Assembly
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// 使用Ioc管理器注册类型
        /// </summary>
        public IIocManager IocManager { get; private set; }

        /// <summary>
        /// 注册配置项
        /// </summary>
        public ConventionalRegistrationConfig Config { get; private set; }

        internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager, ConventionalRegistrationConfig config)
        {
            Assembly = assembly;
            IocManager = iocManager;
            Config = config;
        }
    }
}
