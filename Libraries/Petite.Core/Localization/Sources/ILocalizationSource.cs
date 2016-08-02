//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizationSource 
//        Description :    
//        Created by Wsy at 2016/8/1 16:28:39
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using System.Globalization;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;

namespace Petite.Core.Localization.Sources
{
    public interface ILocalizationSource
    {
        /// <summary>
        /// 当前资源名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 首次使用时初始化
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="iocResolver"></param>
        void Initialize(ILocalizationConfiguration configuration, IIocResolver iocResolver);

        /// <summary>
        /// 根据给定的name获取当前语言的本地显示字符串
        /// 默认使用当前culture
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetString(string name);

        /// <summary>
        /// 根据给定的name及culture获取本地显示字符串
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        string GetString(string name, CultureInfo culture);

        /// <summary>
        /// 根据给定的name获取当前语言对应的本地显示字符串
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="tryDefaults">True:如果在当前设定的culture没有找到对应记录，则返回null</param>
        /// <returns></returns>
        string GetStringOrNull(string name, bool tryDefaults = true);

        /// <summary>
        /// 获取指定的culture对应的本地显示字符串
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="culture">指定的culture</param>
        /// <param name="tryDefaults">True:如果在当前设定的culture没有找到对应记录，则返回null</param>
        /// <returns></returns>
        string GetStringOrNull(string name, CultureInfo culture, bool tryDefaults = true);

        /// <summary>
        /// 根据当前语言获取所有string
        /// </summary>
        /// <param name="includeDefaults"></param>
        /// <returns></returns>
        IReadOnlyList<LocalizedString> GetAllStrings(bool includeDefaults = true);

        /// <summary>
        /// 根据指定culture获取所有string
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="includeDefaults"></param>
        /// <returns></returns>
        IReadOnlyList<LocalizedString> GetAllStrings(CultureInfo culture, bool includeDefaults = true);
    }
}
