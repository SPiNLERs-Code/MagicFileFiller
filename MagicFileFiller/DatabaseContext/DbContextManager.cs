using MagicFileFiller.DatabaseContext.Interfaces;
using System;
using System.Data.Entity;

namespace MagicFileFiller.DatabaseContext
{
    public class DbContextManager<T> : IDbContextManager<T>
        where T : DbContext
    {
        private readonly IDbContextFactory<T> factory;

        private T context;
        private bool disposed = false;

        public DbContextManager(IDbContextFactory<T> factory)
        {
            this.factory = factory;
        }

        ~DbContextManager()
        {
            this.Dispose(false);
        }

        public DbContext Context
        {
            get
            {
                return this.context ?? (this.context = this.factory.Build());
            }
        }

        public bool HasContext
        {
            get { return this.Context != null; }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed == false)
            {
                if (disposing)
                {
                    if (this.HasContext)
                    {
                        this.context.Dispose();
                        this.context = null;
                    }
                }

                this.disposed = true;
            }
        }

    }
}