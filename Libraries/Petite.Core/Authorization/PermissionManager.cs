//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PermissionManager 
//        Description :    
//        Created by Wsy at 2016/8/5 17:35:42
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Petite.Core.Configuration.Startup;
using Petite.Core.Dependency;
using Petite.Core.Domain.Entities.Authorization;
using Petite.Core.Domain.Entities.MultiTenancy;
using Petite.Core.Extension;
using Petite.Core.Runtime.Session;

namespace Petite.Core.Authorization
{
    internal class PermissionManager : PermissionDefinitionContextBase, IPermissionManager, ISingletonDependency
    {
        #region fields

        public IPetiteSession PetiteSession { get; set; }

        private readonly IIocManager _iocManager;
        private readonly IAuthorizationConfiguration _authorizationConfiguration;

        #endregion

        #region ctors

        /// <summary>
        /// Constructor.
        /// </summary>
        public PermissionManager(
            IIocManager iocManager,
            IAuthorizationConfiguration authorizationConfiguration)
        {
            _iocManager = iocManager;
            _authorizationConfiguration = authorizationConfiguration;

            PetiteSession = NullPetiteSession.Instance;
        }

        #endregion


        public void Initialize()
        {
            foreach (var providerType in _authorizationConfiguration.Providers)
            {
                _iocManager.RegisterIfNot(providerType, DependencyLifeStyle.Transient);
                using (var provider = _iocManager.ResolveAsDisposable<AuthorizationProvider>(providerType))
                {
                    provider.Object.SetPermissions(this);
                }
            }

            Permissions.AddAllPermissions();
        }

        public Permission GetPermission(string name)
        {
            var permission = Permissions.GetOrDefault(name);
            if (permission == null)
            {
                throw new Exception("未找到权限: " + name);
            }

            return permission;
        }

        public IReadOnlyList<Permission> GetAllPermissions(bool tenancyFilter = true)
        {
                return Permissions.Values
                    .WhereIf(tenancyFilter, p => p.MultiTenancySides.HasFlag(PetiteSession.MultiTenancySide))
                    .Where(p =>
                        PetiteSession.MultiTenancySide == MultiTenancySides.Host 
                    ).ToImmutableList();
        }

        public IReadOnlyList<Permission> GetAllPermissions(MultiTenancySides multiTenancySides)
        {
                return Permissions.Values
                    .Where(p => p.MultiTenancySides.HasFlag(multiTenancySides))
                    .Where(p =>
                        PetiteSession.MultiTenancySide == MultiTenancySides.Host ||
                        (p.MultiTenancySides.HasFlag(MultiTenancySides.Host) &&
                         multiTenancySides.HasFlag(MultiTenancySides.Host)) 
                    ).ToImmutableList();
            }
        }
    }
}
