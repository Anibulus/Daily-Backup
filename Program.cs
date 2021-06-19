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
            InputGetRutaRespaldo();
        }//Fin de main

        ///<SUMARY>
        ///Crea el objeto que será llamado en el resto de métodos
        private static void InputGetRutaRespaldo()
        {
            string ruta;
            do{
                WriteLine("Ingrese la dirección en la que se alojaran los respaldos");
                ruta=ReaderHelper.ValidarRuta(@ReadLine());
                if(ruta!="")
                {
                    CopyHelper ch=new CopyHelper(ruta);                
                    
                    InputAgregarOtroDirectorio(ch, ruta);

                    WriteLine("¿Cada cuánto tiempo desea que se realice? (Nm Ns Nd)");
                    string plazo=ReaderHelper.ValidarTiempoDeRespaldo(ReadLine());


                    WriteLine("Se procedera a realizar el respaldo");

                    //TODO poner un timer que el usuario puede elegir

                    ch.Respaldar();
                }
                else
                {
                    WriteLine("No se ha determinado ruta.");
                }
            }while(ruta.Equals(""));
        }//Fin de método que otorga la ruta de respaldo

        ///<SUMMARY>
        ///Bucle que agrega directoros y archivos
        private static void InputAgregarOtroDirectorio(CopyHelper ch, string ruta)
        {
            bool opc=true;
                    
            do
            {                   
                InputGetRuta(ch, ruta); 

                WriteLine(@"¿Desea agregar otro archivo o carpeta? (S\N)");
                opc=(ReadLine().Equals("s",StringComparison.OrdinalIgnoreCase));
            }while(opc);//Fin de ciclo para listado de archivos
        }

        ///<SUMMARY>
        ///Primero busca la ruta con un formato valido
        ///para después invocar  el método que pide el nombre del archivo
        private static void InputGetRuta(CopyHelper ch, string ruta)
        {
            do
            {
                WriteLine("Favor de ingresar la ruta, nombre incluyendo su extensión del archivo en ese orden o especificar carpeta terminanco con \"\\\".");    
                WriteLine("Ruta:");
                ruta=ReaderHelper.ValidarRuta(@ReadLine());
                if(ruta!="")
                {
                    InputGetNombreArchivo(ch, ruta);
                }
                else
                {
                    WriteLine("El texto ingresado no coincide con una ruta.");
                }
            }while(ruta.Equals(""));
        }//fin de método ruta

        ///<SUMMARY>
        ///Obtiene el formato de la nombre de archivo hasta que se ingrese un formato válido 
        private static void InputGetNombreArchivo(CopyHelper ch, string ruta)
        {
            string nombre;
            do
            {
                WriteLine("Nombre del archivo");
                nombre=ReaderHelper.ValidarNombreDeArchivo(ReadLine());

                if(nombre!="")
                {
                    string[] file=nombre.Split(".");
                    ch.archivos.Add(new Archivo(file[0], file.Length>1?"."+file[1]:"", ruta));
                    WriteLine("Se ha agregado el archivo a la lista");
                }
                else
                {
                    WriteLine("El texto ingresado no tiene el formato de una ruta.");
                }
            }while(nombre.Equals(""));
        }//Fin de método de nombre de archivo

    }//Fin de la clase

}//Fin de namespace
