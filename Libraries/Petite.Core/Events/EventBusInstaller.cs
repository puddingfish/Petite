﻿//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventBusInstaller 
//        Description :    
//        Created by Wsy at 2016/7/5 15:17:52
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;
using Petite.Core.Events.Factories;
using Petite.Core.Events.Handlers;

namespace Petite.Core.Events
{
    internal class EventBusInstaller:IWindsorInstaller
    {
        #region fields

        public readonly IIocResolver _iocResolver;
        private readonly IEventBusConfiguration _eventBusConfiguration;
        private IEventBus _eventBus;

        #endregion

        #region ctors

        public EventBusInstaller(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
            _eventBusConfiguration = _iocResolver.Resolve<IEventBusConfiguration>();
        }

        #endregion

        #region methods

        public void Install(IWindsorContainer container,IConfigurationStore store)
        {
            if (_eventBusConfiguration.UseDefaultEventBus)
            {
                container.Register(
                    Component.For<IEventBus>().UsingFactoryMethod(() => EventBus.Default).LifestyleSingleton()
                    );
            }
            else
            {
                container.Register(
                    Component.For<IEventBus>().ImplementedBy<EventBus>().LifestyleSingleton()
                    );
            }

            _eventBus = container.Resolve<IEventBus>();

            container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
        }

        private void Kernel_ComponentRegistered(string key, IHandler handler)
        {
            /* This code checks if registering component implements any IEventHandler<TEventData> interface, if yes,
             * gets all event handler interfaces and registers type to Event Bus for each handling event.
             */
            if (!typeof(IEventHandler).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                return;
            }

            var interfaces = handler.ComponentModel.Implementation.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                if (!typeof(IEventHandler).IsAssignableFrom(@interface))
                {
                    continue;
                }

                var genericArgs = @interface.GetGenericArguments();
                if (genericArgs.Length == 1)
                {
                    _eventBus.Register(genericArgs[0], new IocHandlerFactory(_iocResolver, handler.ComponentModel.Implementation));
                }
            }
        }

        #endregion
    }
}
