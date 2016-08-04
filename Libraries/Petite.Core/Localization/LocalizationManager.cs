//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizationManager 
//        Description :    
//        Created by Wsy at 2016/8/4 15:41:14
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Castle.Core.Logging;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;
using Petite.Core.Localization.Dictionaries;
using Petite.Core.Localization.Sources;

namespace Petite.Core.Localization
{
    public class LocalizationManager:ILocalizationManager
    {
        #region fields

        public ILogger Logger { get; set; }
        private readonly ILanguageManager _languageManager;
        private readonly ILocalizationConfiguration _configuration;
        private readonly IIocResolver _iocResolver;
        private readonly IDictionary<string, ILocalizationSource> _sources;

        #endregion

        #region ctors

        public LocalizationManager(ILanguageManager languageManager,
            ILocalizationConfiguration configuration,
            IIocResolver iocResolver)
        {
            _languageManager = languageManager;
            _configuration = configuration;
            _iocResolver = iocResolver;
            _sources = new Dictionary<string, ILocalizationSource>();
        }

        #endregion

        #region methods

        /// <summary>
        /// 初始化资源
        /// </summary>
        public void Initialize()
        {
            InitializeSources();
        }

        /// <summary>
        ///
        /// </summary>
        private void InitializeSources()
        {
            if (!_configuration.IsEnabled)
            {
                Logger.Debug("本地化设置为禁用.");
                return;
            }

            Logger.Debug(string.Format("正在初始化本地资源： {0} .", _configuration.Sources.Count));
            foreach (var source in _configuration.Sources)
            {
                if (_sources.ContainsKey(source.Name))
                {
                    throw new Exception("有多个名为: " + source.Name + "的资源! 资源名称必须唯一!");
                }

                _sources[source.Name] = source;
                source.Initialize(_configuration, _iocResolver);

                //扩展字典
                if (source is IDictionaryBasedLocalizationSource)
                {
                    var dictionaryBasedSource = source as IDictionaryBasedLocalizationSource;
                    var extensions = _configuration.Sources.Extensions.Where(e => e.SourceName == source.Name).ToList();
                    foreach (var extension in extensions)
                    {
                        extension.DictionaryProvider.Initialize(source.Name);
                        foreach (var extensionDictionary in extension.DictionaryProvider.Dictionaries.Values)
                        {
                            dictionaryBasedSource.Extend(extensionDictionary);
                        }
                    }
                }

                Logger.Debug("初始化完成: " + source.Name);
            }
        }

        /// <summary>
        /// 根据给定名称获取本地化资源
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <returns>本地化资源</returns>
        public ILocalizationSource GetSource(string name)
        {
            if (!_configuration.IsEnabled)
            {
                return NullLocalizationSource.Instance;
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            ILocalizationSource source;
            if (!_sources.TryGetValue(name, out source))
            {
                throw new Exception("找不到资源: " + name);
            }

            return source;
        }

        /// <summary>
        /// 获取所有本地化资源
        /// </summary>
        /// <returns>资源集合</returns>
        public IReadOnlyList<ILocalizationSource> GetAllSources()
        {
            return _sources.Values.ToImmutableList();
        }

        #endregion
    }
}
