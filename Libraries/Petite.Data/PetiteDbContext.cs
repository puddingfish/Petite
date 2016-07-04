//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved  
//  
//        Filename :PetiteDbContext 
//        Description :  
//  
//        Created by Wsy at 2016/4/28 15:49:34
//        http://www.hafenxiang.com 
//  
//======================================================================  
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using Petite.Core;
using Castle.Core.Logging;
using System.Threading.Tasks;
using Petite.Core.Events;
using System.Data.Entity.Validation;

namespace Petite.Data
{
    public class PetiteDbContext:DbContext
    {
        #region fields
        
        public ILogger Logger { get; set; }

        #endregion

        #region Ctor

        public PetiteDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Logger = NullLogger.Instance;
            //((IObjectContextAdapter) this).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }

        #endregion

        #region Utilities

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(PetiteEntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            base.OnModelCreating(modelBuilder);
        }

        #endregion

        #region methods

        public override int SaveChanges()
        {
            try
            {
                ApplyPetiteConcepts();
return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw;
            }
            
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        /// <summary>
        /// 对数据库执行给定的 DDL/DML 命令。 
        /// 与接受 SQL 的任何 API 一样，对任何用户输入进行参数化以便避免 SQL 注入攻击是十分重要的。 您可以在 SQL 查询字符串中包含参数占位符，然后将参数值作为附加参数提供。 
        /// 您提供的任何参数值都将自动转换为 DbParameter。 ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); 
        /// 或者，您还可以构造一个 DbParameter 并将它提供给 SqlQuery。 这允许您在 SQL 查询字符串中使用命名参数。 unitOfWork.ExecuteSqlCommand("UPDATE dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        /// </summary>
        /// <param name="transactionalBehavior">对于此命令控制事务的创建。</param>
        /// <param name="sql">命令字符串。</param>
        /// <param name="parameters">要应用于命令字符串的参数。</param>
        /// <returns>执行命令后由数据库返回的结果。</returns>
        public int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            TransactionalBehavior behavior = transactionalBehavior == TransactionalBehavior.DoNotEnsureTransaction
                 ? TransactionalBehavior.DoNotEnsureTransaction
                 : TransactionalBehavior.EnsureTransaction;
            return Database.ExecuteSqlCommand(behavior, sql, parameters);
        }


        protected virtual void ApplyPetiteConcepts()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// 数据库实体验证异常
        /// </summary>
        /// <param name="exception"></param>
        private void LogDbEntityValidationException(DbEntityValidationException exception)
        {
            Logger.Error("EF提交更改时发生了一些错误：");
            foreach (var ve in exception.EntityValidationErrors.SelectMany(eve => eve.ValidationErrors))
            {
                Logger.Error(" - " + ve.PropertyName + "： " + ve.ErrorMessage);
            }
        }

        #endregion
    }
}
