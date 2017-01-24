using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class WordFile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<WordField> Fields { get; set; }

        public byte[] WordData { get; set; }
    }
}