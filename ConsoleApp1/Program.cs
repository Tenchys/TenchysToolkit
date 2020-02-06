using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;
using ConsoleApp1.Functions;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //nulos<clase1> objeto = new nulos<clase1>();
            //objeto.Dinamico = new clase1();
            //ResultadoConsulta<PropiedadValor> result = new ResultadoConsulta<PropiedadValor>();

            //result = funs.Comprobacion(objeto);
            var task = caller();
            Task.WaitAll(task);
            Console.ReadKey();
            

        }

        private static async Task caller()
        {
            Funciones funs = new Funciones();
            Dictionary<string, string> Datos = new Dictionary<string, string>();
            Datos.Add("postId", "1");
            Datos.Add("id", "2");
            string result = await funs.LlamadaGetApi("https://jsonplaceholder.typicode.com", "comments", Datos);
            Console.WriteLine(result);
            List<Respuestaapi> vuelta = new List<Respuestaapi>();
            vuelta = JsonConvert.DeserializeObject<List<Respuestaapi>>(result);
        }
    }
}
