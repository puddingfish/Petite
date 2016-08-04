//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LanguageManager 
//        Description :    
//        Created by Wsy at 2016/7/27 16:47:03
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Petite.Core.Dependency;
using Petite.Core.Domain.Entities.Localization;

namespace Petite.Core.Localization
{
    public class LanguageManager : ILanguageManager, ITransientDependency
    {
        #region fields

        public LanguageInfo CurrentLanguage { get { return GetCurrentLanguage(); } }

        private readonly ILanguageProvider _languageProvider;

        #endregion

        #region ctors

        public LanguageManager(ILanguageProvider languageProvider)
        {
            _languageProvider = languageProvider;
        }

        #endregion

        #region methods

        private LanguageInfo GetCurrentLanguage()
        {
            var languages = _languageProvider.GetLanguages();
            if(languages.Count<=0)
            {
                throw new Exception("未定义任何语言");
            }

            //按照当前culture精确查找
            var currentCultureName = Thread.CurrentThread.CurrentUICulture.Name;
            var currentLanguage = languages.FirstOrDefault(l => l.Name == currentCultureName);
            if(currentLanguage!=null)
            {
                return currentLanguage;
            }

            //精确查找不到时，查找最匹配的语言
            currentLanguage = languages.FirstOrDefault(l => currentCultureName.StartsWith(l.Name));
            if(currentLanguage!=null)
            {
                return currentLanguage;
            }

            //如果还未匹配到，则尝试获取默认语言
            currentLanguage = languages.FirstOrDefault(l => l.IsDefault);
            if(currentLanguage!=null)
            {
                return currentLanguage;
            }

            //返回第一个语言
            return languages[0];

        }

        public IReadOnlyList<LanguageInfo> GetLanguages()
        {
            return _languageProvider.GetLanguages();
        }

        #endregion
    }
}
