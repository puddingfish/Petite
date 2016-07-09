//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IConventionalRegistrationContext 
//        Description :    
//        Created by Wsy at 2016/7/8 17:41:31
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Petite.Core.Configuration;

namespace Petite.Core.Dependency
{
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        /// Gets the registering Assembly.
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// Reference to the IOC Container to register types.
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// Registration configuration.
        /// </summary>
        ConventionalRegistrationConfig Config { get; }
    }
}
