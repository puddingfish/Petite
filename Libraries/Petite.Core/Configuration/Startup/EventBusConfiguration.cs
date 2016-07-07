//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventBusConfiguration 
//        Description :    
//        Created by Wsy at 2016/7/7 17:35:43
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Configuration.Startup
{
    public class EventBusConfiguration:IEventBusConfiguration
    {
        public bool UseDefaultEventBus { get; set; }

        public EventBusConfiguration()
        {
            UseDefaultEventBus = true;
        }
    }
}
