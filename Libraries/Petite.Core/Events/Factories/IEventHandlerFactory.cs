//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEventHandlerFactory 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/7/4 17:36:25
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Events.Handlers;

namespace Petite.Core.Events.Factories
{
    public interface IEventHandlerFactory
    {
        /// <summary>
        /// 获取一个事件处理器
        /// </summary>
        /// <returns></returns>
        IEventHandler GetHandler();

        /// <summary>
        /// 释放一个事件处理器
        /// </summary>
        /// <param name="handler"></param>
        void ReleaseHandler(IEventHandler handler);
    }
}
