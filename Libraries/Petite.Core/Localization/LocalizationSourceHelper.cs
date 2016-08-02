//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationSourceHelper 
//        Description :    
//        Created by Wsy at 2016/8/2 16:58:59
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petite.Core.Configuration.Startup;

namespace Petite.Core.Localization
{
    public class LocalizationSourceHelper
    {
        public static string ReturnGivenNameOrThrowException(ILocalizationConfiguration configuration, string sourceName, string name)
        {
            var exceptionMessage = string.Format(
                "未在资源文件 '{0}' 中找到 '{1}'!",
                sourceName, name
                );

            if (!configuration.ReturnGivenTextIfNotFound)
            {
                throw new Exception(exceptionMessage);
            }            

            return configuration.WrapGivenTextIfNotFound
                ? string.Format("[{0}]", name)
                : name;
        }
    }
}
