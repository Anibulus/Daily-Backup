using System;
using System.Collections.Generic;
using static System.Console;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Bienvenido a Daily BackUp");
            WriteLine("Ingrese la dirección en la que se alojaran los respaldos");
            string ruta=@ReadLine()+"\\";
            CopyHelper ch=new CopyHelper(ruta);
            ch.archivos=new List<Archivo>();

            int opc=0;
            WriteLine("Favor de ingresar la ruta, nombre y extension del archivo en ese orden");
            while(opc!=2)
            {
                
                WriteLine("Ruta");
                ruta=ReadLine()+"\\";
                WriteLine("Nombre del archivo");
                string nombre=ReadLine();
                WriteLine("Extension");
                string extension=ReadLine();
                
                ch.archivos.Add(new Archivo(nombre, extension, ruta));
                WriteLine("Se ha agregado el archivo a la lista");

                opc++;
            }

            WriteLine("Se procedera a realizar el respaldo");
            ch.Respaldar();

        }
    }

}//Fin de namespace
