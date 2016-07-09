//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IConventionalDependencyRegistrar 
//        Description :    
//        Created by Wsy at 2016/7/8 17:34:27
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Dependency
{
    public interface IConventionalDependencyRegistrar
    {
        /// <summary>
        /// Registers types of given assembly by convention.
        /// </summary>
        /// <param name="context">Registration context</param>
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}
