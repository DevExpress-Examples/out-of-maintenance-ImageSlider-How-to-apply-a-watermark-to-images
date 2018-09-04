using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageSliderWithWatermark.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["isWatermarkApplied"] = false;
            return View();
        }

        [HttpPost]
        public ActionResult Index(bool? applyWatermarkCheckBox)
        {
            ViewData["isWatermarkApplied"] = applyWatermarkCheckBox;
            return View();
        }
    }
}