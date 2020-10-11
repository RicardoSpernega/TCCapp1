using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Projeto.UI.Models;
using Projeto.UI.Utils;

namespace Projeto.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            //ResponseApiAdvisor aux = await RequestApiAdvisor.PostCallAPI("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3675/days/15?token=141bb85208a102d3278862261957739e");
            Previsao72 aux = await RequestApiAdvisor.PostCallAPI("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3675/hours/72?token=141bb85208a102d3278862261957739e");
            if (aux == null)
                ViewBag.Error = "Something wrong!";
            return View();
        }
        public async Task<JsonResult> ApiJosnResult()
        {
            Previsao72 aux = await RequestApiAdvisor.PostCallAPI("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3675/hours/72?token=141bb85208a102d3278862261957739e");
            if (aux == null)
                return Json("eroor");
            return Json(aux);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
