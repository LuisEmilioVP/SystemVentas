using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SystemVentas.Domain.Repository
{
    public interface IBaseRepositor<TEntity> where TEntity : class
    {
        bool Exists(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetEntities();
        TEntity GetEntity(int entityId);

        void Add(TEntity entity);
        void Add(TEntity[] entities);

        void Update(TEntity entity);
        void Update(TEntity[] entities);

        void Remove(TEntity entity);
        void Remove(TEntity[] entities);

        void SaveChanges();
    }
}
