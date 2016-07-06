//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEventBusConfiguration 
//        Description :    
//        Created by Wsy at 2016/7/5 15:35:18
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Configuration.Startup
{
    public interface IEventBusConfiguration
    {
        /// <summary>
        /// True,使用<see cref="EventBus.Default"/>
        /// False,创建新实例
        /// 默认为true
        /// </summary>
        bool UseDefaultEventBus { get; set; }
    }
}
