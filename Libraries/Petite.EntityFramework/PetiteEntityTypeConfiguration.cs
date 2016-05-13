//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PetiteEntityTypeConfiguration 
//        Description :    
//        Created by Wsy at 2016/4/29 15:37:26
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Data.Entity.ModelConfiguration;

namespace Petite.Data
{
    public class PetiteEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected PetiteEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }
    }
}
