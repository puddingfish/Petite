//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IAuthorizationConfiguration 
//        Description :    
//        Created by Wsy at 2016/8/5 17:45:44
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Authorization;
using Petite.Core.Extension;

namespace Petite.Core.Configuration.Startup
{
    public interface IAuthorizationConfiguration
    {
        /// <summary>
        /// List of authorization providers.
        /// </summary>
        ITypeList<AuthorizationProvider> Providers { get; }
    }
}
