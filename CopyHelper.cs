using System;
using System.IO;
using System.Collections.Generic;
using static System.Console;

namespace Consola
{
    public class CopyHelper
    {
        public List<Archivo> archivos{get;set;} 
        public int respaldosRealizados{get;set;}=0;
        public int limiteDeRespaldos{get;set;}=5;
        public string destino{get;set;}=@"C:\Users\anibu\Desktop\Proyectos\Platzi\Consola\bin\Program.cs";

        public CopyHelper(string destino)
        {
            this.destino=destino;
        }

        public void Respaldar()
        {
            if(archivos!=null || archivos.Count>0)
            {
                int tasaDeExito=archivos.Count;
                foreach(Archivo archivo in archivos)
                {
                    string actual=archivo.ubicacionActual+archivo.nombre+archivo.extension;
                    string destino=this.destino+archivo.nombre+archivo.extension;
                    try
                    {
                        File.Copy(actual,destino,true);
                    }
                    catch (IOException iox)  
                    {  
                        tasaDeExito--;
                        Console.WriteLine(iox.Message);  
                    }
                }
                WriteLine($"Se han respaldado {tasaDeExito} de {archivos.Count}. Tasa de éxito del {tasaDeExito*100/archivos.Count}%");
                this.respaldosRealizados++;
            }
            else
                WriteLine("El listado de archivos a respaldar debe contener al menos un archivo.");
        }//Fin de respaldar

        public bool DirectorioOArchivoExiste(string ruta)
        {
            //File.Exists
            return Directory.Exists(ruta);
        }

        public void LimiteParaRespaldar()
        {
            if(this.respaldosRealizados>=this.limiteDeRespaldos)
            {
                this.respaldosRealizados--;
                //TODO eliminar respaldos
                Directory.Delete(this.destino);                
            }
        }
        
    }//Fin de clase
}//Fin de namespace