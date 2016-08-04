//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :XmlFileLocalizationDictionaryProvider 
//        Description :    
//        Created by Wsy at 2016/8/2 15:30:04
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.IO;


namespace Petite.Core.Localization.Dictionaries.Xml
{
    public class XmlFileLocalizationDictionaryProvider : LocalizationDictionaryProviderBase
    {
        private readonly string _directoryPath;

        /// <summary>
        /// 创建新的<see cref="XmlFileLocalizationDictionaryProvider"/>.
        /// </summary>
        /// <param name="directoryPath">xml文件路径</param>
        public XmlFileLocalizationDictionaryProvider(string directoryPath)
        {
            //if (!Path.IsPathRooted(directoryPath))
            //{
            //    directoryPath = Path.Combine(XmlLocalizationSource.RootDirectoryOfApplication, directoryPath);
            //}

            _directoryPath = directoryPath;
        }

        public override void Initialize(string sourceName)
        {
            var fileNames = Directory.GetFiles(_directoryPath, "*.xml", SearchOption.TopDirectoryOnly);

            foreach (var fileName in fileNames)
            {
                var dictionary = CreateXmlLocalizationDictionary(fileName);
                if (Dictionaries.ContainsKey(dictionary.CultureInfo.Name))
                {
                    throw new Exception(sourceName + " 包含多个 " + dictionary.CultureInfo.Name + " 的字典");
                }

                Dictionaries[dictionary.CultureInfo.Name] = dictionary;

                if (fileName.EndsWith(sourceName + ".xml"))
                {
                    if (DefaultDictionary != null)
                    {
                        throw new Exception("每个资源只能有一个本地化字典: " + sourceName);
                    }

                    DefaultDictionary = dictionary;
                }
            }
        }

        protected virtual XmlLocalizationDictionary CreateXmlLocalizationDictionary(string fileName)
        {
            return XmlLocalizationDictionary.BuildFomFile(fileName);
        }
    }
}
