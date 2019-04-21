using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Caliber2.Models;
using Caliber2.Helpers;

namespace Caliber2.Controllers
{
    public class SearchController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Details(string searchtext)
        {
            ViewBag.SearchText = searchtext;
            return View("Results");
        }

        public async Task<ActionResult> Speech()
        {
            string speechText = await SpeechToTextHelper.RecognizeSpeechAsync();
            Console.WriteLine("Speech Recognised:" +speechText);
            ViewBag.SearchText = speechText;
            return View("Results");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
