//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IUnitOfWorkCompleteHandler 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/24 16:05:46
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Threading.Tasks;


namespace Petite.Core.Domain.Uow
{
    public interface IUnitOfWorkCompleteHandle:IDisposable
    {
        /// <summary>
        /// 完成UOW
        /// </summary>
        void Complete();

        /// <summary>
        /// 异步完成UOW
        /// </summary>
        /// <returns></returns>
        Task CompleteAsync();
    }
}
