//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationDictionaryProviderBase 
//        Description :    
//        Created by Wsy at 2016/8/2 15:09:39
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;


namespace Petite.Core.Localization.Dictionaries
{
    public class LocalizationDictionaryProviderBase : ILocalizationDictionaryProvider
    {
        #region fields

        public string SourceName { get; private set; }

        public ILocalizationDictionary DefaultDictionary { get; protected set; }

        public IDictionary<string,ILocalizationDictionary> Dictionaries { get; private set; }

        #endregion

        #region ctors

        public LocalizationDictionaryProviderBase()
        {
            Dictionaries = new Dictionary<string, ILocalizationDictionary>();
        }

        #endregion

        #region methods

        public void Extend(ILocalizationDictionary dictionary)
        {
            //Add
            ILocalizationDictionary existingDictionary;
            if(!Dictionaries.TryGetValue(dictionary.CultureInfo.Name,out existingDictionary))
            {
                Dictionaries[dictionary.CultureInfo.Name] = dictionary;
                return;
            }
            //Override
            var localizedStrings = dictionary.GetAllStrings();
            foreach (var localizedString in localizedStrings)
            {
                existingDictionary[localizedString.Name] = localizedString.Value;
            }
        }

        public virtual void Initialize(string sourceName)
        {
            SourceName = sourceName;
        }

        #endregion
    }
}
