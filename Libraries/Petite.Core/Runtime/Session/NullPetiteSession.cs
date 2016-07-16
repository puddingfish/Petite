//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :NullPetiteSession 
//        Description :    
//        Created by Wsy at 2016/7/16 16:56:52
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Domain.Entities.MultiTenancy;

namespace Petite.Core.Runtime.Session
{
    /// <summary>
    /// 实现<see cref="IPetiteSession"/> 的空对象模式
    /// </summary>
    public class NullPetiteSession:IPetiteSession
    {
        private static readonly NullPetiteSession SingletonInstance = new NullPetiteSession();
        public static NullPetiteSession Instance { get { return SingletonInstance; } }

        public long? UserId { get { return null; } }
                public int? TenantId { get { return null; } }

        public MultiTenancySides MultiTenancySide { get { return MultiTenancySides.Tenant; } }

        public NullPetiteSession()
        {

        }
    }
}
