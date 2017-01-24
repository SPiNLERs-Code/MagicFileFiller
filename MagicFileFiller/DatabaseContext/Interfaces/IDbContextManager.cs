using System;
using System.Data.Entity;

namespace MagicFileFiller.DatabaseContext.Interfaces
{
    public interface IDbContextManager : IDisposable
    {
        DbContext Context { get; }

        bool HasContext { get; }

    }

    public interface IDbContextManager<T> : IDbContextManager
    {
    }
}