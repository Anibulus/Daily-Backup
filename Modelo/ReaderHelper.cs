using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Consola.Modelo
{
    public static class ReaderHelper
    { 
        ///Una funcion que comienza por agregar \ al path si no lo tiene
        ///y procede a validar su estructura
        public static string ValidarRuta(string path)
        {            
            path=(!path.EndsWith(@"\"))?path+@"\":path;
            
            return Regex.IsMatch(path.Trim(),@"[A-z]:(\\[A-z_\-. 0-9]+)+\\")?path:"";
        }
        public static string ValidarNombreDeArchivo(string nombre)
        {
            return Regex.IsMatch(nombre.Trim(),@"[\w_\-]+.[A-z]{2,5}")?nombre:"";            
        } 

        public static string ValidarTiempoDeRespaldo(string plazo)
        {
            return Regex.IsMatch(plazo.Trim(),@"([0-9]+[Mm])? ?([0-9]+[Ss])? ?([0-9]+[Dd])?")?plazo:"";
        }
    }//Fin de la clase
}