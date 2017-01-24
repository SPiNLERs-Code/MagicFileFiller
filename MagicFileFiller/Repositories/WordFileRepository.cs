using MagicFileFiller.DatabaseContext.Interfaces;
using MagicFileFiller.Models;
using MagicFileFiller.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Repositories
{
    public class WordFileRepository : RepositoryBase<WordFile>, IWordFileRepository
    {
        public WordFileRepository(IDbContextManager contextManager)
            : base(contextManager)
        {
        }
    }
}
