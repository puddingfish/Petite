//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEventSubscribers 
//        Description :    
//        Created by Wsy at 2016/7/2 16:19:43
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;


namespace Petite.Core.Events
{
    /// <summary>
    /// 事件订阅对象
    /// </summary>
    public interface IEventSubscribers
    {
        /// <summary>
        /// 获取所有的事件订阅对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IList<IEventHandler<T>> GetSubscribers<T>();
    }
}
