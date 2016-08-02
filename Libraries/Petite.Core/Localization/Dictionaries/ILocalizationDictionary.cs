//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizationDictionary 
//        Description :    
//        Created by Wsy at 2016/8/2 11:42:14
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using System.Globalization;


namespace Petite.Core.Localization.Dictionaries
{
    public interface ILocalizationDictionary
    {
        /// <summary>
        /// 字典对应的culture
        /// </summary>
        CultureInfo CultureInfo { get; }

        /// <summary>
        /// 根据给定的name设置或获取一个string
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string this[string name] { get; set; }

        /// <summary>
        /// 根据给定的name获取一个<see cref="LocalizedString"/> 
        /// </summary>
        /// <param name="name">name(key)</param>
        /// <returns>localizedstring 或 null</returns>
        LocalizedString GetOrNull(string name);

        /// <summary>
        /// 获取所有字符串
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<LocalizedString> GetAllStrings();
    }
}
