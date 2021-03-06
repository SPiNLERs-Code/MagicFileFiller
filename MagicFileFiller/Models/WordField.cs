﻿using MagicFileFiller.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagicFileFiller.Models
{
    public class WordField
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PositionNumber { get; set; }

        public virtual WordFile WordFile { get; set; }
    }
}