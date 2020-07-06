using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Metodos
    public static class GuardaString
    {
        /// <summary>
        /// Escribe sobre un archivo de texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns>True si logra hacer la escritura del archivo, false caso contrario</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo + ".txt", true))
            {
                sw.Write(texto);
                retorno = true;
            }
            return retorno;
        }
    }
    #endregion
}
