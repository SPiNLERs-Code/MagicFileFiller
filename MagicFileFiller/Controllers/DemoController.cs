using MagicFileFiller.DatabaseContext.Interfaces;
using MagicFileFiller.Models;
using MagicFileFiller.Repositories.Interfaces;
using MagicFileFiller.ViewModels.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicFileFiller.Controllers
{
    public class DemoController : Controller
    {
        private IWordFieldRepository _wordFieldRepository;
        private IUnitOfWork _unitOfWork;

        public DemoController(IWordFieldRepository wordFieldRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _wordFieldRepository = wordFieldRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Textbox wordField = new Textbox()
            {
                Name = "MyWordField",
                PositionNumber = 0,
                Text = "asdf"
                
            };

            _wordFieldRepository.Add(wordField);
            _unitOfWork.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Change()
        {
            var myField = _wordFieldRepository.Get().Where(x => x.Id==35).FirstOrDefault();

            CheckBox wordField = new CheckBox()
            {
                Id = myField.Id,
                IsChecked = true,
                Name = myField.Name,
                PositionNumber = myField.PositionNumber
            };

            _wordFieldRepository.Update(wordField);
            _unitOfWork.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FillListViewModel vm)
        {
            return View();
        }
    }
}