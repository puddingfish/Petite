//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IDictionaryBasedLocalizationSource 
//        Description :    
//        Created by Wsy at 2016/8/2 16:10:10
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Localization.Sources;

namespace Petite.Core.Localization.Dictionaries
{
    public interface IDictionaryBasedLocalizationSource : ILocalizationSource
    {
        /// <summary>
        /// 获取一个字典Provider.
        /// </summary>
        ILocalizationDictionaryProvider DictionaryProvider { get; }

        /// <summary>
        /// 通过给定字典扩展资源
        /// </summary>
        /// <param name="dictionary">字典</param>
        void Extend(ILocalizationDictionary dictionary);
    }
}
