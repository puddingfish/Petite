//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventData 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/30 15:37:28
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Events
{
    [Serializable]
    public class EventData : IEventData
    {
        public object EventSource { get; set; }

        public DateTime EventTime { get; set; }

        public EventData()
        {
            EventTime = DateTime.Now;
        }
    }
}
