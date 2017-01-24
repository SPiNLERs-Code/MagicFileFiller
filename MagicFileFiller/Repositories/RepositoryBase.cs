using MagicFileFiller.DatabaseContext.Interfaces;
using MagicFileFiller.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MagicFileFiller.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected RepositoryBase(IDbContextManager contextManager)
        {
            if (contextManager == null) throw new NullReferenceException();

            this.ContextManager = contextManager;
        }

        protected DbContext Context
        {
            get
            {
                return this.ContextManager.Context;
            }
        }

        protected IDbContextManager ContextManager { get; private set; }

        private IDbSet<T> DbSet
        {
            get
            {
                return this.Context.Set<T>();
            }
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter)
        {
            return this.Get().Where(filter);
        }

        public virtual IQueryable<T> Get()
        {
            return this.DbSet;
        }

        public virtual T Find(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = this.DbSet.Find(id);

            this.Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (this.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToDelete);
            }

            this.DbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            this.DbSet.Attach(entityToUpdate);
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void LoadCollection<TElement>(T entity, Expression<Func<T, ICollection<TElement>>> expression) where TElement : class
        {
            this.Context.Entry(entity).Collection(expression).Load();
        }

        public virtual void LoadReference<TProperty>(T entity, Expression<Func<T, TProperty>> expression) where TProperty : class
        {
            this.Context.Entry(entity).Reference(expression).Load();
        }
    }
}