//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILanguageManager 
//        Description :    
//        Created by Wsy at 2016/7/27 16:43:02
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Petite.Core.Domain.Entities.Localization;

namespace Petite.Core.Localization
{
    public interface ILanguageManager
    {
        /// <summary>
        ///当前语言
        /// </summary>
        LanguageInfo CurrentLanguage { get; }

        /// <summary>
        /// 获取所有配置语言
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}
