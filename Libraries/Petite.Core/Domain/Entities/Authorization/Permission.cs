//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :Permissions 
//        Description :    
//        Created by Wsy at 2016/8/4 17:10:07
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Petite.Core.Domain.Entities.MultiTenancy;
using Petite.Core.Localization;

namespace Petite.Core.Domain.Entities.Authorization
{
    /// <summary>
    /// 应用程序权限
    /// </summary>
    public sealed class Permission
    {
        /// <summary>
        /// 父级权限.
        /// 如果设置了父级，则分配权限时必须先分配父级权限.
        /// </summary>
        public Permission Parent { get; private set; }

        /// <summary>
        /// 权限唯一名称.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 权限的显示名称.
        /// </summary>
        public ILocalizableString DisplayName { get; set; }

        /// <summary>
        /// 权限描述
        /// </summary>
        public ILocalizableString Description { get; set; }

        /// <summary>
        /// 是否默认授予.
        /// 默认值: false.
        /// </summary>
        public bool IsGrantedByDefault { get; set; }

        /// <summary>
        /// 权限对应的租户类型（服务提供商或租户）.
        /// </summary>
        public MultiTenancySides MultiTenancySides { get; set; }
        

        /// <summary>
        /// 子权限集合
        /// </summary>
        public IReadOnlyList<Permission> Children
        {
            get { return _children.ToImmutableList(); }
        }
        private readonly List<Permission> _children;

        /// <summary>
        /// 新建权限.
        /// </summary>
        /// <param name="name">权限名称</param>
        /// <param name="displayName">显示名称</param>
        /// <param name="isGrantedByDefault">是否默认授予.默认值: false.</param>
        /// <param name="description">权限描述</param>
        /// <param name="multiTenancySides">租户类型</param>
        public Permission(
            string name,
            ILocalizableString displayName = null,
            bool isGrantedByDefault = false,
            ILocalizableString description = null,
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
            DisplayName = displayName;
            IsGrantedByDefault = isGrantedByDefault;
            Description = description;
            MultiTenancySides = multiTenancySides;

            _children = new List<Permission>();
        }

        /// <summary>
        /// 添加子权限.
        /// 分配权限时必须先分配父级权限.
        /// </summary>
        /// <returns>刚添加的子权限</returns>
        public Permission CreateChildPermission(
            string name,
            ILocalizableString displayName = null,
            bool isGrantedByDefault = false,
            ILocalizableString description = null,
            MultiTenancySides multiTenancySides = MultiTenancySides.Host | MultiTenancySides.Tenant)
        {
            var permission = new Permission(name, displayName, isGrantedByDefault, description, multiTenancySides) { Parent = this };
            _children.Add(permission);
            return permission;
        }

        public override string ToString()
        {
            return string.Format("[权限: {0}]", Name);
        }
    }
}
