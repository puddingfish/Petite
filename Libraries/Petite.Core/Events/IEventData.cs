//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEventData 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/30 15:19:46
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Core.Events
{
    public interface IEventData
    {
        /// <summary>
        /// 事件发生时间
        /// </summary>
        DateTime EventTime { get; set; }

        /// <summary>
        /// 触发事件的事件源
        /// </summary>
        object EventSource { get; set; }
    }
}
