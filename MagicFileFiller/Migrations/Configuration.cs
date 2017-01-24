namespace MagicFileFiller.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MagicFileFiller.DatabaseContext.MagicFileFillerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MagicFileFiller.DatabaseContext.MagicFileFillerEntities context)
        {
            
        }
    }
}
