//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EntityCreatedEvent 
//        Description :    
//        Created by Wsy at 2016/7/1 14:01:32
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Events.Entities
{
    public class EntityCreatedEvent<TEntity,TPrimaryKey> where TEntity:IEntity<TPrimaryKey>
    {
        public TEntity Entity { get; private set; }

        public EntityCreatedEvent(TEntity entity)
        {
            Entity = entity;    
        }
    }
}
