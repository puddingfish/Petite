//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventSubscribers 
//        Description :    
//        Created by Wsy at 2016/7/2 16:48:56
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Collections.Generic;
using Castle.Windsor;

namespace Petite.Core.Events
{
    public class EventSubscribers:IEventSubscribers
    {
        protected IWindsorContainer IocContainer { get; private set; }
        
        public EventSubscribers(IWindsorContainer iocContainer)
        {
            IocContainer = iocContainer;
        }

        IList<IEventHandler<T>> IEventSubscribers.GetSubscribers<T>()
        {
            return IocContainer.ResolveAll<IEventHandler<T>>();
        }
    }
}
