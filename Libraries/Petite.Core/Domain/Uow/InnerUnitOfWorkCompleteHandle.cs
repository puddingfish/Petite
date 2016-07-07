//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :InnerUnitOfWorkCompleteHandler 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/24 16:53:26
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace Petite.Core.Domain.Uow
{
    /// <summary>
    /// This handle is used for innet unit of work scopes.
    /// A inner unit of work scope actually uses outer unit of work scope
    /// and has no effect on <see cref="IUnitOfWorkCompleteHandle.Complete"/> call.
    /// But if it's not called, an exception is thrown at end of the UOW to rollback the UOW.
    /// </summary>
    public class InnerUnitOfWorkCompleteHandle : IUnitOfWorkCompleteHandle
    {
        public const string DidNotCallCompleteMethodExceptionMessage = "未调用UnitOfWork的Complete方法.";

        private volatile bool _isCompleteCalled;
        private volatile bool _isDisposed;

        public void Complete()
        {
            _isCompleteCalled = true;
        }

        public async Task CompleteAsync()
        {
            _isCompleteCalled = true;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;

            if (!_isCompleteCalled)
            {
                if (HasException())
                {
                    return;
                }
                throw new Exception(DidNotCallCompleteMethodExceptionMessage);
            }
        }

        private static bool HasException()
        {
            try
            {
                return Marshal.GetExceptionCode() != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
