using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagicFileFiller.DatabaseContext
{
    public class CreateDatabaseIfNotExist : CreateDatabaseIfNotExists<MagicFileFillerEntities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DropCreateDatabaseIfModelChangesInitializer"/> class.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        public CreateDatabaseIfNotExist()
        {

        }
    }
}