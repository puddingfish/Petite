//======================================================================  
//  
//        Copyright (C) 2016 哈分享网      
//        All rights reserved    
//        Filename :EfRepository 
//        Description :    
//        Created by Wsy at 2016/6/29 11:08:10
//        http://www.hafenxiang.com 
//  
//======================================================================  

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petite.Core;
using Petite.Core.Domain.Entities;
using Petite.Data.Domain.Repository;

namespace Petite.Data.EntityFramework.Repositories
{
     public class EfRepository<TDbContext,TEntity,TPrimaryKey>:PetiteRepositoryBase<TEntity,TPrimaryKey> 
        where TEntity:class,IEntity<TPrimaryKey>
         where TDbContext :DbContext
    {
        #region fields

        protected virtual TDbContext Context { get; }

        protected virtual DbSet<TEntity> Entities => Context.Set<TEntity>();

        public override IQueryable<TEntity> Table => Entities;
        public override IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        #endregion

        #region ctors
        
        public EfRepository(TDbContext context)
        {
            Context = context;
        }

        #endregion

        #region methods

        #region insert

        public override TEntity Insert(TEntity entity)
        {
            return Entities.Add(entity);
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity)
        {
            entity = Insert(entity);
            if(entity.IsTransient())
            {
                Context.SaveChanges();
            }
            return entity.Id;
        }

        public override async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity);
            if(entity.IsTransient())
            {
                await Context.SaveChangesAsync();
            }
            return entity.Id;
        }

        public override TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = InsertOrUpdate(entity);

            if (entity.IsTransient())
            {
                Context.SaveChanges();
            }

            return entity.Id;
        }

        public override async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await InsertOrUpdateAsync(entity);

            if (entity.IsTransient())
            {
                await Context.SaveChangesAsync();
            }

            return entity.Id;
        }

        #endregion

        #region update

        public override TEntity Update(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override Task<TEntity> UpdateAsync(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        #endregion

        #region delete

        public override void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            if(entity is ISoftDelete)
            {
                (entity as ISoftDelete).IsDeleted = true;
            }
            else
            {
                Entities.Remove(entity);
            }
        }

        public override void Delete(TPrimaryKey id)
        {
            var entity = Entities.Local.FirstOrDefault(ent => EqualityComparer<TPrimaryKey>.Default.Equals(ent.Id, id));
            if (entity == null)
            {
                entity = Table.FirstOrDefault(CreateEqualityExpressionForId(id));
                if (entity == null)
                {
                    return;
                }
            }

            Delete(entity);
        }

        #endregion

        #endregion

        #region utility

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!Entities.Local.Contains(entity))
            {
                Entities.Attach(entity);
            }
        }

        #endregion
    }
}
