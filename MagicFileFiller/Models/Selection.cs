using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class Selection : WordField
    {
        public virtual List<SelectItem> Items { get; set; }
    }
}