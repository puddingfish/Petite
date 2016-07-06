//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :TransientEventHandlerFactory 
//        Description :    
//        Created by Wsy at 2016/7/5 13:45:35
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using Petite.Core.Events.Handlers;

namespace Petite.Core.Events.Factories.Internals
{
    /// <summary>
    /// 临时事件处理工厂内部类
    /// </summary>
    /// <typeparam name="THandler"></typeparam>
    internal class TransientEventHandlerFactory<THandler>:IEventHandlerFactory
        where THandler :IEventHandler,new()
    {
        /// <summary>
        /// 为Handler对象创建一个新实例
        /// </summary>
        /// <returns>Handler对象</returns>
        public IEventHandler GetHandler()
        {
            return new THandler();
        }

        /// <summary>
        /// Dispose当前Handler.如果他不是<see cref="IDisposable"/>,则不做任何操作.
        /// </summary>
        /// <param name="handler">将要释放的Handler</param>
        public void ReleaseHandler(IEventHandler handler)
        {
            if (handler is IDisposable)
            {
                (handler as IDisposable).Dispose();
            }
        }
    }
}
