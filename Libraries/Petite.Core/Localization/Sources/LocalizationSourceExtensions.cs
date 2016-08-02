//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationSourceExtensions 
//        Description :    
//        Created by Wsy at 2016/8/2 10:54:38
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Globalization;


namespace Petite.Core.Localization.Sources
{
    public static class LocalizationSourceExtensions
    {
        /// <summary>
        /// 获取本地化显示的字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetString(this ILocalizationSource source,string name,params object[] args)
        {
            if(source==null)
            {
                throw new ArgumentNullException("source");
            }
            return string.Format(source.GetString(name), args);
        }

        /// <summary>
        /// 根据给定culture获取对应本地化显示的字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetString(this ILocalizationSource source,string name,CultureInfo culture,params object[] args)
        {
            if(source==null)
            {
                throw new ArgumentNullException("source");
            }
            return string.Format(source.GetString(name, culture), args);
        }
    }
}
