//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IPermissionChecker 
//        Description :    
//        Created by Wsy at 2016/8/6 17:25:01
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Threading.Tasks;


namespace Petite.Core.Authorization
{
    public interface IPermissionChecker
    {
        /// <summary>
        /// 检测当前用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionName">要检测的权限名称</param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(string permissionName);

        /// <summary>
        /// 检测某个用户是否被授予某个权限
        /// </summary>
        /// <param name="userId">要检测的用户ID</param>
        /// <param name="permissionName">要检测的权限名称</param>
        /// <returns></returns>
        Task<bool> IsGrantedAsync(long userId, string permissionName);
    }
}
