﻿//======================================================================  
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
        /// Used to set languages available for this application.
        /// </summary>
        IList<LanguageInfo> Languages { get; }

        /// <summary>
        /// List of localization sources.
        /// </summary>
        ILocalizationSourceList Sources { get; }

        /// <summary>
        /// Used to enable/disable localization system.
        /// Default: true.
        /// </summary>
        bool IsEnabled { get; set; }

        /// <summary>
        /// If this is set to true, the given text (name) is returned
        /// if not found in the localization source. That prevent exceptions if
        /// given name is not defined in the localization sources.
        /// Also writes a warning log.
        /// Default: true.
        /// </summary>
        bool ReturnGivenTextIfNotFound { get; set; }

        /// <summary>
        /// It returns the given text by wrapping with [ and ] chars
        /// if not found in the localization source.
        /// This is considered only if <see cref="ReturnGivenTextIfNotFound"/> is true.
        /// Default: true.
        /// </summary>
        bool WrapGivenTextIfNotFound { get; set; }
    }
}
