using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Model;

namespace ConsoleApp1.Functions
{
    public class Funciones
    {
        public ResultadoConsulta<PropiedadValor> Comprobacion(Object obj)
        {
            ResultadoConsulta<PropiedadValor> result = new ResultadoConsulta<PropiedadValor>();
            List<PropiedadValor> ValoresNulos = new List<PropiedadValor>();
            foreach(PropertyInfo propiedad in obj.GetType().GetProperties() )
            {
                PropiedadValor Propiedades = new PropiedadValor();
                Propiedades.Propiedad = propiedad.Name;
                if(propiedad.GetValue(obj) == null)
                {
                    Propiedades.Valor = "Nulo";
                    ValoresNulos.Add(Propiedades);

                }
                else
                {
                    if (propiedad.GetValue(obj).ToString() == "0")
                    {
                        Propiedades.Valor = "Nulo";
                        ValoresNulos.Add(Propiedades);
                    }
                    if(propiedad.PropertyType.IsClass)
                      {
                        ResultadoConsulta<PropiedadValor> resultClass = new ResultadoConsulta<PropiedadValor>();
                        resultClass = Comprobacion(propiedad.GetValue(obj));
                        if(!resultClass.Exito)
                        {
                            foreach(var nulosclase in resultClass.result)
                            {
                                PropiedadValor Nulos = new PropiedadValor();
                                Nulos.Propiedad = Propiedades.Propiedad + "." + nulosclase.Propiedad;
                                Nulos.Valor = "Nulo";
                                ValoresNulos.Add(Nulos);
                            }
                        }
                    }
                }
            }

            if(ValoresNulos.Count != 0)
            {
                result.Exito = false;
                result.result = ValoresNulos;
            }
            else
            {
                result.Exito = true;
                result.result = new List<PropiedadValor>();
            }
            return result;

        }


        public  async Task<string> LlamadaGetApi(string baseurl, string metodo, Dictionary<string, string> Datos)
        {
            
            string respuesta = string.Empty; 

            try
            {

                using (HttpClient _client = new HttpClient())
                {
                    
                    string Params = string.Empty;
                    bool primero = true;
                    foreach (KeyValuePair<string, string> dat in Datos)
                    {
                        if (primero)
                        {
                            Params = Params + dat.Key + "=" + dat.Value;
                            primero = false;
                        }
                        else
                        {
                            Params = Params + "&" + dat.Key + "=" + dat.Value;
                        }

                    }
                   

                    _client.BaseAddress = new Uri(baseurl);
                    HttpResponseMessage response = await _client.GetAsync(metodo + "?" + Params);
                    if(response.IsSuccessStatusCode)
                    {
                        respuesta = await response.Content.ReadAsStringAsync();
                    }

                    return respuesta;

                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}



//https://jsonplaceholder.typicode.com/comments?postId=1&id=2

