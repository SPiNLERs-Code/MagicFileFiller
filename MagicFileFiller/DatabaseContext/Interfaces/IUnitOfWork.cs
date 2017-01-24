using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.DatabaseContext.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}