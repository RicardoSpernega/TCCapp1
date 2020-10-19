using Newtonsoft.Json;
using Projeto.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.UI.Utils
{
    public class CalcularPorcentagem
    {
        public static ResponsePredicao BuscarPred()
        {
            var aux = File.ReadAllText("dadosResponse.json");
            return JsonConvert.DeserializeObject<ResponsePredicao>(aux);
        }
    }
}
