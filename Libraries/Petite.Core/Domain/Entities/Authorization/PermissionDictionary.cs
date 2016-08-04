//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PermissionDictionary 
//        Description :    
//        Created by Wsy at 2016/8/4 17:33:18
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;


namespace Petite.Core.Domain.Entities.Authorization
{
    internal class PermissionDictionary:Dictionary<string,Permission>
    {
        public void AddAllPermissions()
        {
            foreach (var permission in Values.ToList())
            {
                AddPermissionRecursively(permission);
            }
        }

        private void AddPermissionRecursively(Permission permission)
        {
            //防止重复添加.
            Permission existingPermission;
            if (TryGetValue(permission.Name, out existingPermission))
            {
                if (existingPermission != permission)
                {
                    throw new Exception("检测到重复的权限： " + permission.Name);
                }
            }
            else
            {
                this[permission.Name] = permission;
            }

            //递归添加子权限
            foreach (var childPermission in permission.Children)
            {
                AddPermissionRecursively(childPermission);
            }
        }
    }
}
