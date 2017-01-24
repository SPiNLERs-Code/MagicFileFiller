using MagicFileFiller.DatabaseContext.Interfaces;
using MagicFileFiller.Models;
using MagicFileFiller.Repositories.Interfaces;

namespace MagicFileFiller.Repositories
{
    public class WordFieldRepository : RepositoryBase<WordField>, IWordFieldRepository
    {
        public WordFieldRepository(IDbContextManager contextManager)
            : base(contextManager)
        {
        }
    }
}
