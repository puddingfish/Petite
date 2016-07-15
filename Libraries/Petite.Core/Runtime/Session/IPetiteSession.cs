//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IPetiteSession 
//        Description :    
//        Created by Wsy at 2016/7/15 17:45:33
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Domain.Entities.MultiTenancy;

namespace Petite.Core.Runtime.Session
{
    /// <summary>
    /// 可供程序使用的session信息
    /// </summary>
    public interface IPetiteSession
    {
        /// <summary>
        /// 当前用户Id或Null
        /// </summary>
        long? UserId { get; }

        /// <summary>
        /// 当前租户Id或Null
        /// </summary>
        int? TenantId { get; }

        /// <summary>
        /// 租户性质（租户或平台所有者）
        /// </summary>
        MultiTenancySides MultiTenancySide { get; }

    }
}
