using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SystemVentas.Domain.Repository;
using SystemVentas.Infrastructure.Context;

namespace SystemVentas.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepositor<TEntity> where TEntity : class
    {
        private readonly SystemVentasContext context;
        private readonly DbSet<TEntity> entities;

        public BaseRepository(SystemVentasContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntity(int entityId)
        {
            return this.entities.Find(entityId);
        }

        public virtual void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Add(TEntity[] entities)
        {
            this.entities.AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.entities.UpdateRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public virtual void Remove(TEntity[] entities)
        {
            this.entities.RemoveRange(entities);
        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
