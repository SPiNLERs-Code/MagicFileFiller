using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class TextBoxType : FieldType
    {
        public int MaxLenght { get; set; }

        public string DefaultValue { get; set; }
    }
}