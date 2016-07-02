//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EventPublisher 
//        Description :    
//        Created by Wsy at 2016/7/2 17:06:45
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petite.Core.Events
{
    public class EventPublisher:IEventPublisher
    {
        #region fields

        private readonly IEventSubscribers _eventSubscribers;

        #endregion

        #region ctors

        public EventPublisher(IEventSubscribers eventSubscribers)
        {
            _eventSubscribers = eventSubscribers;
        }

        #endregion
    }
}
