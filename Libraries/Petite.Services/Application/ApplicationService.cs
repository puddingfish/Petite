//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ApplicationService 
//        Description :    
//        Created by Wsy at 2016/7/15 16:50:48
//        http://www.hafenxiang.com 
//  
//======================================================================  



using Petite.Core.Runtime.Session;

namespace Petite.Services.Application
{
    public class ApplicationService:PetiteServiceBase,IApplicationService
    {
        public IPetiteSession PetiteSession { get; set; }

        public ApplicationService()
        {
            PetiteSession = NullPetiteSession.Instance;
        }
    }
}
