//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ActionEventHandler 
//        Description :    
//        Created by Wsy at 2016/7/5 14:38:58
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using Petite.Core.Dependency;

namespace Petite.Core.Events.Handlers.internals
{
    internal class ActionEventHandler<TEventData>:IEventHandler<TEventData>,ITransientDependency
    {
        public Action<TEventData> Action { get; private set; }

        public ActionEventHandler(Action<TEventData> handler)
        {
            Action = handler;
        }

        public  void HandleEvent(TEventData eventData)
        {
            Action(eventData);
        }
    }
}
