//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEventBus 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/7/4 17:16:07
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Threading.Tasks;
using Petite.Core.Events.Factories;
using Petite.Core.Events.Handlers;

namespace Petite.Core.Events
{
    public interface IEventBus
    {
        #region Register

        /// <summary>
        /// 注册到事件
        /// 事件发生时将调用给定的action
        /// </summary>
        /// <param name="action">处理事件的Action</param>
        /// <typeparam name="TEventData">事件信息</typeparam>
        IDisposable Register<TEventData>(Action<TEventData> action) where TEventData : IEventData;

        /// <summary>
        /// 注册到事件
        /// 使用相同Handler处理.
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="handler">处理事件的对象</param>
        IDisposable Register<TEventData>(IEventHandler<TEventData> handler) where TEventData : IEventData;

        /// <summary>
        /// 注册到事件
        /// 每一个事件发生都会创建一个新的Handler对象
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <typeparam name="THandler">事件处理类型</typeparam>
        IDisposable Register<TEventData, THandler>() where TEventData : IEventData where THandler : IEventHandler<TEventData>, new();

        /// <summary>
        /// 注册到事件
        /// 所有事件都使用相同Handler处理
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="handler">Object to handle the event</param>
        IDisposable Register(Type eventType, IEventHandler handler);

        /// <summary>
        /// 注册到事件
        /// 使用给定的事件处理工厂创建或释放Handlers
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="handlerFactory">创建或释放handlers的Factory</param>
        IDisposable Register<TEventData>(IEventHandlerFactory handlerFactory) where TEventData : IEventData;

        /// <summary>
        /// 注册到事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="handlerFactory">创建或释放handlers的Factory</param>
        IDisposable Register(Type eventType, IEventHandlerFactory handlerFactory);

        #endregion

        #region Unregister

        /// <summary>
        /// 从一个事件注销Handler
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="action"></param>
        void Unregister<TEventData>(Action<TEventData> action) where TEventData : IEventData;

        /// <summary>
        /// 从一个事件注销HandlerHandler
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="handler">Handler object that is registered before</param>
        void Unregister<TEventData>(IEventHandler<TEventData> handler) where TEventData : IEventData;

        /// <summary>
        /// 从一个事件注销Handler
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="handler">Handler object that is registered before</param>
        void Unregister(Type eventType, IEventHandler handler);

        /// <summary>
        /// 从一个事件注销Handler
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="factory">Factory object that is registered before</param>
        void Unregister<TEventData>(IEventHandlerFactory factory) where TEventData : IEventData;

        /// <summary>
        /// 从一个事件注销Handler
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="factory">Factory object that is registered before</param>
        void Unregister(Type eventType, IEventHandlerFactory factory);

        /// <summary>
        ///根据给定的事件信息注销所有的Handler
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        void UnregisterAll<TEventData>() where TEventData : IEventData;

        /// <summary>
        /// 根据给定的事件信息注销所有的Handler
        /// </summary>
        /// <param name="eventType">事件信息</param>
        void UnregisterAll(Type eventType);

        #endregion

        #region Trigger

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="eventData">事件关联的信息</param>
        void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData;

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="eventSource">The object which triggers the event</param>
        /// <param name="eventData">事件关联的信息</param>
        void Trigger<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData;

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="eventData">事件关联的信息</param>
        void Trigger(Type eventType, IEventData eventData);

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="eventSource">触发事件的对象</param>
        /// <param name="eventData">事件关联的信息</param>
        void Trigger(Type eventType, object eventSource, IEventData eventData);

        /// <summary>
        /// 异步触发事件
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="eventData">事件关联的信息</param>
        /// <returns>处理异步操作的Task</returns>
        Task TriggerAsync<TEventData>(TEventData eventData) where TEventData : IEventData;

        /// <summary>
        /// 异步触发事件.
        /// </summary>
        /// <typeparam name="TEventData">事件信息</typeparam>
        /// <param name="eventSource">触发事件的对象</param>
        /// <param name="eventData">事件关联的信息</param>
        /// <returns>处理异步操作的Task</returns>
        Task TriggerAsync<TEventData>(object eventSource, TEventData eventData) where TEventData : IEventData;

        /// <summary>
        /// 异步触发事件
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="eventData">事件关联的信息</param>
        /// <returns>处理异步操作的Task</returns>
        Task TriggerAsync(Type eventType, IEventData eventData);

        /// <summary>
        /// 异步触发事件
        /// </summary>
        /// <param name="eventType">事件信息</param>
        /// <param name="eventSource">触发事件的对象</param>
        /// <param name="eventData">事件关联的信息</param>
        /// <returns>处理异步操作的Task</returns>
        Task TriggerAsync(Type eventType, object eventSource, IEventData eventData);


        #endregion
    }
}
