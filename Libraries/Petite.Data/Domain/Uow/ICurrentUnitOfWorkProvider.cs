//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ICurrentUnitOfWorkProvider 
//        Description :    
//        Created by Wsy at 2016/6/24 17:12:13
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Data.Domain.Uow
{
    public interface ICurrentUnitOfWorkProvider
    {
        IUnitOfWork Current { get; set; }
    }
}
