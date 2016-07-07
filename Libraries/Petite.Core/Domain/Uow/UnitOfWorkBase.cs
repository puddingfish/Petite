//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWorkBase 
//        Description :   UOW基类，方便其他ORM的UOW实现， 参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/22 11:54:53
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Threading.Tasks;
using Petite.Core.Extension;


namespace Petite.Core.Domain.Uow
{
    /// <summary>
    /// 所有Unit of work的基类
    /// </summary>
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        #region fields

        public string Id { get; private set; }

        public bool IsDisposed { get; private set; }

        /// <summary>
        /// UOW设置选项
        /// </summary>
        public UnitOfWorkOptions Options { get; private set; }

        /// <summary>
        /// 外部已经存在的UOW
        /// </summary>
        public IUnitOfWork outer { get; set; }

        /// <summary>
        /// UOW完成事件
        /// </summary>
        public event EventHandler Completed;

        /// <summary>
        /// UOW释放事件
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        /// UOW失败事件
        /// </summary>
        public event EventHandler<UnitOfWorkFailedEventArgs> Failed;

        /// <summary>
        /// <see cref="Begin(UnitOfWorkOptions)"/>方法是否被调用过
        /// </summary>
        private bool _isBeginCalledBefore;

        /// <summary>
        /// <see cref="Complete"/>方法是否被调用过
        /// </summary>
        private bool _isCompleteCalledBefore;

        /// <summary>
        /// 标识当前UOW是否成功执行
        /// </summary>
        private bool _succeed;

        /// <summary>
        /// 当前UOW失败时报的异常信息
        /// </summary>
        private Exception _exception;

        #endregion

        #region ctors

        public UnitOfWorkBase()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        #endregion

        #region methods

        /// <summary>
        /// 启动UOW
        /// </summary>
        /// <param name="options"></param>
        public void Begin(UnitOfWorkOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            //防止多次启动
            PreventMultipleBegin();

            BeginUow();
        }

        /// <summary>
        /// 在派生类中实现，主要为应对不同ORM实现不同的事务
        /// </summary>
        protected abstract void BeginUow();

        /// <summary>
        /// 在派生类中实现，主要为应对不同ORM实现不同的事务
        /// </summary>
        protected abstract void CompleteUow();

        /// <summary>
        /// 在派生类中实现，主要为应对不同ORM实现不同的事务
        /// </summary>
        protected abstract Task CompleteUowAsync();

        /// <summary>
        /// 在派生类中实现，主要为应对不同ORM实现不同的事务
        /// </summary>
        protected abstract void DisposeUow();

        public abstract void Commit();

        public abstract Task CommitAsync();

        public void Complete()
        {
            //防止多次调用完成事务
            PreventMultipleComplete();
            try
            {
                CompleteUow();
                _succeed = true;
                
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }
        }

        public async Task CompleteAsync()
        {
            PreventMultipleComplete();
            try
            {
                await CompleteUowAsync();
                _succeed = true;
                OnCompleted();
            }
            catch (Exception ex)
            {
                _exception = ex;
                throw;
            }
        }

        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            if (!_succeed)
            {
                OnFailed(_exception);
            }

            DisposeUow();
            OnDisposed();
        }

        /// <summary>
        /// Called to trigger <see cref="Completed"/> event.
        /// </summary>
        protected virtual void OnCompleted()
        {
            Completed.InvokeSafely(this);
        }

        /// <summary>
        /// Called to trigger <see cref="Failed"/> event.
        /// </summary>
        /// <param name="exception">Exception that cause failure</param>
        protected virtual void OnFailed(Exception exception)
        {
            Failed.InvokeSafely(this, new UnitOfWorkFailedEventArgs(exception));
        }

        /// <summary>
        /// Called to trigger <see cref="Disposed"/> event.
        /// </summary>
        protected virtual void OnDisposed()
        {
            Disposed.InvokeSafely(this);
        }

        /// <summary>
        /// 阻止重复启动Uow
        /// </summary>
        private  void PreventMultipleBegin()
        {
            if(_isBeginCalledBefore)
            {
                throw new Exception("当前已经调用过UnitOfWork，不能重复调用！");
            }
            _isBeginCalledBefore = true;
        }

        /// <summary>
        /// 防止重复调用完成事件
        /// </summary>
        private void PreventMultipleComplete()
        {
            if(_isCompleteCalledBefore)
            {
                throw new Exception("当前UnitOfWork已经完成，请不要重复调用！");
            }
        }

        #endregion
    }
}
