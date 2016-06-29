using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Petite.Core;

namespace Petite.Data.Domain.Repository
{
    public partial interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        #region fields

        /// <summary>
        /// 返回一个IQueryable用于检索整个表的Entities
        /// 必须要添加<see cref="UnitOfWorkAttribute"/>属性
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// 使用"no-tracking"方式获取表
        /// 必须要添加<see cref="UnitOfWorkAttribute"/>属性
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        #endregion

        #region GET/Query

        /// <summary>
        /// 返回一个基于实体的查询
        /// 如果返回 IQueryable带有ToList()或者FirstOrDefault等则<see cref="UnitOfWorkAttribute"/>属性不是必须的
        /// </summary>
        /// <typeparam name="T">返回值类型</typeparam>
        /// <param name="queryMethod">查询实体类的方法</param>
        /// <returns></returns>
        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        /// <summary>
        /// 返回一个基于实体的查询
        /// 如果返回 IQueryable带有ToList()或者FirstOrDefault等则<see cref="UnitOfWorkAttribute"/>属性不是必须的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryMethod"></param>
        /// <returns></returns>
        T QueryAsNoTracking<T>(Func<IQueryable<TEntity>, T> queryMethod);

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        TEntity GetById(TPrimaryKey id);

        /// <summary>
        /// 异步根据ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TPrimaryKey id);

        #endregion

        #region Insert

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// 异步添加一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>
        /// 新增一个实体并返回新增实体的Id
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>新实体的Id</returns>
        TPrimaryKey InsertAndGetId(TEntity entity);

        /// <summary>
        ///异步新增一个实体并返回实体的Id
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        /// <summary>
        /// 根据Id值进行新增或更新操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity InsertOrUpdate(TEntity entity);

        /// <summary>
        /// 根据Id值进行异步新增或更新操作
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        /// <summary>
        /// 根据Id值进行新增或更新操作并返回Id值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        /// <summary>
        /// 根据Id值进行异步新增或更新操作并返回Id值
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        #endregion

        #region Update

        /// <summary>
        /// 更新一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        TEntity Update(TEntity entity);

        /// <summary>
        /// 根据ID更新一个已有实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAction"></param>
        /// <returns></returns>
        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        /// <summary>
        /// 异步更新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// 根据ID异步更新一个已有的实体
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateAction"></param>
        /// <returns></returns>
        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);

        #endregion

        #region Delete

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Delete(TEntity entity);

        /// <summary>
        /// 根据ID删除一个实体
        /// </summary>
        /// <param name="id"></param>
        bool Delete(TPrimaryKey id);

        /// <summary>
        /// 根据给定谓词表达式批量删除实体，数量过多可能会导致性能问题
        /// </summary>
        /// <param name="predicate"></param>
        int Delete(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 异步删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// 根据ID异步删除一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TPrimaryKey id);

        /// <summary>
        /// 根据给定谓词表达式批量删除实体，数量过多可能会导致性能问题
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }
}
