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
            return View();
        }
        public async Task<JsonResult> ApiJosnResult()
        {
            RequestForJson response = await RequestApiAdvisor.PostCallAPI("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3675/hours/72?token=141bb85208a102d3278862261957739e");
            if (response == null)
                return Json("error");
            return Json(response);
        }
        public async Task<IActionResult> BuscarPred(ResponsePredicao responsePredicao)
        {
            //ResponseApiAdvisor aux = await RequestApiAdvisor.PostCallAPI("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3675/days/15?token=141bb85208a102d3278862261957739e");
            RequestForJson response = await RequestApiAdvisor.PostCallAPI("http://apiadvisor.climatempo.com.br/api/v1/forecast/locale/3675/hours/72?token=141bb85208a102d3278862261957739e");
            if (response == null)
                ViewBag.Error = "Something wrong!";
            else
            {
                var resposta = CalcularPorcentagem.BuscarPred();
                responsePredicao.Dia = new DateTime(response.Ano, response.Mes, response.Dia);
                responsePredicao.Dia.AddHours(response.Hora);
                responsePredicao.Resultado = resposta.Resultado;
            }
            return View("Index", responsePredicao);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
