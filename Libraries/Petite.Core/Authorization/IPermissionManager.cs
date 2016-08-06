//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IPermissionManager 
//        Description :    
//        Created by Wsy at 2016/8/5 17:24:41
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Domain.Entities.Authorization;
using Petite.Core.Domain.Entities.MultiTenancy;

namespace Petite.Core.Authorization
{
    public interface IPermissionManager
    {
        /// <summary>
        /// 根据给定的name获取 <see cref="Permission"/> 或未找到时抛出异常
        /// </summary>
        /// <param name="name">权限名称</param>
        Permission GetPermission(string name);
        
        /// <summary>
        /// 根据给定的name获取 <see cref="Permission"/> 或未找到时返回null
        /// </summary>
        /// <param name="name">权限名称</param>
        Permission GetPermissionOrNull(string name);

        /// <summary>
        /// 获取所有权限.
        /// </summary>
        /// <param name="tenancyFilter">是否启用租户过滤.</param>
        IReadOnlyList<Permission> GetAllPermissions(bool tenancyFilter = true);

        /// <summary>
        /// 获取所有权限.
        /// </summary>
        /// <param name="multiTenancySides">多租户过滤</param>
        IReadOnlyList<Permission> GetAllPermissions(MultiTenancySides multiTenancySides);
    }
}
