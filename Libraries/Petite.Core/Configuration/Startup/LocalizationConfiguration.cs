//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationConfiguration 
//        Description :    
//        Created by Wsy at 2016/8/2 17:02:04
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Domain.Entities.Localization;

namespace Petite.Core.Configuration.Startup
{
    public class LocalizationConfiguration:ILocalizationConfiguration
    {
        /// <inheritdoc/>
        public IList<LanguageInfo> Languages { get; private set; }

        /// <inheritdoc/>
        public ILocalizationSourceList Sources { get; private set; }

        /// <inheritdoc/>
        public bool IsEnabled { get; set; }

        /// <inheritdoc/>
        public bool ReturnGivenTextIfNotFound { get; set; }

        /// <inheritdoc/>
        public bool WrapGivenTextIfNotFound { get; set; }

        public LocalizationConfiguration()
        {
            Languages = new List<LanguageInfo>();
            Sources = new LocalizationSourceList();

            IsEnabled = true;
            ReturnGivenTextIfNotFound = true;
            WrapGivenTextIfNotFound = true;
        }
    }
}
