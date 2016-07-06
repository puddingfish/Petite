//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :FactoryUnregistrar 
//        Description :    
//        Created by Wsy at 2016/7/5 13:42:11
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Events.Factories.Internals
{
    /// <summary>
    /// 用于注销<see cref="IEventHandlerFactory"/>(<see cref="Dispose"/>方法)
    /// </summary>
    internal class FactoryUnregistrar : IDisposable
    {
        private readonly IEventBus _eventBus;
        private readonly Type _eventType;
        private readonly IEventHandlerFactory _factory;

        public FactoryUnregistrar(IEventBus eventBus, Type eventType, IEventHandlerFactory factory)
        {
            _eventBus = eventBus;
            _eventType = eventType;
            _factory = factory;
        }

        public void Dispose()
        {
            _eventBus.Unregister(_eventType, _factory);
        }
    }
}
