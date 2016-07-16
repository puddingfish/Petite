//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :ClaimsPetiteSession 
//        Description :    
//        Created by Wsy at 2016/7/15 17:59:11
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Linq;
using System.Threading;
using System.Security.Claims;
using Petite.Core.Configuration.Startup;
using Petite.Core.Domain.Entities.MultiTenancy;
using Petite.Core.Runtime.Security;

namespace Petite.Core.Runtime.Session
{
    public class ClaimsPetiteSession:IPetiteSession
    {
        private const int DefaultTenantId = 1;
        private readonly IMultiTenancyConfig _multiTenancy;

        public ClaimsPetiteSession(IMultiTenancyConfig multiTenancy)
        {
            _multiTenancy = multiTenancy;
        }

        public virtual long? UserId
        {
            get
            {
                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                {
                    return null;
                }

                var claimsIdentity = claimsPrincipal.Identity as ClaimsIdentity;
                if (claimsIdentity == null)
                {
                    return null;
                }

                var userIdClaim = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim == null || string.IsNullOrEmpty(userIdClaim.Value))
                {
                    return null;
                }

                long userId;
                if (!long.TryParse(userIdClaim.Value, out userId))
                {
                    return null;
                }

                return userId;
            }
        }

        public virtual int? TenantId
        {
            get
            {
                if (!_multiTenancy.IsEnabled)
                {
                    return DefaultTenantId;
                }

                var claimsPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;
                if (claimsPrincipal == null)
                {
                    return null;
                }

                var tenantIdClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == PetiteClaimTypes.TenantId);
                if (tenantIdClaim == null || string.IsNullOrEmpty(tenantIdClaim.Value))
                {
                    return null;
                }

                return Convert.ToInt32(tenantIdClaim.Value);
            }
        }

        public virtual MultiTenancySides MultiTenancySide
        {
            get
            {
                return _multiTenancy.IsEnabled && !TenantId.HasValue
                    ? MultiTenancySides.Host
                    : MultiTenancySides.Tenant;
            }
        }
    }
}
