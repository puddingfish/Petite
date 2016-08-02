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
using System.Text;
using System.Threading.Tasks;
using Petite.Core.Dependency;
using Petite.Core.Domain.Entities.Localization;

namespace Petite.Core.Localization
{
    public class LanguageManager : ILanguageManager, ITransientDependency
    {
        #region fields

        public LanguageInfo CurrentLanguage { get { return GetCurrentLanguage(); } }

        #endregion

        #region ctors

        public LanguageManager()
        {

        }

        #endregion

        #region methods

        private LanguageInfo GetCurrentLanguage()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<LanguageInfo> GetLanguages()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
