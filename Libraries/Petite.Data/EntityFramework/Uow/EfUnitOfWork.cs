//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :UnitOfWork 
//        Description :    参考ABP：https://github.com/aspnetboilerplate/aspnetboilerplate
//        Created by Wsy at 2016/6/13 17:48:47
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Transactions;
using Castle.Core.Internal;
using Petite.Core.Dependency;
using Petite.Core.Domain.Uow;

namespace Petite.Data.EntityFramework.Uow
{
    public class EfUnitOfWork : UnitOfWorkBase
    {
        #region fields

        protected readonly IDictionary<Type, DbContext> ActiveDbContexts;
        protected IIocResolver IocResolver { get; private set; }
        protected TransactionScope CurrentTransaction;

        #endregion

        #region ctors

        public EfUnitOfWork(IIocResolver iocResolver)
            :base()
        {
            IocResolver = iocResolver;
            ActiveDbContexts = new Dictionary<Type, DbContext>();
        }

        #endregion

        #region methods

        /// <summary>
        /// 提交修改
        /// </summary>
        public override void Commit()
        {
            ActiveDbContexts.Values.ForEach(SaveChangesInDbContext);
        }

        /// <summary>
        /// 异步提交修改
        /// </summary>
        /// <returns></returns>
        public override async Task CommitAsync()
        {
            foreach (var dbContext in ActiveDbContexts.Values)
            {
                await SaveChangesInDbContextAsync(dbContext);
            }
        }

        /// <summary>
        /// 开启UOW
        /// </summary>
        protected override void BeginUow()
        {
            if (Options.IsTransactional == true)
            {
                var transactionOptions = new TransactionOptions
                {
                    IsolationLevel = Options.IsolationLevel.GetValueOrDefault(IsolationLevel.ReadUncommitted),
                };

                if (Options.Timeout.HasValue)
                {
                    transactionOptions.Timeout = Options.Timeout.Value;
                }

                CurrentTransaction = new TransactionScope(
                    Options.Scope.GetValueOrDefault(TransactionScopeOption.Required),
                    transactionOptions,
                    Options.AsyncFlowOption.GetValueOrDefault(TransactionScopeAsyncFlowOption.Enabled)
                    );
            }
        }

        /// <summary>
        /// 完成UOW
        /// </summary>
        protected override void CompleteUow()
        {
            Commit();
            if (CurrentTransaction != null)
            {
                CurrentTransaction.Complete();
            }
        }

        /// <summary>
        /// 异步完成UOW
        /// </summary>
        /// <returns></returns>
        protected override async Task CompleteUowAsync()
        {
            await CommitAsync();
            if (CurrentTransaction != null)
            {
                CurrentTransaction.Complete();
            }
        }

        /// <summary>
        /// 释放UOW
        /// </summary>
        protected override void DisposeUow()
        {
            ActiveDbContexts.Values.ForEach(Release);

            if (CurrentTransaction != null)
            {
                CurrentTransaction.Dispose();
            }
        }

        public virtual TDbContext GetOrCreateDbContext<TDbContext>()
            where TDbContext : DbContext
        {
            DbContext dbContext;
            if (!ActiveDbContexts.TryGetValue(typeof(TDbContext), out dbContext))
            {
                dbContext = Resolve<TDbContext>();               

                ActiveDbContexts[typeof(TDbContext)] = dbContext;
            }

            return (TDbContext)dbContext;
        }

        protected virtual void SaveChangesInDbContext(DbContext dbContext)
        {
            dbContext.SaveChanges();
        }

        protected virtual async Task SaveChangesInDbContextAsync(DbContext dbContext)
        {
            await dbContext.SaveChangesAsync();
        }


        protected virtual TDbContext Resolve<TDbContext>()
        {
            return IocResolver.Resolve<TDbContext>();
        }

        protected virtual void Release(DbContext dbContext)
        {
            dbContext.Dispose();
            IocResolver.Release(dbContext);
        }

        #endregion
    }
}
