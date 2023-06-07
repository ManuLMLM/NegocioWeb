using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosOperaciones.Solicitudes
{
    public class Solicitudes
    {
        public static async Task<string> SolicitarGet(string url)
        {
            HttpClient pedido = new HttpClient();
            var respuesta = await pedido.GetAsync(url);
            var contenido = await respuesta.Content.ReadAsStringAsync();
            return contenido;
        }
        
    }
}
