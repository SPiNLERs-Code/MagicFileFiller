using MagicFileFiller.DatabaseContext.Interfaces;
using System.Data.Entity;

namespace MagicFileFiller.DatabaseContext
{
    public class DbContextFactory : IDbContextFactory<MagicFileFillerEntities>
    {
        private readonly IDatabaseInitializer<MagicFileFillerEntities> dbInitializer;

        private bool hasSetInitializer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextFactory"/> class.
        /// </summary>
        /// <param name="dbInitializer">The database initializer.</param>
        public DbContextFactory(IDatabaseInitializer<MagicFileFillerEntities> dbInitializer)
        {
            this.dbInitializer = dbInitializer;
        }


        /// <summary>
        /// Build the Entity Framework database
        /// context based on our entities.
        /// </summary>
        /// <returns>The new database context.</returns>
        public MagicFileFillerEntities Build()
        {
            if (!this.hasSetInitializer)
            {
                Database.SetInitializer(this.dbInitializer);
                this.hasSetInitializer = true;
            }

            var context = new MagicFileFillerEntities();
            return context;
        }

    }
}