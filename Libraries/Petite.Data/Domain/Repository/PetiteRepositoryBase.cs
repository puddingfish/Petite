//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :PetiteRepositoryBase 
//        Description :    
//        Created by Wsy at 2016/6/28 15:26:33
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Petite.Core;

namespace Petite.Data.Domain.Repository
{
    /// <summary>
    /// 实现<see cref="IRepository{TEntity, TPrimaryKey}"/>接口的基类
    /// </summary>
    /// <typeparam name="TEntity">当前仓储的实体</typeparam>
    /// <typeparam name="TPrimaryKey">实体的主键类型</typeparam>
    public abstract class PetiteRepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region fields

        public abstract IQueryable<TEntity> Table { get; }
        public abstract IQueryable<TEntity> TableAsNoTracking { get;}

        #endregion        

        #region Get/Query

        public virtual T Query<T>(Func<IQueryable<TEntity>,T> queryMethod)
        {
            return queryMethod(Table);
        }

        public virtual T QueryAsNoTracking<T>(Func<IQueryable<TEntity>,T> queryMethod)
        {
            return queryMethod(TableAsNoTracking);
        }

        public virtual TEntity GetById(TPrimaryKey id)
        {
            var entity = Table.FirstOrDefault(CreateEqualityExpressionForId(id));
            if(entity==null)
            {
                throw new Exception("根据ID值未找到相应的Entity，Entity Type："+typeof(TEntity).FullName+"，ID："+id);
            }
            return entity;
        }

        public virtual async Task<TEntity> GetByIdAsync(TPrimaryKey id)
        {
            var entity = await Task.FromResult(Table.FirstOrDefault(CreateEqualityExpressionForId(id)));
            if(entity==null)
            {
                throw new Exception("根据ID值未找到相应的Entity，Entity Type：" + typeof(TEntity).FullName + "，ID：" + id);
            }
            return entity;
        }

        #endregion

        #region insert

        public abstract TEntity Insert(TEntity entity);

        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public virtual TPrimaryKey InsertAndGetId(TEntity endity)
        {
            return Insert(endity).Id;
        }

        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(InsertAndGetId(entity));
        }

        public virtual TEntity InsertOrUpdate(TEntity entity)
        {
            return entity.IsTransient() ?  Insert(entity) : Update(entity);
        }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return entity.IsTransient() ? await InsertAsync(entity) : await UpdateAsync(entity);
        }

        public virtual TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            return InsertOrUpdate(entity).Id;
        }

        public virtual Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(InsertOrUpdateAndGetId(entity));
        }

        #endregion

        #region update

        public abstract TEntity Update(TEntity entity);

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        #endregion

        #region utility

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        #endregion
    }
}
