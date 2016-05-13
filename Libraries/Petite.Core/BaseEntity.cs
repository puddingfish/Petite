//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :BaseEntity 
//        Description :    
//        Created by Wsy at 2016/4/28 17:32:15
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;


namespace Petite.Core
{
    [Serializable]
    public abstract class BaseEntity<TPrimaryKey>:IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Entity主键
        /// </summary>
        public virtual TPrimaryKey Id{get; set;}
        
        public virtual bool IsTransient()
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey));
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity<TPrimaryKey>))
            {
                return false;
            }

            //Same instances must be considered as equal
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            //Transient objects are not considered as equal
            var other = (BaseEntity<TPrimaryKey>)obj;
            if (IsTransient() && other.IsTransient())
            {
                return false;
            }

            //Must have a IS-A relation of types or must be same type
            var typeOfThis = GetType();
            var typeOfOther = other.GetType();
            if (!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
            {
                return false;
            }

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }        

        public static bool operator ==(BaseEntity<TPrimaryKey> x, BaseEntity<TPrimaryKey> y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(BaseEntity<TPrimaryKey> x, BaseEntity<TPrimaryKey> y)
        {
            return !(x == y);
        }
    }
}
