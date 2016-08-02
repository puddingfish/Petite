//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizationDictionaryProvider 
//        Description :    
//        Created by Wsy at 2016/8/2 14:48:52
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;


namespace Petite.Core.Localization.Dictionaries
{
    public interface ILocalizationDictionaryProvider
    {
        ILocalizationDictionary DefaultDictionary { get; }

        IDictionary<string,ILocalizationDictionary> Dictionaries { get; }

        void Initialize(string sourceName);

        void Extend(ILocalizationDictionary dictionary);
    }
}
