using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.UI.Models
{
    public class RequestForJson
    {
        public int Hora  { get; set; }
        public int Dia  { get; set; }
        public int Mes  { get; set; }
        public int Ano  { get; set; }
        public int Estacao  { get; set; }
        public float Acumulado  { get; set; }
    }
}
