using System;

namespace Consola
{
    public class Archivo
    {
        public string nombre{get;set;}
        public string extension{get;set;}
        public string ubicacionActual{get;set;}
        
        public Archivo(string nombre, string extension,string ubicacion)
        {        
            this.nombre=nombre;
            this.extension=extension;
            ubicacionActual=ubicacion;
        }
    }
}