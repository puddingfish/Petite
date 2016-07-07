//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IEntityChangeEventHelper 
//        Description :    
//        Created by Wsy at 2016/7/7 11:36:19
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Events.Entities
{
    public interface IEntityChangeEventHelper
    {
        void TriggerEntityCreatedEventOnUowCompleted(object entity);
        
        void TriggerEntityUpdatedEventOnUowCompleted(object entity);
        
        void TriggerEntityDeletedEventOnUowCompleted(object entity);
    }
}
