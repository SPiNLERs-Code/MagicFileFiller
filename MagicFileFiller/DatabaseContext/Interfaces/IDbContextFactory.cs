using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.DatabaseContext.Interfaces
{
    public interface IDbContextFactory<T>
    {
        T Build();
    }
}