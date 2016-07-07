//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWorkOptions 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/20 14:14:28
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Transactions;

namespace Petite.Core.Domain.Uow
{
    public class UnitOfWorkOptions
    {
        public UnitOfWorkOptions()
        {
            IsTransactional = true;
            Scope = TransactionScopeOption.Required;
        }

        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 是否当前UOW的事务
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// UOW超时时间（毫秒）
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 如果当前UOW是事务型的，此选项设置事务的隔离级别
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 指示是否为TransactionScope启用跨线程连续任务的事务流
        /// </summary>
        public TransactionScopeAsyncFlowOption? AsyncFlowOption { get; set; }

    }
}
