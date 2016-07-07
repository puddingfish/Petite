//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :NullDisposable 
//        Description :    
//        Created by Wsy at 2016/7/7 11:23:34
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;


namespace Petite.Utils.Extensions
{
    public class NullDisposable:IDisposable
    {
        public static NullDisposable Instance { get { return SingletonInstance; } }
        private static readonly NullDisposable SingletonInstance = new NullDisposable();

        private NullDisposable()
        {

        }

        public void Dispose()
        {

        }
    }
}
