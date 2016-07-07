//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IUnitOfWorkManager 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/25 15:31:36
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Transactions;

namespace Petite.Core.Domain.Uow
{
    /// <summary>
    /// UOW管理器接口
    /// </summary>
    public interface IUnitOfWorkManager
    {
        /// <summary>
        /// 获取当前活动的UOW，不存在则返回null
        /// </summary>
        IActiveUnitOfWork Current { get; }

        /// <summary>
        /// 启动UOW
        /// </summary>
        /// <returns>完成UOW的handle</returns>
        IUnitOfWorkCompleteHandle Begin();

        /// <summary>
        /// 启动UOW
        /// </summary>
        /// <returns>完成UOW的handle</returns>
        IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope);

        /// <summary>
        /// 启动UOW
        /// </summary>
        /// <returns>完成UOW的handle</returns>
        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
