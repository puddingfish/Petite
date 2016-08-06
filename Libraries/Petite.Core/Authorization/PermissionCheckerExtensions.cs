//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PermissionCheckerExtensions 
//        Description :    
//        Created by Wsy at 2016/8/6 17:37:27
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Petite.Data.Threading;

namespace Petite.Core.Authorization
{
    /// <summary>
    /// <see cref="IPermissionChecker"/>扩展方法类
    /// </summary>
    public static class PermissionCheckerExtensions
    {
        /// <summary>
        /// 检测当前用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="permissionName">权限名称</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, string permissionName)
        {
            return AsyncHelper.RunSync(() => permissionChecker.IsGrantedAsync(permissionName));
        }

        /// <summary>
        /// 检测某个用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="userId">用户ID</param>
        /// <param name="permissionName">权限名称</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, long userId, string permissionName)
        {
            return AsyncHelper.RunSync(() => permissionChecker.IsGrantedAsync(userId, permissionName));
        }

        /// <summary>
        /// 检测某个用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="userId">用户ID</param>
        /// <param name="requiresAll">True:获取所以已授权的权限. False:获取一个或多个.</param>
        /// <param name="permissionNames">权限名称</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, long userId, bool requiresAll, params string[] permissionNames)
        {
            return AsyncHelper.RunSync(() => IsGrantedAsync(permissionChecker, userId, requiresAll, permissionNames));
        }

        /// <summary>
        /// 检测某个用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="userId">用户ID</param>
        /// <param name="requiresAll">True:获取所以已授权的权限. False:获取一个或多个.</param>
        /// <param name="permissionNames">权限名称</param>
        public static async Task<bool> IsGrantedAsync(this IPermissionChecker permissionChecker, long userId, bool requiresAll, params string[] permissionNames)
        {
            if (permissionNames.IsNullOrEmpty())
            {
                return true;
            }

            if (requiresAll)
            {
                foreach (var permissionName in permissionNames)
                {
                    if (!(await permissionChecker.IsGrantedAsync(userId, permissionName)))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                foreach (var permissionName in permissionNames)
                {
                    if (await permissionChecker.IsGrantedAsync(userId, permissionName))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 检测当前用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requiresAll">True:获取所以已授权的权限. False:获取一个或多个.</param>
        /// <param name="permissionNames">权限名称</param>
        public static bool IsGranted(this IPermissionChecker permissionChecker, bool requiresAll, params string[] permissionNames)
        {
            return AsyncHelper.RunSync(() => IsGrantedAsync(permissionChecker, requiresAll, permissionNames));
        }

        /// <summary>
        /// 检测当前用户是否被授予某个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requiresAll">True:获取所以已授权的权限. False:获取一个或多个.</param>
        /// <param name="permissionNames">权限名称</param>
        public static async Task<bool> IsGrantedAsync(this IPermissionChecker permissionChecker, bool requiresAll, params string[] permissionNames)
        {
            if (permissionNames.IsNullOrEmpty())
            {
                return true;
            }

            if (requiresAll)
            {
                foreach (var permissionName in permissionNames)
                {
                    if (!(await permissionChecker.IsGrantedAsync(permissionName)))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                foreach (var permissionName in permissionNames)
                {
                    if (await permissionChecker.IsGrantedAsync(permissionName))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// 授予当前用户某(几)个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="permissionNames">需要授予的权限</param>
        public static void Authorize(this IPermissionChecker permissionChecker, params string[] permissionNames)
        {
            Authorize(permissionChecker, false, permissionNames);
        }

        /// <summary>
        /// 授予当前用户某(几)个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requireAll">
        /// True:所有的 <see cref="permissionNames"/>将被授予.
        /// False:授予至少一个 <see cref="permissionNames"/>.
        /// </param>
        /// <param name="permissionNames">需要授予的权限</param>
        public static void Authorize(this IPermissionChecker permissionChecker, bool requireAll, params string[] permissionNames)
        {
            AsyncHelper.RunSync(() => AuthorizeAsync(permissionChecker, requireAll, permissionNames));
        }

        /// <summary>
        /// 授予当前用户某(几)个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="permissionNames">需要授予的权限</param>
        public static Task AuthorizeAsync(this IPermissionChecker permissionChecker, params string[] permissionNames)
        {
            return AuthorizeAsync(permissionChecker, false, permissionNames);
        }

        /// <summary>
        /// 授予当前用户某(几)个权限
        /// </summary>
        /// <param name="permissionChecker">Permission checker</param>
        /// <param name="requireAll">
        /// True:所有的 <see cref="permissionNames"/>将被授予.
        /// False:授予至少一个 <see cref="permissionNames"/>.
        /// </param>
        /// <param name="permissionNames">需要授予的权限</param>
        public static async Task AuthorizeAsync(this IPermissionChecker permissionChecker, bool requireAll, params string[] permissionNames)
        {
            if (await IsGrantedAsync(permissionChecker, requireAll, permissionNames))
            {
                return;
            }

            if (requireAll)
            {
                throw new Exception(
                    "未授予必须的权限. 以下权限必须全部授予: " +
                    string.Join(", ", permissionNames)
                    );
            }
            else
            {
                throw new Exception(
                    "必须的权限未被授予. 以下权限至少要被授予一个: " +
                    string.Join(", ", permissionNames)
                    );
            }
        }
    }
}
