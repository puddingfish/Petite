//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWorkFailedEventArgs 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/21 17:18:51
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petite.Core.Domain.Uow
{
    /// <summary>
    /// Used as event arguments on <see cref="IActiveUnitOfWork.Failed"/> event.
    /// </summary>
    public class UnitOfWorkFailedEventArgs:EventArgs
    {
        /// <summary>
        /// Exception that caused failure.
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Creates a new <see cref="UnitOfWorkFailedEventArgs"/> object.
        /// </summary>
        /// <param name="exception">Exception that caused failure</param>
        public UnitOfWorkFailedEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
