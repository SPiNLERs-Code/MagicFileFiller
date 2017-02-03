using MagicFileFiller.DatabaseContext.Interfaces;
using MagicFileFiller.Models;
using MagicFileFiller.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagicFileFiller.Controllers
{
    public class HomeController : Controller
    {
        private IWordFileRepository _wordFileRepository;
        private IWordFieldRepository _wordFieldRepository;
        private IUnitOfWork _unitOfWork;

        public HomeController(IWordFileRepository wordFileRepository, IWordFieldRepository wordFieldRepository, IUnitOfWork unitOfWork)
        {
            _wordFileRepository = wordFileRepository;
            _wordFieldRepository = wordFieldRepository;
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var asdf = _wordFieldRepository.Get().FirstOrDefault();

            if(asdf is CheckBox)
            {
                var box = (CheckBox)asdf;
            }

            CheckBox checkBox = new CheckBox
            {
                Name = "MyCheckBox",
                IsChecked = true,
                PositionNumber = 0,
                WordFile = null
            };

            _wordFieldRepository.Add(checkBox);

            _unitOfWork.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}