//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :IMultiTenancyConfig 
//        Description :    
//        Created by Wsy at 2016/7/16 15:33:25
//        http://www.hafenxiang.com 
//  
//======================================================================  



namespace Petite.Core.Configuration.Startup
{
    public interface IMultiTenancyConfig
    {
        /// <summary>
        /// 是否开启多租户模式
        /// 默认为:false
        /// </summary>
        bool IsEnabled { get; set; }
    }
}
