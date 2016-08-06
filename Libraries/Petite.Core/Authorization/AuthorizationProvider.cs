//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :AuthorizationProvider 
//        Description :    
//        Created by Wsy at 2016/8/5 17:19:17
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Dependency;

namespace Petite.Core.Authorization
{
    /// <summary>
    /// 定义权限的主要接口
    /// </summary>
    public abstract class AuthorizationProvider:ITransientDependency
    {
        /// <summary>
        /// 此方法在应用程序启动时调用
        /// </summary>
        /// <param name="context">权限定义上下文</param>
        public abstract void SetPermissions(IPermissionDefinitionContext context);
    }
}
