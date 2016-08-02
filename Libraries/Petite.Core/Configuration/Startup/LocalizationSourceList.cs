//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationSourceList 
//        Description :    
//        Created by Wsy at 2016/8/2 17:03:13
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Localization.Sources;

namespace Petite.Core.Configuration.Startup
{
    internal class LocalizationSourceList:List<ILocalizationSource>,ILocalizationSourceList
    {
        public IList<LocalizationSourceExtensionInfo> Extensions { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public LocalizationSourceList()
        {
            Extensions = new List<LocalizationSourceExtensionInfo>();
        }
    }
}
