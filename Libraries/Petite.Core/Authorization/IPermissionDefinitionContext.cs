//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IPermissionDefinitionContext 
//        Description :    
//        Created by Wsy at 2016/8/4 17:48:06
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Domain.Entities.Authorization;
using Petite.Core.Domain.Entities.MultiTenancy;
using Petite.Core.Localization;

namespace Petite.Core.Authorization
{
    public interface IPermissionDefinitionContext
    {
        /// <summary>
        /// 创建一个权限
        /// </summary>
        /// <param name="name">权限名称</param>
        /// <param name="displayName">权限显示名</param>
        /// <param name="isGrantedByDefault">是否默认授予，默认为false</param>
        /// <param name="description">权限描述</param>
        /// <param name="multiTenancySides">租户类型</param>
        /// <returns></returns>
        Permission CreatePermission(
            string name,
            ILocalizableString displayName = null,
            bool isGrantedByDefault = false,
            ILocalizableString description = null,
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant
            );

        /// <summary>
        /// 根据权限名称获取权限，没有则返回null
        /// </summary>
        /// <param name="name">权限名称</param>
        /// <returns>Permission或null</returns>
        Permission GetPermissionOrNull(string name);
    }
}
