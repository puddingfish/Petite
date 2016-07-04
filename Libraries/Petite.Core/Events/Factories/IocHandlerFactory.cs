//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IocHandlerFactory 
//        Description :    
//        Created by Wsy at 2016/7/4 17:45:13
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using Castle.Windsor;
using Petite.Core.Events.Handlers;

namespace Petite.Core.Events.Factories
{
    public class IocHandlerFactory:IEventHandlerFactory
    {
        #region fields

        public Type HandlerType { get; private set; }

        private readonly IWindsorContainer _iocContainer;

        #endregion

        #region ctors

        public IocHandlerFactory(IWindsorContainer iocContainer,Type handlerType)
        {
            HandlerType = handlerType;
            _iocContainer = iocContainer;
        }

        #endregion

        #region methods

        /// <summary>
        /// 获得事件处理器
        /// </summary>
        /// <returns></returns>
        public IEventHandler GetHandler()
        {
            return (IEventHandler)_iocContainer.Resolve(HandlerType);
        }

        /// <summary>
        /// 释放事件器
        /// </summary>
        /// <param name="handler"></param>
        public void ReleaseHandler(IEventHandler handler)
        {
            _iocContainer.Release(handler);
        }

        #endregion
    }
}
