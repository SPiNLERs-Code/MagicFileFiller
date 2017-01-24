using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MagicFileFiller.Repositories.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        TEntity Find(object id);

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Get();

        void LoadCollection<TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> expression)
            where TElement : class;

        void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> expression)
            where TProperty : class;

        void Update(TEntity entityToUpdate);
    }
}