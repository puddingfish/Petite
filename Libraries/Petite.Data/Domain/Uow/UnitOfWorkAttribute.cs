//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWorkAttribute 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/24 17:20:09
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Reflection;
using System.Transactions;

namespace Petite.Data.Domain.Uow
{
    /// <summary>
    /// 这个特性表明声明的方法是原子的，应该考虑作为一个UOW
    /// 拥有此特性的方法将会被拦截，在调用方法之前会打开一个数据库连接及开启事务
    /// 如果没有异常，调用方法后将提交事务保存数据
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute:Attribute
    {
        #region fields

        /// <summary>
        /// 事务范围附加选项
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 是否是事务型UOW
        /// </summary>
        public bool? IsTransactional { get; private set; }
        
        /// <summary>
        /// Uow超时时间（毫秒）
        /// </summary>
        public TimeSpan? Timeout { get; private set; }

        /// <summary>
        /// 如果当前是事务型Uow，则标识其事务的隔离级别
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// Used to prevent starting a unit of work for the method.
        /// If there is already a started unit of work, this property is ignored.
        /// Default: false.
        /// </summary>
        public bool IsDisabled { get; set; }

        #endregion

        #region ctor

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// </summary>
        public UnitOfWorkAttribute()
        {

        }

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// </summary>
        /// <param name="isTransactional">
        /// 事务标识
        /// </param>
        public UnitOfWorkAttribute(bool isTransactional)
        {
            IsTransactional = isTransactional;
        }

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// </summary>
        /// <param name="isTransactional">事务标识</param>
        /// <param name="timeout">超时时间</param>
        public UnitOfWorkAttribute(bool isTransactional, int timeout)
        {
            IsTransactional = isTransactional;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// <see cref="IsTransactional"/> 默认为true.
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel)
        {
            IsTransactional = true;
            IsolationLevel = isolationLevel;
        }

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// <see cref="IsTransactional"/> 自动设为true
        /// </summary>
        /// <param name="isolationLevel">事务隔离级别</param>
        /// <param name="timeout">事务超时时间（毫秒）</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel, int timeout)
        {
            IsTransactional = true;
            IsolationLevel = isolationLevel;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// <see cref="IsTransactional"/>自动设置为true
        /// </summary>
        /// <param name="scope">事务范围</param>
        public UnitOfWorkAttribute(TransactionScopeOption scope)
        {
            IsTransactional = true;
            Scope = scope;
        }

        /// <summary>
        /// 构造 <see cref="UnitOfWorkAttribute"/> 对象.
        /// <see cref="IsTransactional"/> 自动设置为true.
        /// </summary>
        /// <param name="scope">事务范围</param>
        /// <param name="timeout">事务超时时间（毫秒）</param>
        public UnitOfWorkAttribute(TransactionScopeOption scope, int timeout)
        {
            IsTransactional = true;
            Scope = scope;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        #endregion

        #region methods

        internal static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(UnitOfWorkAttribute), false);
            if (attrs.Length > 0)
            {
                return (UnitOfWorkAttribute)attrs[0];
            }

            if (UnitOfWorkHelper.IsConventionalUowClass(methodInfo.DeclaringType))
            {
                return new UnitOfWorkAttribute(); //Default
            }

            return null;
        }

        internal UnitOfWorkOptions CreateOptions()
        {
            return new UnitOfWorkOptions
            {
                IsTransactional = IsTransactional,
                IsolationLevel = IsolationLevel,
                Timeout = Timeout,
                Scope = Scope
            };
        }

        #endregion

    }
}
