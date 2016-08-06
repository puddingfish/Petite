//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :NullPermissionChecker 
//        Description :    
//        Created by Wsy at 2016/8/6 17:30:09
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Threading.Tasks;


namespace Petite.Core.Authorization
{
    /// <summary>
    ///  <see cref="IPermissionChecker"/>空实例模式(默认实现).
    /// </summary>
    public sealed class NullPermissionChecker : IPermissionChecker
    {
        /// <summary>
        /// 单例.
        /// </summary>
        public static NullPermissionChecker Instance { get { return SingletonInstance; } }
        private static readonly NullPermissionChecker SingletonInstance = new NullPermissionChecker();

        public Task<bool> IsGrantedAsync(string permissionName)
        {
            return Task.FromResult(true);
        }

        /// <summary>
        /// 检测某个用户是否被授予某个权限
        /// </summary>
        /// <param name="userId">要检测的用户ID</param>
        /// <param name="permissionName">要检测的权限名称</param>
        /// <returns>如果此用户有被授予此权限,则返回true,否则返回false.</returns>
        public Task<bool> IsGrantedAsync(long userId, string permissionName)
        {
            return Task.FromResult(true);
        }

        private NullPermissionChecker()
        {

        }
    }
}
