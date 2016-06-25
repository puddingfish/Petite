//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IActiveUnitOfWork 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/21 17:16:56
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Threading.Tasks;


namespace Petite.Data.Domain.Uow
{
    public interface IActiveUnitOfWork
    {
        #region fields

        /// <summary>
        /// 完成事件：当UOW成功执行后触发
        /// </summary>
        event EventHandler Completed;

        /// <summary>
        /// 释放事件：当UOW被释放时触发
        /// </summary>
        event EventHandler Disposed;

        /// <summary>
        /// 失败事件：当UOW执行失败时触发
        /// </summary>
        event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// 获取UOW是否为事务型
        /// </summary>
        UnitOfWorkOptions Options { get;}

        /// <summary>
        /// 标识当前UOW是否已经被释放
        /// </summary>
        bool IsDisposed { get; }

        #endregion

        #region methods

        /// <summary>
        /// 提交当前UOW的所有更改
        /// 当需要提交变更时可以调用此方法
        /// 注意：如果当前UOW是事务型的，如果事务回滚，当前更改也会跟着回滚
        /// 一般的更改提交时，无须显式调用方法，因为在UOW结束时会自动提交
        /// </summary>
        void Commit();

        /// <summary>
        /// 提交当前UOW的所有更改
        /// 当需要提交变更时可以调用此方法
        /// 注意：如果当前UOW是事务型的，如果事务回滚，当前更改也会跟着回滚
        /// 一般的更改提交时，无须显式调用方法，因为在UOW结束时会自动提交
        /// </summary>
        Task CommitAsync();

        #endregion
    }
}
