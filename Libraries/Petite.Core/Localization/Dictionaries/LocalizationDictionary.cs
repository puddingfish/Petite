//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationDictionary 
//        Description :    
//        Created by Wsy at 2016/8/2 14:27:20
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;


namespace Petite.Core.Localization.Dictionaries
{
    public class LocalizationDictionary:ILocalizationDictionary,IEnumerable<LocalizedString>
    {
        #region fields

        public CultureInfo CultureInfo { get; private set; }               

        private readonly Dictionary<string, LocalizedString> _dictionary;

        public virtual string this[string name]
        {
            get
            {
                var localizedString = GetOrNull(name);
                return localizedString == null ? null : localizedString.Value;
            }
            set
            {
                _dictionary[name] = new LocalizedString(name, value, CultureInfo);
            }
        }

        #endregion

        #region ctors

        public LocalizationDictionary(CultureInfo cultureInfo)
        {
            CultureInfo = cultureInfo;
            _dictionary = new Dictionary<string, LocalizedString>();
        }

        #endregion

        #region methods

        /// <inheritdoc/>
        public virtual LocalizedString GetOrNull(string name)
        {
            LocalizedString localizedString;
            return _dictionary.TryGetValue(name, out localizedString) ? localizedString : null;
        }

        /// <inheritdoc/>
        public IReadOnlyList<LocalizedString> GetAllStrings()
        {
            return _dictionary.Values.ToImmutableList();
        }

        /// <inheritdoc/>
        public virtual IEnumerator<LocalizedString> GetEnumerator()
        {
            return GetAllStrings().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAllStrings().GetEnumerator();
        }

        protected bool Contains(string name)
        {
            return _dictionary.ContainsKey(name);
        }

        #endregion
    }
}
