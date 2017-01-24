using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class SelectItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Selection Selection { get; set; }
    }
}