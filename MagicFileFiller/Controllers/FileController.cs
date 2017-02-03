using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using MagicFileFiller.Models;
using MagicFileFiller.ViewModels;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicFileFiller.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateFileViewModel vm = new CreateFileViewModel();
            return View(vm);
        }

        [HttpPost]
        public FileResult Create(CreateFileViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }



            byte[] uploadedFile = new byte[vm.UploadFile.InputStream.Length];
            vm.UploadFile.InputStream.Read(uploadedFile, 0, uploadedFile.Length);

            var fileds = GetWordFieldsFromByte(uploadedFile);

            var memoryStream = new MemoryStream();
            memoryStream.Write(uploadedFile, 0, uploadedFile.Length);

            byte[] secondFile = new byte[vm.UploadFile.InputStream.Length];
            vm.UploadFile.InputStream.Read(secondFile, 0, secondFile.Length);

            var ss = new WmlDocument("firstFile", uploadedFile);
            var sss = new WmlDocument("secondFile", uploadedFile);

            var sources = new List<Source>();

            sources.Add(new Source(ss));
            sources.Add(new Source(sss));

            var mergedDoc = DocumentBuilder.BuildDocument(sources);

            var arra = mergedDoc.DocumentByteArray;




            return File(arra, "docx", "myfile.docx");

        }


        


        private List<WordField> GetWordFieldsFromByte(byte[] fileBytes)
        {
            var memoryStream = new MemoryStream();
            memoryStream.Write(fileBytes, 0, fileBytes.Length);

            OpenSettings asd = new OpenSettings();

            List<string> NameList = new List<string>();

            using (var wordDoc = WordprocessingDocument.Open(memoryStream, false, new OpenSettings()))
            {
                MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                foreach (SdtElement sdt in mainPart.Document.Descendants<SdtElement>())
                {
                    SdtAlias alias = sdt.Descendants<SdtAlias>().FirstOrDefault();

                    var dateType = alias.GetAttributes().FirstOrDefault().Value;


                    var name = sdt.XmlQualifiedName;

                    if (alias != null)
                    {
                        string elementName = alias.Val.Value;


                        WordField wordField;

                        switch (dateType)
                        {
                            case "RichTextField":
                                Textbox textBox = new Textbox();
                                textBox.Name = elementName;
                                wordField = textBox;
                                break;
                            case "TextField":
                                break;
                            case "Image":
                                break;
                            case "CheckBox":
                                break;
                            case "DateField":
                                break;
                        }

                    }


                }
            }

            return null;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}