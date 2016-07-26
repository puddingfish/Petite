//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LanguageInfo 
//        Description :    
//        Created by Wsy at 2016/7/26 16:53:25
//        http://www.hafenxiang.com 
//  
//======================================================================  


namespace Petite.Core.Domain.Entities.Localization
{
    /// <summary>
    /// 本地化语言信息类
    /// </summary>
    public class LanguageInfo
    {
        /// <summary>
        /// 语言的代号名称，如zh-CN代表简体中文
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 语言的显示名称，如简体中文
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 语言对应的ＵＩ显示的字体图标(font-awesome etc;)
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 默认语言
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 创建一个语言对象
        /// </summary>
        /// <param name="name">代号</param>
        /// <param name="displayName">显示名称</param>
        /// <param name="icon">字体图标</param>
        /// <param name="isDefault">是否默认语言</param>
        public LanguageInfo(string name,string displayName,string icon=null,bool isDefault=false)
        {
            Name = name;
            DisplayName = displayName;
            Icon = icon;
            IsDefault = isDefault;
        }
    }
}
