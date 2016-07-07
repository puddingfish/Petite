//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :NullEntityChangeEventHelper 
//        Description :    
//        Created by Wsy at 2016/7/7 11:53:03
//        http://www.hafenxiang.com 
//  
//======================================================================  

using Petite.Core.Events.Entities;

namespace Petite.Core.Events.Entities
{
    public class NullEntityChangeEventHelper:IEntityChangeEventHelper
    {
        #region fields

        private static readonly NullEntityChangeEventHelper SingletonInstance = new NullEntityChangeEventHelper();
        public static NullEntityChangeEventHelper Instance { get { return SingletonInstance; } }

        #endregion

        #region ctors

        public NullEntityChangeEventHelper()
        {

        }

        #endregion

        #region methods

        public void TriggerEntityCreatedEventOnUowCompleted(object entity)
        {
        }

        public void TriggerEntityUpdatedEventOnUowCompleted(object entity)
        {
        }

        public void TriggerEntityDeletedEventOnUowCompleted(object entity)
        {
        }

        #endregion
    }
}
