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
using Petite.Core.Domain.Uow;

namespace Petite.EntityFramework.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWorkOptions Options { get; set;}

        public IUnitOfWork outer { get; set; }

        public bool TransactionEnabled { get; set; }

        public void Begin(UnitOfWorkOptions options)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
