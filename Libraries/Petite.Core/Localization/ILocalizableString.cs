//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ILocalizableString 
//        Description :    
//        Created by Wsy at 2016/8/4 17:17:54
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Globalization;


namespace Petite.Core.Localization
{
    public interface ILocalizableString
    {
        /// <summary>
        /// 本地化字符串.
        /// </summary>
        /// <param name="manager">本地化管理器</param>
        /// <returns>本地化字符串</returns>
        string Localize(ILocalizationManager manager);

        /// <summary>
        /// 本地化字符串.
        /// </summary>
        /// <param name="manager">本地化管理器</param>
        /// <param name="culture">culture</param>
        /// <returns>本地化字符串</returns>
        string Localize(ILocalizationManager manager, CultureInfo culture);
    }
}
