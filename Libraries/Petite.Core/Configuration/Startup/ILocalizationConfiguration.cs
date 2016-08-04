//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizationConfiguration 
//        Description :    
//        Created by Wsy at 2016/7/27 16:57:42
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Domain.Entities.Localization;

namespace Petite.Core.Configuration.Startup
{
    public interface ILocalizationConfiguration
    {
        /// <summary>
        /// 设置当前程序的可用语言
        /// </summary>
        IList<LanguageInfo> Languages { get; }

        /// <summary>
        /// 本地化资源
        /// </summary>
        ILocalizationSourceList Sources { get; }

        /// <summary>
        /// 设置是否启用本地化系统
        /// Default: true.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// 如果设置为true,在资源文件中未找到将返回给定的text
        /// Default: true.
        /// </summary>
        bool ReturnGivenTextIfNotFound { get; set; }

        /// <summary>
        /// 如果未找到将返回使用[]包裹的给定text
        /// <see cref="ReturnGivenTextIfNotFound"/> 必须设置为true才有效.
        /// Default: true.
        /// </summary>
        bool WrapGivenTextIfNotFound { get; set; }
    }
}
