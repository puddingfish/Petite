//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWorkManager 
//        Description :    
//        Created by Wsy at 2016/6/25 15:36:26
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System.Transactions;
using Petite.Core.Dependency;

namespace Petite.Core.Domain.Uow
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        #region fields

        private readonly IIocResolver _iocResolver;
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        public IActiveUnitOfWork Current => _currentUnitOfWorkProvider.Current;

        #endregion

        #region ctors

        public UnitOfWorkManager(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider, IIocResolver iocResolver)
        {
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _iocResolver = iocResolver;
        }

        #endregion

        #region methods

        public IUnitOfWorkCompleteHandle Begin()
        {
            return Begin(new UnitOfWorkOptions());
        }

        public IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options)
        {
            if (options.Scope == TransactionScopeOption.Required && _currentUnitOfWorkProvider.Current != null)
            {
                return new InnerUnitOfWorkCompleteHandle();
            }

            var uow = _iocResolver.Resolve<IUnitOfWork>();

            uow.Completed += (sender, args) =>
            {
                _currentUnitOfWorkProvider.Current = null;
            };

            uow.Failed += (sender, args) =>
            {
                _currentUnitOfWorkProvider.Current = null;
            };

            uow.Disposed += (sender, args) =>
            {
                _iocResolver.Release(uow);
            };

            uow.Begin(options);

            _currentUnitOfWorkProvider.Current = uow;

            return uow;
        }

        public IUnitOfWorkCompleteHandle Begin(TransactionScopeOption scope)
        {
            return Begin(new UnitOfWorkOptions { Scope = scope });
        }

        #endregion
    }
}
