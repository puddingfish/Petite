//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationExtensionInfo 
//        Description :    
//        Created by Wsy at 2016/8/2 11:19:32
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Localization.Dictionaries;

namespace Petite.Core.Localization.Sources
{
    public class LocalizationSourceExtensionInfo
    {
        /// <summary>
        /// 资源名称
        /// </summary>
        public string SourceName { get; private set; }

        /// <summary>
        /// 扩展字典
        /// </summary>
        public ILocalizationDictionaryProvider DictionaryProvider { get; private set; }

        /// <summary>
        /// <see cref="LocalizationSourceExtensionInfo"/> 构造函数
        /// </summary>
        /// <param name="sourceName">资源名称</param>
        /// <param name="dictionaryProvider">扩展字典集合</param>
        public LocalizationSourceExtensionInfo(string sourceName, ILocalizationDictionaryProvider dictionaryProvider)
        {
            SourceName = sourceName;
            DictionaryProvider = dictionaryProvider;
        }
    }
}
