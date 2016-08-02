//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :DictionaryBasedLocalizationSource 
//        Description :    
//        Created by Wsy at 2016/8/2 16:19:19
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Threading;
using Castle.Core.Internal;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;
using Petite.Core.Extension;

namespace Petite.Core.Localization.Dictionaries
{
    public class DictionaryBasedLocalizationSource:IDictionaryBasedLocalizationSource
    {
        /// <summary>
        /// 资源的唯一名称
        /// </summary>
        public string Name { get; private set; }

        public ILocalizationDictionaryProvider DictionaryProvider { get { return _dictionaryProvider; } }

        protected ILocalizationConfiguration LocalizationConfiguration { get; private set; }

        private readonly ILocalizationDictionaryProvider _dictionaryProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="dictionaryProvider"></param>
        public DictionaryBasedLocalizationSource(string name, ILocalizationDictionaryProvider dictionaryProvider)
        {
            if (name.IsNullOrEmpty())
            {
                throw new ArgumentNullException("name");
            }

            Name = name;

            if (dictionaryProvider == null)
            {
                throw new ArgumentNullException("dictionaryProvider");
            }

            _dictionaryProvider = dictionaryProvider;
        }

        /// <inheritdoc/>
        public virtual void Initialize(ILocalizationConfiguration configuration, IIocResolver iocResolver)
        {
            LocalizationConfiguration = configuration;
            DictionaryProvider.Initialize(Name);
        }

        /// <inheritdoc/>
        public string GetString(string name)
        {
            return GetString(name, Thread.CurrentThread.CurrentUICulture);
        }

        /// <inheritdoc/>
        public string GetString(string name, CultureInfo culture)
        {
            var value = GetStringOrNull(name, culture);

            if (value == null)
            {
                return ReturnGivenNameOrThrowException(name);
            }

            return value;
        }

        public string GetStringOrNull(string name, bool tryDefaults = true)
        {
            return GetStringOrNull(name, Thread.CurrentThread.CurrentUICulture, tryDefaults);
        }

        public string GetStringOrNull(string name, CultureInfo culture, bool tryDefaults = true)
        {
            var cultureName = culture.Name;
            var dictionaries = DictionaryProvider.Dictionaries;

            //尝试从原始字典中获取（带国家代码）
            ILocalizationDictionary originalDictionary;
            if (dictionaries.TryGetValue(cultureName, out originalDictionary))
            {
                var strOriginal = originalDictionary.GetOrNull(name);
                if (strOriginal != null)
                {
                    return strOriginal.Value;
                }
            }

            if (!tryDefaults)
            {
                return null;
            }

            //尝试从相同语言字典获取（不带国家代码）
            if (cultureName.Contains("-")) //如: "zh-CN" (length=5)
            {
                ILocalizationDictionary langDictionary;
                if (dictionaries.TryGetValue(GetBaseCultureName(cultureName), out langDictionary))
                {
                    var strLang = langDictionary.GetOrNull(name);
                    if (strLang != null)
                    {
                        return strLang.Value;
                    }
                }
            }

            //尝试从默认语言中获取
            var defaultDictionary = DictionaryProvider.DefaultDictionary;
            if (defaultDictionary == null)
            {
                return null;
            }

            var strDefault = defaultDictionary.GetOrNull(name);
            if (strDefault == null)
            {
                return null;
            }

            return strDefault.Value;
        }

        /// <inheritdoc/>
        public IReadOnlyList<LocalizedString> GetAllStrings(bool includeDefaults = true)
        {
            return GetAllStrings(Thread.CurrentThread.CurrentUICulture, includeDefaults);
        }

        /// <inheritdoc/>
        public IReadOnlyList<LocalizedString> GetAllStrings(CultureInfo culture, bool includeDefaults = true)
        {
            //TODO: Can be optimized (example: if it's already default dictionary, skip overriding)

            var dictionaries = DictionaryProvider.Dictionaries;

            //临时字典
            var allStrings = new Dictionary<string, LocalizedString>();

            if (includeDefaults)
            {
                //给默认字典填充所有字符串
                var defaultDictionary = DictionaryProvider.DefaultDictionary;
                if (defaultDictionary != null)
                {
                    foreach (var defaultDictString in defaultDictionary.GetAllStrings())
                    {
                        allStrings[defaultDictString.Name] = defaultDictString;
                    }
                }

                //基于culture覆盖所有语言对应的字符串
                if (culture.Name.Contains("-"))
                {
                    ILocalizationDictionary langDictionary;
                    if (dictionaries.TryGetValue(GetBaseCultureName(culture.Name), out langDictionary))
                    {
                        foreach (var langString in langDictionary.GetAllStrings())
                        {
                            allStrings[langString.Name] = langString;
                        }
                    }
                }
            }

            //从原始字典中覆盖所有字符串
            ILocalizationDictionary originalDictionary;
            if (dictionaries.TryGetValue(culture.Name, out originalDictionary))
            {
                foreach (var originalLangString in originalDictionary.GetAllStrings())
                {
                    allStrings[originalLangString.Name] = originalLangString;
                }
            }

            return allStrings.Values.ToImmutableList();
        }

        /// <summary>
        /// 使用给定的dictionary扩展资源
        /// </summary>
        /// <param name="dictionary">给定字典</param>
        public virtual void Extend(ILocalizationDictionary dictionary)
        {
            DictionaryProvider.Extend(dictionary);
        }

        protected virtual string ReturnGivenNameOrThrowException(string name)
        {
            return LocalizationSourceHelper.ReturnGivenNameOrThrowException(LocalizationConfiguration, Name, name);
        }

        private static string GetBaseCultureName(string cultureName)
        {
            return cultureName.Contains("-")
                ? cultureName.Left(cultureName.IndexOf("-", StringComparison.InvariantCulture))
                : cultureName;
        }
    }
}
