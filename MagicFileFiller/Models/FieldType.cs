using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public abstract class FieldType
    {
        public virtual List<FormularField> FormularFields { get; set; }

        public int Id { get; set; }
    }
}