//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ConventionalRegistrationConfig 
//        Description :    
//        Created by Wsy at 2016/7/9 10:03:06
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petite.Core.Configuration
{
    public class ConventionalRegistrationConfig : DictionayBasedConfig
    {
        /// <summary>
        /// Install all <see cref="IInterceptor"/> implementations automatically or not.
        /// Default: true. 
        /// </summary>
        public bool InstallInstallers { get; set; }

        /// <summary>
        /// Creates a new <see cref="ConventionalRegistrationConfig"/> object.
        /// </summary>
        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}
