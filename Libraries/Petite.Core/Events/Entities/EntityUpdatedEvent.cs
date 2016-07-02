//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EntityUpdatedEvent 
//        Description :    
//        Created by Wsy at 2016/7/1 14:01:46
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Events.Entities
{
    public class EntityUpdatedEvent<TEntity,TPrimaryKey> where TEntity:IEntity<TPrimaryKey>
    {
        public TEntity Entity { get; private set; }

        /// <summary>
        /// 更新事件
        /// </summary>
        /// <param name="entity"></param>
        public EntityUpdatedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}
