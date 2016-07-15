//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :MultiTenancySides 
//        Description :    
//        Created by Wsy at 2016/7/15 17:48:52
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Domain.Entities.MultiTenancy
{
    /// <summary>
    /// 多租户程序中表示多租户的性质
    /// </summary>
    [Flags]
    public enum MultiTenancySides
    {
        /// <summary>
        /// 租户
        /// </summary>
        Tenant=1,

        /// <summary>
        /// 平台所有者
        /// </summary>
        Host=2
    }
}
