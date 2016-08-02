//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :XmlNodeExtensions 
//        Description :    
//        Created by Wsy at 2016/8/2 15:34:36
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Linq;
using System.Xml;

namespace Petite.Core.Extension
{
    public static class XmlNodeExtensions
    {
        /// <summary>
        /// 从XML节点返回属性值
        /// </summary>
        /// <param name="node">Xml节点</param>
        /// <param name="attributeName">属性名称</param>
        /// <returns>属性值或null</returns>
        public static string GetAttributeValueOrNull(this XmlNode node, string attributeName)
        {
            if (node.Attributes == null || node.Attributes.Count <= 0)
            {
                throw new ApplicationException(node.Name + " 节点未包含 " + attributeName + " 属性");
            }

            return node.Attributes
                .Cast<XmlAttribute>()
                .Where(attr => attr.Name == attributeName)
                .Select(attr => attr.Value)
                .FirstOrDefault();
        }
    }
}
