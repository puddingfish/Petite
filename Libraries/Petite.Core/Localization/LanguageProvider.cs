//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LanguageProvider 
//        Description :    
//        Created by Wsy at 2016/8/3 17:15:58
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using System.Collections.Immutable;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;
using Petite.Core.Domain.Entities.Localization;

namespace Petite.Core.Localization
{
    public class LanguageProvider:ILanguageProvider,ITransientDependency
    {
        private readonly ILocalizationConfiguration _configuration;

        public LanguageProvider(ILocalizationConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IReadOnlyList<LanguageInfo> GetLanguages()
        {
            return _configuration.Languages.ToImmutableList();
        }
    }
}
