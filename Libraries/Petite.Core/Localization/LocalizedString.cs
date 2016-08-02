//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :LocalizedString 
//        Description :    
//        Created by Wsy at 2016/8/1 17:02:24
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Globalization;


namespace Petite.Core.Localization
{
    public class LocalizedString
    {
        public CultureInfo CultureInfo { get; internal set; }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public LocalizedString(string name,string value,CultureInfo cultureInfo)
        {
            Name = name;
            Value = value;
            CultureInfo = cultureInfo;
        }
    }
}
