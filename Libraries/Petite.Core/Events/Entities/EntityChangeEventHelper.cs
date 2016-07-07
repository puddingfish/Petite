//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EntityChangeEventHelper 
//        Description :    
//        Created by Wsy at 2016/7/7 11:39:42
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using Petite.Data.Domain.Uow;

namespace Petite.Core.Events.Entities
{
    public class EntityChangeEventHelper:IEntityChangeEventHelper
    {
        #region fields

        public IEventBus EventBus { get; set; }

        private readonly IUnitOfWorkManager _unitOfWorkManager;

        #endregion

        #region ctors

        public EntityChangeEventHelper(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
            EventBus = NullEventBus.Instance;
        }

        #endregion

        #region methods

        public void TriggerEntityCreatedEventOnUowCompleted(object entity)
        {
            TriggerEventWithEntity(typeof(EntityCreatedEvent<>), entity, false);
        }

        public void TriggerEntityUpdatedEventOnUowCompleted(object entity)
        {
            TriggerEventWithEntity(typeof(EntityUpdatedEvent<>), entity, false);
        }

        public void TriggerEntityDeletedEventOnUowCompleted(object entity)
        {
            TriggerEventWithEntity(typeof(EntityDeletedEvent<>), entity, false);
        }

        private void TriggerEventWithEntity(Type genericEventType, object entity, bool triggerImmediately)
        {
            var entityType = entity.GetType();
            var eventType = genericEventType.MakeGenericType(entityType);

            if (triggerImmediately || _unitOfWorkManager.Current == null)
            {
                EventBus.Trigger(eventType, (IEventData)Activator.CreateInstance(eventType, new[] { entity }));
                return;
            }

            _unitOfWorkManager.Current.Completed += (sender, args) => EventBus.Trigger(eventType, (IEventData)Activator.CreateInstance(eventType, new[] { entity }));
        }

        #endregion
    }
}
