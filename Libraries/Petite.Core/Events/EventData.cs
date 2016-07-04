//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventData 
//        Description :    
//        Created by Wsy at 2016/7/4 17:03:54
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Events
{
    [Serializable]
    public class EventData:IEventData
    {
        /// <summary>
        /// 事件发生时间
        /// </summary>
        public DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的事件源
        /// </summary>
        public object EventSource { get; set; }

        public EventData()
        {
            //默认为当前时间
            EventTime = DateTime.Now;
        }
    }
}
