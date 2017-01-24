using MagicFileFiller.Models;
using System.Data.Entity;

namespace MagicFileFiller.DatabaseContext
{
    public class MagicFileFillerEntities : DbContext
    {
        public MagicFileFillerEntities()
            : base("Name=MagicFileFillerEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordField>().ToTable("WordField");
            modelBuilder.Entity <Models.Selection>().ToTable("Selection");
            modelBuilder.Entity<CheckBox>().ToTable("CheckBox");
            modelBuilder.Entity<SelectItem>().ToTable("SelectItem");
            modelBuilder.Entity<Textbox>().ToTable("Textbox");
            modelBuilder.Entity<WordFile>().ToTable("WordFile");
        }
    }
}