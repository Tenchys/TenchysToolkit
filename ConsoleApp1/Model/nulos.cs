using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class nulos<T>
    {
        public string Letras { get; set; }
        public int Numeros { get; set; }
        public double doble { get; set; }
        public T Dinamico { get; set; }
    }

    public class clase1
    {
        public string Letras { get; set; }
        public int Numeros { get; set; }
        public decimal Decimales { get; set; }

    }

    public class clase2
    {
        public string Letras { get; set; }
        public int Numeros { get; set; }
        public decimal Decimales { get; set; }
    }

    public class ResultadoConsulta<T>
    {
        public bool Exito { get; set; }

        public List<T> result { get; set; }
    }

    public class PropiedadValor
    {
        public string Propiedad { get; set; }
        public string Valor { get; set; }

    }

    public class Respuestaapi
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}
