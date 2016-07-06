//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :SingleInstanceHandlerFactory 
//        Description :    
//        Created by Wsy at 2016/7/5 14:20:56
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Events.Handlers;

namespace Petite.Core.Events.Factories.Internals
{
    internal class SingleInstanceHandlerFactory:IEventHandlerFactory
    {
        public IEventHandler HandlerInstance { get; private set; }

        public SingleInstanceHandlerFactory(IEventHandler handler)
        {
            HandlerInstance = handler;
        }

        public IEventHandler GetHandler()
        {
            return HandlerInstance;
        }

        public void ReleaseHandler(IEventHandler handler)
        {

        }
    }
}
