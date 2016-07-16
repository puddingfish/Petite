//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :MultiTenancyConfig 
//        Description :    
//        Created by Wsy at 2016/7/16 15:35:18
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Configuration.Startup
{
    public class MultiTenancyConfig:IMultiTenancyConfig
    {
        /// <summary>
        /// 是否开启多租户模式
        /// 默认：false
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
