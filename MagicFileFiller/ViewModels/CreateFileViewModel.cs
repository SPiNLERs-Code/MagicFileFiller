using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace MagicFileFiller.ViewModels
{
    public class CreateFileViewModel
    {
        

        [Required]
        public string Name { get; set; }

        public string FormInformation { get; set; }

        public byte[] WordData { get; set; }

        [Required]
        public HttpPostedFileBase UploadFile { get; set; }

    }
}