//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IUnitOfWork 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/13 14:38:47
//        http://www.hafenxiang.com 
//          
//======================================================================  


namespace Petite.Core.Domain.Uow
{
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        #region fields

        /// <summary>
        /// UOW唯一标识
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 引用外部存在的UOW
        /// </summary>
        IUnitOfWork outer { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// 根据给定的Options启动UOW
        /// </summary>
        /// <param name="options"></param>
        void Begin(UnitOfWorkOptions options);

        #endregion
    }
}
