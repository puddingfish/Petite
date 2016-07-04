//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEventHandler
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/7/4 17:27:07
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Events.Handlers
{
    /// <summary>
    /// 事件类型为<see cref="IEventData"/>的事件处理接口
    /// </summary>
    /// <typeparam name="TEventData">处理的事件类型</typeparam>
    public interface IEventHandler<in TEventData>:IEventHandler
    {
        void HandleEvent(TEventData eventData);
    }
}
