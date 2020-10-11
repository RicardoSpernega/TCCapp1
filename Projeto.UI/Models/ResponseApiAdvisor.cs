using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.UI.Models
{
    public class ResponseApiAdvisor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public List<Previsao72> data { get; set; }
    }
    public class Previsao72
    {
        public DateTime date { get; set; }
        public string date_br { get; set; }
        public Rain rain { get; set; }
        public Wind wind { get; set; }
        public Temperature temperature { get; set; }
    }
    public class Temperature
    {
        public float temperatura { get; set; }

    }
    public class Rain
    {
        public float precipitation { get; set; }
    }
    public class Wind
    {
        public float velocity { get; set; }
        public string direction { get; set; }
        public float direction_degrees { get; set; }
        public float gust { get; set; }
    }

}
