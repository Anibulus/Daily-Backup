using System;
using static System.Console;
using Consola.Modelo;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Bienvenido a Daily BackUp");
            WriteLine("Ingrese la dirección en la que se alojaran los respaldos");
            string ruta=ReaderHelper.ValidarRuta(@ReadLine());
            if(ruta!="")
            {
                CopyHelper ch=new CopyHelper(ruta);                
                bool opc=true;
                
                do
                {
                    WriteLine("Favor de ingresar la ruta, nombre incluyendo su extensión del archivo en ese orden.");    
                    WriteLine("Ruta");
                    ruta=ReaderHelper.ValidarRuta(@ReadLine());
                    if(ruta!="")
                    {
                        WriteLine("Nombre del archivo");
                        string nombre=ReaderHelper.ValidarNombreDeArchivo(ReadLine());
                        if(nombre!="")
                        {
                            string[] file=nombre.Split(".");
                            ch.archivos.Add(new Archivo(file[0], "."+file[1], ruta));
                            WriteLine("Se ha agregado el archivo a la lista");
                        }
                    }
                    
                    WriteLine(@"¿Desea agregar otro archivo o carpeta? (S\N)");
                    opc=(ReadLine().Equals("s"));
                }while(opc);//Fin de ciclo para listado de archivos

                WriteLine("¿Cada cuánto tiempo desea que se realice? (Nm Ns Nd)");
                string plazo=ReaderHelper.ValidarTiempoDeRespaldo(ReadLine());


                WriteLine("Se procedera a realizar el respaldo");
                ch.Respaldar();
            }
            else
            {
                WriteLine("No se ha determinado ruta.");
            }

        }//Fin de main

    }//Fin de la clase

}//Fin de namespace
