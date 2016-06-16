//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IUnitOfWork 
//        Description :    
//        Created by Wsy at 2016/6/13 14:38:47
//        http://www.hafenxiang.com 
//          
//======================================================================  

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;


namespace Petite.Data.Uow
{
    public interface IUnitOfWork
    {
        #region fields

        bool TransactionEnabled { get; set; }

        #endregion

        #region methods       

        /// <summary>
        /// 提交当前单元操作的更改。
        /// </summary>
        /// <returns>操作影响的行数</returns>
        int Commit();

        #endregion
    }
}
