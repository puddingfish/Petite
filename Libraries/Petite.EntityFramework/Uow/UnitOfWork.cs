//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWork 
//        Description :    
//        Created by Wsy at 2016/6/13 17:48:47
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Petite.EntityFramework.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public bool TransactionEnabled { get; set; }
        

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
