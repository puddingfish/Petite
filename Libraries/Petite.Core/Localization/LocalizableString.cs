//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizableString 
//        Description :    
//        Created by Wsy at 2016/8/4 17:20:19
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Globalization;


namespace Petite.Core.Localization
{
    [Serializable]
    public class LocalizableString:ILocalizableString
    {
        /// <summary>
        /// 本地化资源名称
        /// </summary>
        public virtual string SourceName { get; private set; }

        /// <summary>
        /// 需要本地化的字符串名称
        /// </summary>
        public virtual string Name { get; private set; }

        /// <summary>
        /// 序列化所需
        /// </summary>
        private LocalizableString()
        {

        }

        /// <param name="name">本地化资源名称</param>
        /// <param name="sourceName">需要本地化的字符串名称</param>
        public LocalizableString(string name, string sourceName)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (sourceName == null)
            {
                throw new ArgumentNullException("sourceName");
            }

            Name = name;
            SourceName = sourceName;
        }

        public string Localize(ILocalizationManager manager)
        {
            return manager.GetSource(SourceName).GetString(Name);
        }

        public string Localize(ILocalizationManager manager, CultureInfo culture)
        {
            return manager.GetSource(SourceName).GetString(Name,culture);
        }

        public override string ToString()
        {
            return string.Format("[本地化字符串: {0}, {1}]", Name, SourceName);
        }
    }
}
