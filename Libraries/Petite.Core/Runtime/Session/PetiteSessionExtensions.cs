//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PetiteSessionExtension 
//        Description :    
//        Created by Wsy at 2016/7/16 16:50:21
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Runtime.Session
{
    /// <summary>
    /// 对<see cref="IPetiteSession"/> 的扩展方法
    /// </summary>
    public static class PetiteSessionExtensions
    {
        /// <summary>
        /// 获取用户ID
        /// 如果 <see cref="IPetiteSession.UserId"/>为Null则抛出异常.
        /// </summary>
        /// <param name="session">Session对象.</param>
        /// <returns>当前用户ID</returns>
        public static long GetUserId(this IPetiteSession session)
        {
            if (!session.UserId.HasValue)
            {
                throw new Exception("Session.UserId 为null，可能用户还未登录.");
            }

            return session.UserId.Value;
        }

        /// <summary>
        /// 获取当前租户ID
        /// 如果 <see cref="IPetiteSession.TenantId"/> 为null则抛出异常.
        /// </summary>
        /// <param name="session">Session 对象.</param>
        /// <returns>当前租户ID.</returns>
        /// <exception cref="AbpException"></exception>
        public static int GetTenantId(this IPetiteSession session)
        {
            if (!session.TenantId.HasValue)
            {
                throw new Exception("Session.TenantId 为null! 可能原因：没有用户登录或当前登录的用户为Host（Host用户 TenantId为null）");
            }

            return session.TenantId.Value;
        }
    }
}
