//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EntityDeletedEvent 
//        Description :    
//        Created by Wsy at 2016/7/1 14:01:58
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Events.Entities
{
    public class EntityDeletedEvent<TEntity,TPrimaryKey> where TEntity :IEntity<TPrimaryKey>
    {
        public TEntity Entity { get; private set; }

        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="entity"></param>
        public EntityDeletedEvent(TEntity entity)
        {
            Entity = entity;
        }
    }
}
