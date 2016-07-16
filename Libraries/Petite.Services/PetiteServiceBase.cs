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
using Castle.Core.Logging;
using Petite.Core.Domain.Uow;

namespace Petite.Services
{
    /// <summary>
    /// Service的基类，提供一些共同的属性或方法
    /// </summary>
    public abstract class PetiteServiceBase
    {
        #region fields

        private IUnitOfWorkManager _unitOfWorkManager;

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

        #endregion

        #region ctors

        public PetiteServiceBase()
        {
            Logger = NullLogger.Instance;
        }

        #endregion
    }
}
