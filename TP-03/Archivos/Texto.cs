using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Método que genera el guardado de un archivo de texto
        /// </summary>
        /// <param name="archivo">string con la ruta del archivo a guardar</param>
        /// <param name="datos">string con la información a guardar</param>
        /// <returns>bool true si el guardado se realizó correctamente, excepcion caso contrario</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }

        /// <summary>
        /// Método que realiza la lectura de un archivo de texto
        /// </summary>
        /// <param name="archivo">string con la ruta del archivo a leer</param>
        /// <param name="datos">string con la información a leer</param>
        /// <returns>bool true si la lectura se realizó correctamente, excepcion caso contrario</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
        }
    }
}
