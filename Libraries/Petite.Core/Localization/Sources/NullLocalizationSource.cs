//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :NullLocalizationSource 
//        Description :    
//        Created by Wsy at 2016/8/4 15:55:39
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using System.Globalization;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;

namespace Petite.Core.Localization.Sources
{
    internal class NullLocalizationSource:ILocalizationSource
    {
        /// <summary>
        /// 单例模式.
        /// </summary>
        public static NullLocalizationSource Instance { get { return SingletonInstance; } }
        private static readonly NullLocalizationSource SingletonInstance = new NullLocalizationSource();

        public string Name { get { return null; } }

        private readonly IReadOnlyList<LocalizedString> _emptyStringArray = new LocalizedString[0];

        private NullLocalizationSource()
        {

        }

        public void Initialize(ILocalizationConfiguration configuration, IIocResolver iocResolver)
        {

        }

        public string GetString(string name)
        {
            return name;
        }

        public string GetString(string name, CultureInfo culture)
        {
            return name;
        }

        public string GetStringOrNull(string name, bool tryDefaults = true)
        {
            return null;
        }

        public string GetStringOrNull(string name, CultureInfo culture, bool tryDefaults = true)
        {
            return null;
        }

        public IReadOnlyList<LocalizedString> GetAllStrings(bool includeDefaults = true)
        {
            return _emptyStringArray;
        }

        public IReadOnlyList<LocalizedString> GetAllStrings(CultureInfo culture, bool includeDefaults = true)
        {
            return _emptyStringArray;
        }
    }
}
