using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class SelectType : FieldType
    {
        public List<SelectItem> Items { get; set; }

        public SelectItem DefaultItem { get; set; }
    }
}