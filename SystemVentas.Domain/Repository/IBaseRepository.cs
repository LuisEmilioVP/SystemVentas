using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SystemVentas.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool Existx(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetEntities();
        TEntity GetEntity(int entityid);

        void Add(TEntity entity);
        void Add(TEntity[] entities);

        void Update(TEntity entity);
        void Update(TEntity[] entities);

        void Remove(TEntity entity);
        void Remove(TEntity[] entities);

        void SaveChanges();
    }
}
