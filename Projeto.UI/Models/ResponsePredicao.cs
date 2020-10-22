using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.UI.Models
{
    public class ResponsePredicao
    {
        public float Resultado { get; set; }
        public DateTime Dia { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string uf { get; set; }
        public string cep { get; set; }
    }
}
