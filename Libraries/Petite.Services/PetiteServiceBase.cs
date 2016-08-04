//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PetiteServiceBase 
//        Description :    
//        Created by Wsy at 2016/7/16 17:23:38
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Globalization;
using Castle.Core.Logging;
using Petite.Core.Domain.Uow;
using Petite.Core.Localization;
using Petite.Core.Localization.Sources;

namespace Petite.Services
{
    /// <summary>
    /// Service的基类，提供一些共同的属性或方法
    /// </summary>
    public abstract class PetiteServiceBase
    {
        #region fields

        private IUnitOfWorkManager _unitOfWorkManager;

        public ILocalizationManager LocalizationManager { protected get; set; }

        protected string LocalizationSourceName { get; set; }


        public IUnitOfWorkManager UnitOfWorkManager
        {
            get
            {
                if(_unitOfWorkManager==null)
                {
                    throw new Exception("使用UnitOfWorkManager前必须先初始化！");
                }
                return _unitOfWorkManager;
            }
        }

        /// <summary>
        /// 当前UOW
        /// </summary>
        protected IActiveUnitOfWork CurrentUnitOfWork { get { return UnitOfWorkManager.Current; } }

        /// <summary>
        /// 日志
        /// </summary>
        public ILogger Logger { protected get; set; }

        private ILocalizationSource _localizationSource;
        protected ILocalizationSource LocalizationSource
        {
            get
            {
                if (LocalizationSourceName == null)
                {
                    throw new Exception("获取一个资源前必须先设置 LocalizationSourceName ");
                }

                if (_localizationSource == null || _localizationSource.Name != LocalizationSourceName)
                {
                    _localizationSource = LocalizationManager.GetSource(LocalizationSourceName);
                }

                return _localizationSource;
            }
        }

        #endregion

        #region ctors

        public PetiteServiceBase()
        {
            Logger = NullLogger.Instance;
            LocalizationManager = NullLocalizationManager.Instance;
        }

        #endregion

        #region methods

        /// <summary>
        /// 根据给定的name及当前语言获取本地化字符串.
        /// </summary>
        /// <param name="name">资源名称(key)</param>
        /// <returns>本地化字符串</returns>
        protected virtual string L(string name)
        {
            return LocalizationSource.GetString(name);
        }

        /// <summary>
        /// 根据给定名称及当前语言获取格式化的本地化字符串
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="args">格式化参数</param>
        /// <returns>本地化字符串</returns>
        protected string L(string name, params object[] args)
        {
            return LocalizationSource.GetString(name, args);
        }

        /// <summary>
        /// 根据给定的名称获取指定culture的本地化字符串
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="culture">culture信息</param>
        /// <returns>本地化字符串</returns>
        protected virtual string L(string name, CultureInfo culture)
        {
            return LocalizationSource.GetString(name, culture);
        }

        /// <summary>
        /// 根据给定的名称获取指定culture的格式化本地字符串.
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="culture">culture信息</param>
        /// <param name="args">格式化字符串</param>
        /// <returns>本地化字符串</returns>
        protected string L(string name, CultureInfo culture, params object[] args)
        {
            return LocalizationSource.GetString(name, culture, args);
        }

        #endregion
    }
}
