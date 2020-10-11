using Newtonsoft.Json;
using Projeto.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.UI.Utils
{
    public class RequestApiAdvisor
    {
        public static async Task<Previsao72> PostCallAPI(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                    var response = await client.GetAsync(url);
                    if (response != null)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var objetoSerializado = JsonConvert.DeserializeObject<ResponseApiAdvisor>(jsonString);
                        var diaComMaiorChuva = objetoSerializado.data.Where(x => x.rain.precipitation == objetoSerializado.data.Max(x => x.rain.precipitation)).FirstOrDefault();

                        EscreverArquivo(diaComMaiorChuva);

                        return diaComMaiorChuva;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public static void EscreverArquivo(Previsao72 aux)
        {
            File.WriteAllText(@"JsonPast\movie.json", JsonConvert.SerializeObject(aux));
        }
    }
}
