//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizationManager 
//        Description :    
//        Created by Wsy at 2016/8/4 15:39:02
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Localization.Sources;

namespace Petite.Core.Localization
{
    public interface ILocalizationManager
    {
        /// <summary>
        /// 通过给定名称获取本地化资源
        /// </summary>
        /// <param name="name">本地资源名称</param>
        /// <returns>本地资源</returns>
        ILocalizationSource GetSource(string name);

        /// <summary>
        /// 获取所有的本地资源
        /// </summary>
        /// <returns>资源集合</returns>
        IReadOnlyList<ILocalizationSource> GetAllSources();
    }
}
