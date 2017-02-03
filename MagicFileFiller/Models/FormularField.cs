using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class FormularField
    {
        public int Id { get; set; }

        public string LabelText { get; set; }

        public bool IsRequired { get; set; }

        public FieldType FieldType { get; set; }
    }
}