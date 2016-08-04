//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PermissionDefinitionContextBase 
//        Description :    
//        Created by Wsy at 2016/8/4 17:55:40
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using Petite.Core.Domain.Entities.Authorization;
using Petite.Core.Domain.Entities.MultiTenancy;
using Petite.Core.Extension;
using Petite.Core.Localization;

namespace Petite.Core.Authorization
{
    internal abstract class PermissionDefinitionContextBase:IPermissionDefinitionContext
    {
        protected readonly PermissionDictionary Permissions;

        protected PermissionDefinitionContextBase()
        {
            Permissions = new PermissionDictionary();
        }

        public Permission CreatePermission(
          string name,
            ILocalizableString displayName = null,
            bool isGrantedByDefault = false,
            ILocalizableString description = null,
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant)
        {
            if (Permissions.ContainsKey(name))
            {
                throw new Exception("检测到已存在此名称的权限: " + name);
            }

            var permission = new Permission(name, displayName, isGrantedByDefault, description, multiTenancySides);
            Permissions[permission.Name] = permission;
            return permission;
        }

        public Permission GetPermissionOrNull(string name)
        {
            return Permissions.GetOrDefault(name);
        }
    }
}
