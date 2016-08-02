//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizationSourceList 
//        Description :    
//        Created by Wsy at 2016/7/27 17:00:35
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Localization.Sources;

namespace Petite.Core.Configuration.Startup
{
    public interface ILocalizationSourceList:IList<ILocalizationSource>
    {
        IList<LocalizationSourceExtensionInfo> Extensions { get; }
    }
}
