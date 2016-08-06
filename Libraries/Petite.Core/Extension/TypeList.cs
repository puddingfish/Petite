//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :TypeList 
//        Description :    
//        Created by Wsy at 2016/8/6 15:09:45
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections;
using System.Collections.Generic;


namespace Petite.Core.Extension
{
    /// <summary>
    /// object类型的<see cref="TypeList{TBaseType}"/>.
    /// </summary>
    public class TypeList : TypeList<object>, ITypeList
    {
    }

    /// <summary>
    /// 使用指定基类扩展 <see cref="IList{Type}"/> .
    /// </summary>
    /// <typeparam name="TBaseType">list对应的基类<see cref="Type"/>s </typeparam>
    public class TypeList<TBaseType> : ITypeList<TBaseType>
    {
        /// <summary>
        /// 获取集合计数.
        /// </summary>
        /// <value>计数.</value>
        public int Count { get { return _typeList.Count; } }

        /// <summary>
        /// 获取此集合是否为只读.
        /// </summary>
        /// <value><c>true</c>：只读; <c>false</c>：读写</value>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// 按索引获取 <see cref="Type"/>.
        /// </summary>
        /// <param name="index">索引</param>
        public Type this[int index]
        {
            get { return _typeList[index]; }
            set
            {
                CheckType(value);
                _typeList[index] = value;
            }
        }

        private readonly List<Type> _typeList;

        /// <summary>
        /// 构造函数
        /// </summary>
        public TypeList()
        {
            _typeList = new List<Type>();
        }

        /// <inheritdoc/>
        public void Add<T>() where T : TBaseType
        {
            _typeList.Add(typeof(T));
        }

        /// <inheritdoc/>
        public void Add(Type item)
        {
            CheckType(item);
            _typeList.Add(item);
        }

        /// <inheritdoc/>
        public void Insert(int index, Type item)
        {
            _typeList.Insert(index, item);
        }

        /// <inheritdoc/>
        public int IndexOf(Type item)
        {
            return _typeList.IndexOf(item);
        }

        /// <inheritdoc/>
        public bool Contains<T>() where T : TBaseType
        {
            return Contains(typeof(T));
        }

        /// <inheritdoc/>
        public bool Contains(Type item)
        {
            return _typeList.Contains(item);
        }

        /// <inheritdoc/>
        public void Remove<T>() where T : TBaseType
        {
            _typeList.Remove(typeof(T));
        }

        /// <inheritdoc/>
        public bool Remove(Type item)
        {
            return _typeList.Remove(item);
        }

        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            _typeList.RemoveAt(index);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _typeList.Clear();
        }

        /// <inheritdoc/>
        public void CopyTo(Type[] array, int arrayIndex)
        {
            _typeList.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public IEnumerator<Type> GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        private static void CheckType(Type item)
        {
            if (!typeof(TBaseType).IsAssignableFrom(item))
            {
                throw new ArgumentException(string.Format("给定项不是{0}的类型！", typeof(TBaseType).AssemblyQualifiedName), "item");
            }
        }
    }
}
